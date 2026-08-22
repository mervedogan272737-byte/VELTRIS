/*
 * VELTRIS — Güvenlik Modülleri DTO Katmanı
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */
namespace Veltris.Api.Application.Guvenlik;

public sealed record TehditOlusturmaIstegi(
    Guid KurumId,
    string Baslik,
    string? Aciklama,
    string Kaynak,
    string Seviye,
    string Durum,
    int RiskSkoru,
    string? Gosterge);

public sealed record TehditGuncellemeIstegi(
    string Baslik,
    string? Aciklama,
    string Kaynak,
    string Seviye,
    string Durum,
    int RiskSkoru,
    string? Gosterge);

public sealed record OlayOlusturmaIstegi(
    Guid KurumId,
    string Baslik,
    string? Aciklama,
    string Oncelik,
    string Durum,
    int RiskSkoru,
    Guid? TehditId);

public sealed record OlayGuncellemeIstegi(
    string Baslik,
    string? Aciklama,
    string Oncelik,
    string Durum,
    int RiskSkoru,
    Guid? TehditId);

public sealed record ZafiyetOlusturmaIstegi(
    Guid KurumId,
    string Baslik,
    string? CveKodu,
    decimal CvssSkoru,
    string Seviye,
    string Durum,
    int EtkilenenVarlikSayisi,
    string? CozumNotu);

public sealed record ZafiyetGuncellemeIstegi(
    string Baslik,
    string? CveKodu,
    decimal CvssSkoru,
    string Seviye,
    string Durum,
    int EtkilenenVarlikSayisi,
    string? CozumNotu);

public sealed record VarlikOlusturmaIstegi(
    Guid KurumId,
    string Ad,
    string VarlikTuru,
    string? HostAdi,
    string? IpAdresi,
    string? IsletimSistemi,
    string Kritiklik,
    string Durum);

public sealed record VarlikGuncellemeIstegi(
    string Ad,
    string VarlikTuru,
    string? HostAdi,
    string? IpAdresi,
    string? IsletimSistemi,
    string Kritiklik,
    string Durum);
