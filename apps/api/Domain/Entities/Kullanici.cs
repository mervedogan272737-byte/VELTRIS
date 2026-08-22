/*
 * VELTRIS — Kullanıcı Entity
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

namespace Veltris.Api.Domain.Entities;

public sealed class Kullanici
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid KurumId { get; set; }

    public required string Ad { get; set; }

    public required string Soyad { get; set; }

    public required string Eposta { get; set; }

    public required string SifreOzeti { get; set; }

    public bool Aktif { get; set; } = true;

    public DateTime OlusturulmaTarihiUtc { get; set; } = DateTime.UtcNow;

    public DateTime? SonGirisTarihiUtc { get; set; }

    public Kurum? Kurum { get; set; }

    public ICollection<KullaniciRol> KullaniciRolleri { get; set; } = new List<KullaniciRol>();
}
