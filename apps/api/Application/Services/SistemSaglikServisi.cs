/*
 * VELTRIS — Sistem Sağlık Servisi
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Veltris.Api.Models.Responses;

namespace Veltris.Api.Application.Services;

public sealed class SistemSaglikServisi
{
    public SistemSaglikYaniti SaglikDurumunuGetir()
    {
        return new SistemSaglikYaniti(
            Durum: "Healthy",
            Platform: "VELTRIS",
            Surum: "1.0.0",
            ZamanUtc: DateTime.UtcNow
        );
    }

    public ApiBilgiYaniti ApiBilgisiniGetir(IHostEnvironment ortam)
    {
        return new ApiBilgiYaniti(
            Platform: "VELTRIS Enterprise Security Intelligence API",
            Surum: "1.0.0",
            Aciklama: "VELTRIS güvenlik platformu çekirdek API katmanı.",
            Ortam: ortam.EnvironmentName,
            Durum: "Active"
        );
    }
}
