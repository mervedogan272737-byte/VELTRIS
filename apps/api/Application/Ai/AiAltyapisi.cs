/*
 * VELTRIS — AI Katmanı Entegrasyon Mimarisi
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */
namespace Veltris.Api.Application.Ai;

using Veltris.Api.Application.Guvenlik;

public sealed record AiRiskAnaliziYaniti(
    string Saglayici,
    string Durum,
    string Derece,
    string Ozet,
    IReadOnlyList<string> Oneriler);

public interface IAiRiskAnalizSaglayicisi
{
    Task<AiRiskAnaliziYaniti> AnalizEtAsync(
        RiskMotoruSonucu risk,
        CancellationToken cancellationToken = default);
}

public sealed class YerelAiRiskAnalizSaglayicisi : IAiRiskAnalizSaglayicisi
{
    public Task<AiRiskAnaliziYaniti> AnalizEtAsync(
        RiskMotoruSonucu risk,
        CancellationToken cancellationToken = default)
    {
        var derece = risk.RiskSkoru >= 90
            ? "KRİTİK"
            : risk.RiskSkoru >= 70
                ? "YÜKSEK"
                : risk.RiskSkoru >= 40
                    ? "ORTA"
                    : risk.RiskSkoru > 0
                        ? "DÜŞÜK"
                        : "VERİ YOK";

        var oneriler = new List<string>();

        if (risk.KritikTehditSayisi > 0)
            oneriler.Add("Kritik tehditleri öncelikli inceleyin.");

        if (risk.KritikZafiyetSayisi > 0)
            oneriler.Add("Kritik CVSS zafiyetleri için düzeltme planı oluşturun.");

        if (risk.YuksekOncelikliOlaySayisi > 0)
            oneriler.Add("Yüksek öncelikli olayları olay müdahale akışına alın.");

        if (risk.KritikVarlikSayisi > 0)
            oneriler.Add("Kritik varlıkları ek izleme ve erişim kontrollerine alın.");

        if (oneriler.Count == 0)
            oneriler.Add("Yeni güvenlik verileri geldikçe risk analizi güncellenecektir.");

        return Task.FromResult(
            new AiRiskAnaliziYaniti(
                "VELTRIS-LOCAL",
                risk.VeriVar ? "AKTİF" : "VERİ BEKLENİYOR",
                derece,
                risk.Aciklama,
                oneriler));
    }
}

public sealed class AiRiskAnalizServisi
{
    private readonly RiskMotoruServisi _riskMotoru;
    private readonly IAiRiskAnalizSaglayicisi _saglayici;

    public AiRiskAnalizServisi(
        RiskMotoruServisi riskMotoru,
        IAiRiskAnalizSaglayicisi saglayici)
    {
        _riskMotoru = riskMotoru;
        _saglayici = saglayici;
    }

    public async Task<AiRiskAnaliziYaniti> AnalizEtAsync(
        CancellationToken cancellationToken = default)
    {
        var risk = await _riskMotoru.HesaplaAsync(cancellationToken);
        return await _saglayici.AnalizEtAsync(risk, cancellationToken);
    }
}
