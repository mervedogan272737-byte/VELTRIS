/*
 * VELTRIS — Gerçek Dashboard Servisi
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */
using Microsoft.EntityFrameworkCore;
using Veltris.Api.Application.Guvenlik;
using Veltris.Api.Infrastructure.Data;

namespace Veltris.Api.Application.Dashboard;

public sealed class DashboardServisi
{
    private readonly VeltrisDbContext _veritabani;
    private readonly RiskMotoruServisi _riskMotoru;

    public DashboardServisi(
        VeltrisDbContext veritabani,
        RiskMotoruServisi riskMotoru)
    {
        _veritabani = veritabani;
        _riskMotoru = riskMotoru;
    }

    public async Task<DashboardOzetYaniti> OzetGetirAsync(CancellationToken ct = default)
    {
        var risk = await _riskMotoru.HesaplaAsync(ct);

        var tehditler = await _veritabani.Set<Domain.Entities.GuvenlikTehdidi>()
            .AsNoTracking()
            .Where(x => x.Durum != "KAPANDI")
            .OrderByDescending(x => x.OlusturulmaTarihiUtc)
            .Take(8)
            .ToListAsync(ct);

        var olaylar = await _veritabani.Set<Domain.Entities.GuvenlikOlayi>()
            .AsNoTracking()
            .Where(x => x.Durum != "KAPANDI")
            .OrderByDescending(x => x.OlusturulmaTarihiUtc)
            .Take(8)
            .ToListAsync(ct);

        var aktiviteler = new List<DashboardAktiviteYaniti>();

        aktiviteler.AddRange(
            olaylar.Select(x => new DashboardAktiviteYaniti(
                x.Baslik,
                "Olay Yönetimi",
                x.OlusturulmaTarihiUtc.ToLocalTime().ToString("dd.MM.yyyy HH:mm"))));

        aktiviteler.AddRange(
            tehditler.Select(x => new DashboardAktiviteYaniti(
                x.Baslik,
                x.Kaynak,
                x.OlusturulmaTarihiUtc.ToLocalTime().ToString("dd.MM.yyyy HH:mm"))));

        return new DashboardOzetYaniti(
            risk.GuvenlikSkoru,
            risk.AktifTehditSayisi,
            risk.KritikTehditSayisi,
            risk.AcikOlaySayisi,
            risk.YuksekOncelikliOlaySayisi,
            risk.ZafiyetSayisi,
            risk.KritikZafiyetSayisi,
            new SistemDurumuYaniti("Hazır", "Risk motoru aktif"),
            new SistemDurumuYaniti("Sağlıklı", "PostgreSQL aktif"),
            new SistemDurumuYaniti("Hazır", "Entegrasyon bekleniyor"),
            tehditler.Select(x => new DashboardTehditYaniti(
                x.Baslik,
                x.Kaynak,
                x.Seviye,
                x.OlusturulmaTarihiUtc.ToLocalTime().ToString("dd.MM.yyyy HH:mm"))).ToArray(),
            aktiviteler.OrderByDescending(x => x.Zaman).Take(10).ToArray(),
            new DashboardRiskYaniti(
                risk.GuvenlikSkoru > 0 ? risk.GuvenlikSkoru.ToString() : "N/A",
                risk.Seviye,
                risk.Aciklama,
                risk.KritikTehditSayisi > 0 || risk.KritikZafiyetSayisi > 0));
    }
}
