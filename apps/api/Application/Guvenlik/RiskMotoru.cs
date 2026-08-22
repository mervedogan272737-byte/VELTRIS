/*
 * VELTRIS — Risk Motoru
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */
using Microsoft.EntityFrameworkCore;
using Veltris.Api.Infrastructure.Data;

namespace Veltris.Api.Application.Guvenlik;

public sealed record RiskMotoruSonucu(
    bool VeriVar,
    int RiskSkoru,
    int GuvenlikSkoru,
    int AktifTehditSayisi,
    int KritikTehditSayisi,
    int AcikOlaySayisi,
    int YuksekOncelikliOlaySayisi,
    int ZafiyetSayisi,
    int KritikZafiyetSayisi,
    int KritikVarlikSayisi,
    string Seviye,
    string Aciklama);

public sealed class RiskMotoruServisi
{
    private readonly VeltrisDbContext _veritabani;

    public RiskMotoruServisi(VeltrisDbContext veritabani)
    {
        _veritabani = veritabani;
    }

    public async Task<RiskMotoruSonucu> HesaplaAsync(CancellationToken ct = default)
    {
        var tehditler = await _veritabani.Set<Domain.Entities.GuvenlikTehdidi>()
            .AsNoTracking().Where(x => x.Durum != "KAPANDI").ToListAsync(ct);

        var olaylar = await _veritabani.Set<Domain.Entities.GuvenlikOlayi>()
            .AsNoTracking().Where(x => x.Durum != "KAPANDI").ToListAsync(ct);

        var zafiyetler = await _veritabani.Set<Domain.Entities.GuvenlikZafiyeti>()
            .AsNoTracking().Where(x => x.Durum != "KAPANDI").ToListAsync(ct);

        var varliklar = await _veritabani.Set<Domain.Entities.GuvenlikVarligi>()
            .AsNoTracking().ToListAsync(ct);

        var kritikTehdit = tehditler.Count(x => x.Seviye == "KRİTİK");
        var yuksekOlay = olaylar.Count(x => x.Oncelik == "YÜKSEK" || x.Oncelik == "KRİTİK");
        var kritikZafiyet = zafiyetler.Count(x => x.Seviye == "KRİTİK" || x.CvssSkoru >= 9.0m);
        var kritikVarlik = varliklar.Count(x => x.Kritiklik == "KRİTİK");

        var veriVar = tehditler.Count > 0 || olaylar.Count > 0 || zafiyetler.Count > 0 || varliklar.Count > 0;

        if (!veriVar)
        {
            return new RiskMotoruSonucu(
                false, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                "VERİ YOK",
                "Risk hesaplaması için güvenlik verisi bekleniyor.");
        }

        var tehditRiski = tehditler.Count == 0 ? 0 : (int)Math.Round((decimal)tehditler.Average(x => x.RiskSkoru) * 0.35m);
        var olayRiski = olaylar.Count == 0 ? 0 : (int)Math.Round((decimal)olaylar.Average(x => x.RiskSkoru) * 0.25m);
        var zafiyetRiski = zafiyetler.Count == 0 ? 0 : (int)Math.Round(zafiyetler.Average(x => x.CvssSkoru) * 10m * 0.25m);
        var varlikRiski = varliklar.Count == 0 ? 0 : (int)Math.Round((kritikVarlik / (decimal)varliklar.Count) * 100m * 0.15m);

        var riskSkoru = Math.Clamp(
            tehditRiski + olayRiski + zafiyetRiski + varlikRiski,
            0,
            100);

        var guvenlikSkoru = 100 - riskSkoru;

        var seviye = riskSkoru >= 90
            ? "KRİTİK"
            : riskSkoru >= 70
                ? "YÜKSEK"
                : riskSkoru >= 40
                    ? "ORTA"
                    : "DÜŞÜK";

        return new RiskMotoruSonucu(
            true,
            riskSkoru,
            guvenlikSkoru,
            tehditler.Count,
            kritikTehdit,
            olaylar.Count,
            yuksekOlay,
            zafiyetler.Count,
            kritikZafiyet,
            kritikVarlik,
            seviye,
            $"VELTRIS risk motoru {seviye} seviyesinde değerlendirme üretti.");
    }
}

