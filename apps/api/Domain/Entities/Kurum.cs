/*
 * VELTRIS — Kurum Entity
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

namespace Veltris.Api.Domain.Entities;

public sealed class Kurum
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Ad { get; set; }

    public string? Aciklama { get; set; }

    public bool Aktif { get; set; } = true;

    public DateTime OlusturulmaTarihiUtc { get; set; } = DateTime.UtcNow;

    public ICollection<Kullanici> Kullanicilar { get; set; } = new List<Kullanici>();
}
