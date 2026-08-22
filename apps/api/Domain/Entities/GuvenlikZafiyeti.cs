/*
 * VELTRIS — Zafiyet Varlığı
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */
namespace Veltris.Api.Domain.Entities;

public sealed class GuvenlikZafiyeti
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid KurumId { get; set; }
    public required string Baslik { get; set; }
    public string? CveKodu { get; set; }
    public decimal CvssSkoru { get; set; }
    public required string Seviye { get; set; }
    public required string Durum { get; set; }
    public int EtkilenenVarlikSayisi { get; set; }
    public string? CozumNotu { get; set; }
    public DateTime OlusturulmaTarihiUtc { get; set; } = DateTime.UtcNow;
    public DateTime GuncellenmeTarihiUtc { get; set; } = DateTime.UtcNow;
}
