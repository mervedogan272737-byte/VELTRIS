/*
 * VELTRIS — Varlık Varlığı
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */
namespace Veltris.Api.Domain.Entities;

public sealed class GuvenlikVarligi
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid KurumId { get; set; }
    public required string Ad { get; set; }
    public required string VarlikTuru { get; set; }
    public string? HostAdi { get; set; }
    public string? IpAdresi { get; set; }
    public string? IsletimSistemi { get; set; }
    public required string Kritiklik { get; set; }
    public required string Durum { get; set; }
    public DateTime OlusturulmaTarihiUtc { get; set; } = DateTime.UtcNow;
    public DateTime GuncellenmeTarihiUtc { get; set; } = DateTime.UtcNow;
}
