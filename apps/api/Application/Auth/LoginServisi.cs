/*
 * VELTRIS — Login Servisi
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.EntityFrameworkCore;
using Veltris.Api.Infrastructure.Data;
using Veltris.Api.Infrastructure.Security;

namespace Veltris.Api.Application.Auth;

public sealed class LoginServisi
{
    private readonly VeltrisDbContext _veritabani;
    private readonly SifreHashServisi _sifreHashServisi;
    private readonly JwtTokenServisi _jwtTokenServisi;
    private readonly JwtAyarlari _jwtAyarlari;

    public LoginServisi(
        VeltrisDbContext veritabani,
        SifreHashServisi sifreHashServisi,
        JwtTokenServisi jwtTokenServisi,
        JwtAyarlari jwtAyarlari)
    {
        _veritabani = veritabani;
        _sifreHashServisi = sifreHashServisi;
        _jwtTokenServisi = jwtTokenServisi;
        _jwtAyarlari = jwtAyarlari;
    }

    public async Task<GirisCevabi?> GirisYapAsync(
        GirisIstegi istek,
        CancellationToken cancellationToken = default)
    {
        var eposta = istek.Eposta.Trim();

        if (string.IsNullOrWhiteSpace(eposta) ||
            string.IsNullOrWhiteSpace(istek.Sifre))
        {
            return null;
        }

        var kullanici = await _veritabani.Kullanicilar
            .Include(x => x.KullaniciRolleri)
                .ThenInclude(x => x.Rol)
                    .ThenInclude(x => x!.RolYetkileri)
                        .ThenInclude(x => x.Yetki)
            .SingleOrDefaultAsync(
                x => x.Eposta == eposta,
                cancellationToken);

        if (kullanici is null || !kullanici.Aktif)
        {
            return null;
        }

        if (!_sifreHashServisi.Dogrula(
                istek.Sifre,
                kullanici.SifreOzeti))
        {
            return null;
        }

        var roller = kullanici.KullaniciRolleri
            .Where(x => x.Rol is not null && x.Rol.Aktif)
            .Select(x => x.Rol!.Ad)
            .Distinct(StringComparer.Ordinal)
            .ToArray();

        var yetkiler = kullanici.KullaniciRolleri
            .Where(x => x.Rol is not null && x.Rol.Aktif)
            .SelectMany(x => x.Rol!.RolYetkileri)
            .Where(x => x.Yetki is not null && x.Yetki.Aktif)
            .Select(x => x.Yetki!.Kod)
            .Distinct(StringComparer.Ordinal)
            .ToArray();

        kullanici.SonGirisTarihiUtc = DateTime.UtcNow;

        await _veritabani.SaveChangesAsync(cancellationToken);

        var token = _jwtTokenServisi.TokenOlustur(
            kullanici,
            roller,
            yetkiler);

        return new GirisCevabi(
            token,
            DateTime.UtcNow.AddMinutes(_jwtAyarlari.Dakika));
    }
}
