/*
 * VELTRIS — Rol Entity
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

namespace Veltris.Api.Domain.Entities;

public sealed class Rol
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid KurumId { get; set; }

    public required string Ad { get; set; }

    public string? Aciklama { get; set; }

    public bool SistemRolu { get; set; }

    public bool Aktif { get; set; } = true;

    public DateTime OlusturulmaTarihiUtc { get; set; } = DateTime.UtcNow;

    public Kurum? Kurum { get; set; }

    public ICollection<KullaniciRol> KullaniciRolleri { get; set; } = new List<KullaniciRol>();

    public ICollection<RolYetki> RolYetkileri { get; set; } = new List<RolYetki>();
}
