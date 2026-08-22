/*
 * VELTRIS — İlk Kurulum DTO
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using System.ComponentModel.DataAnnotations;

namespace Veltris.Api.Application.Kurulum;

public sealed record IlkKurulumDurumuYaniti(
    bool KurulumGerekli,
    int KullaniciSayisi);

public sealed record IlkYoneticiOlusturmaIstegi(
    [property: Required]
    [property: MinLength(2)]
    string Ad,

    [property: Required]
    [property: MinLength(2)]
    string Soyad,

    [property: Required]
    [property: EmailAddress]
    string Eposta,

    [property: Required]
    [property: MinLength(12)]
    string Sifre);
