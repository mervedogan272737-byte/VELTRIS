/*
 * VELTRIS — İlk Kurulum DTO
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using System.ComponentModel.DataAnnotations;

namespace Veltris.Api.Application.Kurulum;

public sealed class IlkKurulumDurumuYaniti
{
    public IlkKurulumDurumuYaniti(
        bool kurulumGerekli,
        int kullaniciSayisi)
    {
        KurulumGerekli = kurulumGerekli;
        KullaniciSayisi = kullaniciSayisi;
    }

    public bool KurulumGerekli { get; }

    public int KullaniciSayisi { get; }
}

public sealed class IlkYoneticiOlusturmaIstegi
{
    [Required]
    [MinLength(2)]
    public string Ad { get; set; } = string.Empty;

    [Required]
    [MinLength(2)]
    public string Soyad { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Eposta { get; set; } = string.Empty;

    [Required]
    [MinLength(12)]
    public string Sifre { get; set; } = string.Empty;
}
