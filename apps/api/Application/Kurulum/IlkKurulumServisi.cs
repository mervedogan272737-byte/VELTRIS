/*
 * VELTRIS — İlk Kurulum Servisi
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.EntityFrameworkCore;
using Veltris.Api.Application.Auth;
using Veltris.Api.Domain.Entities;
using Veltris.Api.Infrastructure.Data;
using Veltris.Api.Infrastructure.Security;

namespace Veltris.Api.Application.Kurulum;

public sealed class IlkKurulumServisi
{
    private readonly VeltrisDbContext _db;
    private readonly SifreHashServisi _sifreHashServisi;
    private readonly JwtTokenServisi _jwtTokenServisi;
    private readonly JwtAyarlari _jwtAyarlari;

    private static readonly (string Kod, string Ad)[] SistemYetkileri =
    [
        ("dashboard.goruntule", "Dashboard görüntüleme"),
        ("tehdit.goruntule", "Tehdit görüntüleme"),
        ("tehdit.olustur", "Tehdit oluşturma"),
        ("tehdit.guncelle", "Tehdit güncelleme"),
        ("tehdit.sil", "Tehdit silme"),
        ("olay.goruntule", "Olay görüntüleme"),
        ("olay.olustur", "Olay oluşturma"),
        ("olay.guncelle", "Olay güncelleme"),
        ("olay.sil", "Olay silme"),
        ("zafiyet.goruntule", "Zafiyet görüntüleme"),
        ("zafiyet.olustur", "Zafiyet oluşturma"),
        ("zafiyet.guncelle", "Zafiyet güncelleme"),
        ("zafiyet.sil", "Zafiyet silme"),
        ("varlik.goruntule", "Varlık görüntüleme"),
        ("varlik.olustur", "Varlık oluşturma"),
        ("varlik.guncelle", "Varlık güncelleme"),
        ("varlik.sil", "Varlık silme"),
        ("risk.goruntule", "Risk görüntüleme"),
        ("ai.goruntule", "AI analiz görüntüleme"),
        ("kullanici.yonet", "Kullanıcı yönetimi"),
        ("rol.yonet", "Rol yönetimi")
    ];

    public IlkKurulumServisi(
        VeltrisDbContext db,
        SifreHashServisi sifreHashServisi,
        JwtTokenServisi jwtTokenServisi,
        JwtAyarlari jwtAyarlari)
    {
        _db = db;
        _sifreHashServisi = sifreHashServisi;
        _jwtTokenServisi = jwtTokenServisi;
        _jwtAyarlari = jwtAyarlari;
    }

    public async Task<IlkKurulumDurumuYaniti> DurumuGetirAsync(
        CancellationToken cancellationToken = default)
    {
        var sayi = await _db.Kullanicilar
            .AsNoTracking()
            .CountAsync(cancellationToken);

        return new IlkKurulumDurumuYaniti(
            sayi == 0,
            sayi);
    }

    public async Task<GirisCevabi?> YoneticiOlusturAsync(
        IlkYoneticiOlusturmaIstegi istek,
        CancellationToken cancellationToken = default)
    {
        var mevcutSayi = await _db.Kullanicilar
            .CountAsync(cancellationToken);

        if (mevcutSayi != 0)
            return null;

        var eposta = istek.Eposta.Trim();

        if (string.IsNullOrWhiteSpace(eposta))
            throw new InvalidOperationException(
                "E-posta adresi zorunludur.");

        var kurum = await _db.Kurumlar
            .OrderBy(x => x.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (kurum is null)
            throw new InvalidOperationException(
                "Kurulum için kurum kaydı bulunamadı. Müşteri kurum kaydı oluşturulmadan yönetici hesabı açılamaz.");

        var yoneticiRolu = await _db.Roller
            .Include(x => x.RolYetkileri)
            .ThenInclude(x => x.Yetki)
            .SingleOrDefaultAsync(
                x => x.Ad == "Yönetici",
                cancellationToken);

        if (yoneticiRolu is null)
        {
            yoneticiRolu = new Rol
            {
                Id = Guid.NewGuid(),
                Ad = "Yönetici",
                Aktif = true
            };

            _db.Roller.Add(yoneticiRolu);
        }

        foreach (var (kod, ad) in SistemYetkileri)
        {
            var yetki = await _db.Yetkiler
                .SingleOrDefaultAsync(
                    x => x.Kod == kod,
                    cancellationToken);

            if (yetki is null)
            {
                yetki = new Yetki
                {
                    Id = Guid.NewGuid(),
                    Kod = kod,
                    Ad = ad,
                    Aktif = true
                };

                _db.Yetkiler.Add(yetki);
                await _db.SaveChangesAsync(cancellationToken);
            }

            var yetkiBaglantisiVar =
                yoneticiRolu.RolYetkileri.Any(
                    x => x.YetkiId == yetki.Id);

            if (!yetkiBaglantisiVar)
            {
                yoneticiRolu.RolYetkileri.Add(
                    new RolYetki
                    {
                        YetkiId = yetki.Id,
                        RolId = yoneticiRolu.Id
                    });
            }
        }

        var kullanici = new Kullanici
        {
            Id = Guid.NewGuid(),
            KurumId = kurum.Id,
            Ad = istek.Ad.Trim(),
            Soyad = istek.Soyad.Trim(),
            Eposta = eposta,
            SifreOzeti = _sifreHashServisi.Hashle(istek.Sifre),
            Aktif = true
        };

        kullanici.KullaniciRolleri.Add(
            new KullaniciRol
            {
                KullaniciId = kullanici.Id,
                RolId = yoneticiRolu.Id,
                Rol = yoneticiRolu
            });

        _db.Kullanicilar.Add(kullanici);

        await _db.SaveChangesAsync(cancellationToken);

        var roller = new[]
        {
            yoneticiRolu.Ad
        };

        var yetkiler = yoneticiRolu.RolYetkileri
            .Where(x => x.Yetki is not null && x.Yetki.Aktif)
            .Select(x => x.Yetki!.Kod)
            .Distinct(StringComparer.Ordinal)
            .ToArray();

        var token = _jwtTokenServisi.TokenOlustur(
            kullanici,
            roller,
            yetkiler);

        return new GirisCevabi(
            token,
            DateTime.UtcNow.AddMinutes(
                _jwtAyarlari.Dakika));
    }
}
