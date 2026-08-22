/*
 * VELTRIS — Veritabanı Kontrol Servisi
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.EntityFrameworkCore;

namespace Veltris.Api.Infrastructure.Data;

public sealed record KullaniciVeritabaniKaydi(
    Guid Id,
    string Eposta,
    bool Aktif);

public sealed record VeritabaniKullaniciKontrolSonucu(
    int KayitSayisi,
    IReadOnlyList<KullaniciVeritabaniKaydi> Kullanicilar);

public sealed class VeritabaniKontrolServisi
{
    private readonly VeltrisDbContext _veritabani;

    public VeritabaniKontrolServisi(VeltrisDbContext veritabani)
    {
        _veritabani = veritabani;
    }

    public async Task<VeritabaniKullaniciKontrolSonucu> KullanicilariOkuAsync(
        CancellationToken cancellationToken = default)
    {
        var kullanicilar = await _veritabani.Kullanicilar
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Select(x => new KullaniciVeritabaniKaydi(
                x.Id,
                x.Eposta,
                x.Aktif))
            .ToListAsync(cancellationToken);

        return new VeritabaniKullaniciKontrolSonucu(
            kullanicilar.Count,
            kullanicilar);
    }
}
