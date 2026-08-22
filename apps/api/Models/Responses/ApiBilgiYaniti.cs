/*
 * VELTRIS — API Bilgi Yanıt Modeli
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

namespace Veltris.Api.Models.Responses;

public sealed record ApiBilgiYaniti(
    string Platform,
    string Surum,
    string Aciklama,
    string Ortam,
    string Durum
);
