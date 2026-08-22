/*
 * VELTRIS — Güvenlik Modülleri Servisi
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */
using Microsoft.EntityFrameworkCore;
using Veltris.Api.Domain.Entities;
using Veltris.Api.Infrastructure.Data;

namespace Veltris.Api.Application.Guvenlik;

public sealed class GuvenlikModulleriServisi
{
    private readonly VeltrisDbContext _veritabani;

    public GuvenlikModulleriServisi(VeltrisDbContext veritabani)
    {
        _veritabani = veritabani;
    }

    public Task<List<GuvenlikTehdidi>> TehditleriGetirAsync(CancellationToken ct = default) =>
        _veritabani.Set<GuvenlikTehdidi>().AsNoTracking().OrderByDescending(x => x.OlusturulmaTarihiUtc).ToListAsync(ct);

    public Task<List<GuvenlikOlayi>> OlaylariGetirAsync(CancellationToken ct = default) =>
        _veritabani.Set<GuvenlikOlayi>().AsNoTracking().OrderByDescending(x => x.OlusturulmaTarihiUtc).ToListAsync(ct);

    public Task<List<GuvenlikZafiyeti>> ZafiyetleriGetirAsync(CancellationToken ct = default) =>
        _veritabani.Set<GuvenlikZafiyeti>().AsNoTracking().OrderByDescending(x => x.CvssSkoru).ToListAsync(ct);

    public Task<List<GuvenlikVarligi>> VarliklariGetirAsync(CancellationToken ct = default) =>
        _veritabani.Set<GuvenlikVarligi>().AsNoTracking().OrderBy(x => x.Ad).ToListAsync(ct);

    public async Task<GuvenlikTehdidi> TehditOlusturAsync(TehditOlusturmaIstegi istek, CancellationToken ct = default)
    {
        var kayit = new GuvenlikTehdidi
        {
            KurumId = istek.KurumId,
            Baslik = istek.Baslik,
            Aciklama = istek.Aciklama,
            Kaynak = istek.Kaynak,
            Seviye = istek.Seviye,
            Durum = istek.Durum,
            RiskSkoru = Math.Clamp(istek.RiskSkoru, 0, 100),
            Gosterge = istek.Gosterge
        };

        _veritabani.Set<GuvenlikTehdidi>().Add(kayit);
        await _veritabani.SaveChangesAsync(ct);
        return kayit;
    }

    public async Task<bool> TehditSilAsync(Guid id, CancellationToken ct = default)
    {
        var kayit = await _veritabani.Set<GuvenlikTehdidi>().FindAsync([id], ct);
        if (kayit is null) return false;
        _veritabani.Remove(kayit);
        await _veritabani.SaveChangesAsync(ct);
        return true;
    }

    public async Task<GuvenlikOlayi> OlayOlusturAsync(OlayOlusturmaIstegi istek, CancellationToken ct = default)
    {
        var kayit = new GuvenlikOlayi
        {
            KurumId = istek.KurumId,
            Baslik = istek.Baslik,
            Aciklama = istek.Aciklama,
            Oncelik = istek.Oncelik,
            Durum = istek.Durum,
            RiskSkoru = Math.Clamp(istek.RiskSkoru, 0, 100),
            TehditId = istek.TehditId
        };

        _veritabani.Set<GuvenlikOlayi>().Add(kayit);
        await _veritabani.SaveChangesAsync(ct);
        return kayit;
    }

    public async Task<bool> OlaySilAsync(Guid id, CancellationToken ct = default)
    {
        var kayit = await _veritabani.Set<GuvenlikOlayi>().FindAsync([id], ct);
        if (kayit is null) return false;
        _veritabani.Remove(kayit);
        await _veritabani.SaveChangesAsync(ct);
        return true;
    }

    public async Task<GuvenlikZafiyeti> ZafiyetOlusturAsync(ZafiyetOlusturmaIstegi istek, CancellationToken ct = default)
    {
        var skor = Math.Clamp(istek.CvssSkoru, 0, 10);

        var kayit = new GuvenlikZafiyeti
        {
            KurumId = istek.KurumId,
            Baslik = istek.Baslik,
            CveKodu = istek.CveKodu,
            CvssSkoru = skor,
            Seviye = istek.Seviye,
            Durum = istek.Durum,
            EtkilenenVarlikSayisi = Math.Max(0, istek.EtkilenenVarlikSayisi),
            CozumNotu = istek.CozumNotu
        };

        _veritabani.Set<GuvenlikZafiyeti>().Add(kayit);
        await _veritabani.SaveChangesAsync(ct);
        return kayit;
    }

    public async Task<bool> ZafiyetSilAsync(Guid id, CancellationToken ct = default)
    {
        var kayit = await _veritabani.Set<GuvenlikZafiyeti>().FindAsync([id], ct);
        if (kayit is null) return false;
        _veritabani.Remove(kayit);
        await _veritabani.SaveChangesAsync(ct);
        return true;
    }

    public async Task<GuvenlikVarligi> VarlikOlusturAsync(VarlikOlusturmaIstegi istek, CancellationToken ct = default)
    {
        var kayit = new GuvenlikVarligi
        {
            KurumId = istek.KurumId,
            Ad = istek.Ad,
            VarlikTuru = istek.VarlikTuru,
            HostAdi = istek.HostAdi,
            IpAdresi = istek.IpAdresi,
            IsletimSistemi = istek.IsletimSistemi,
            Kritiklik = istek.Kritiklik,
            Durum = istek.Durum
        };

        _veritabani.Set<GuvenlikVarligi>().Add(kayit);
        await _veritabani.SaveChangesAsync(ct);
        return kayit;
    }

    public async Task<bool> VarlikSilAsync(Guid id, CancellationToken ct = default)
    {
        var kayit = await _veritabani.Set<GuvenlikVarligi>().FindAsync([id], ct);
        if (kayit is null) return false;
        _veritabani.Remove(kayit);
        await _veritabani.SaveChangesAsync(ct);
        return true;
    }
}
