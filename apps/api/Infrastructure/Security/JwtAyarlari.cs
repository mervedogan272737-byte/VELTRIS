/*
 * VELTRIS — Kimlik Doğrulama Ayarları
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

namespace Veltris.Api.Infrastructure.Security;

public sealed class JwtAyarlari
{
    public const string BolumAdi = "Jwt";

    public required string GizliAnahtar { get; init; }

    public required string Veren { get; init; }

    public required string HedefKitle { get; init; }

    public int Dakika { get; init; } = 30;

    public int YenilemeTokenGun { get; init; } = 7;
}
