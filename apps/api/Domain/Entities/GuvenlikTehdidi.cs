/*
 * VELTRIS — Tehdit Varlığı
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */
namespace Veltris.Api.Domain.Entities;

public sealed class GuvenlikTehdidi
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid KurumId { get; set; }
    public required string Baslik { get; set; }
    public string? Aciklama { get; set; }
    public required string Kaynak { get; set; }
    public required string Seviye { get; set; }
    public required string Durum { get; set; }
    public int RiskSkoru { get; set; }
    public string? Gosterge { get; set; }
    public DateTime OlusturulmaTarihiUtc { get; set; } = DateTime.UtcNow;
    public DateTime GuncellenmeTarihiUtc { get; set; } = DateTime.UtcNow;
}
