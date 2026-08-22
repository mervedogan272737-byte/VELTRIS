/*
 * VELTRIS — Yetki Entity
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

namespace Veltris.Api.Domain.Entities;

public sealed class Yetki
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Kod { get; set; }

    public required string Ad { get; set; }

    public string? Aciklama { get; set; }

    public bool Aktif { get; set; } = true;

    public ICollection<RolYetki> RolYetkileri { get; set; } = new List<RolYetki>();
}
