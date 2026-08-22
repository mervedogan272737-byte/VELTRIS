/*
 * VELTRIS — Dashboard DTO
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

namespace Veltris.Api.Application.Dashboard;

public sealed record DashboardOzetYaniti(
    int GuvenlikSkoru,
    int AktifTehditSayisi,
    int KritikTehditSayisi,
    int AcikOlaySayisi,
    int YuksekOncelikliOlaySayisi,
    int ZafiyetSayisi,
    int KritikZafiyetSayisi,
    SistemDurumuYaniti AiMotoru,
    SistemDurumuYaniti VeriIsleme,
    SistemDurumuYaniti SensorAgi,
    IReadOnlyList<DashboardTehditYaniti> AktifTehditler,
    IReadOnlyList<DashboardAktiviteYaniti> Aktiviteler,
    DashboardRiskYaniti RiskAnalizi
);

public sealed record SistemDurumuYaniti(
    string Durum,
    string Deger
);

public sealed record DashboardTehditYaniti(
    string Baslik,
    string Kaynak,
    string Seviye,
    string Zaman
);

public sealed record DashboardAktiviteYaniti(
    string Baslik,
    string Kaynak,
    string Zaman
);

public sealed record DashboardRiskYaniti(
    string Derece,
    string Seviye,
    string Aciklama,
    bool KritikRiskVar
);
