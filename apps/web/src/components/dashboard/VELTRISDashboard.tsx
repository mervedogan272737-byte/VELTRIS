/*
 * VELTRIS — Enterprise Security Intelligence Dashboard
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

"use client";

import {
  Activity,
  AlertTriangle,
  ArrowUpRight,
  Bot,
  Bug,
  CheckCircle2,
  ChevronRight,
  CircleDot,
  Cpu,
  Database,
  FileWarning,
  Gauge,
  Globe2,
  KeyRound,
  LockKeyhole,
  Network,
  Radar,
  RefreshCw,
  Search,
  Server,
  ShieldAlert,
  ShieldCheck,
  Siren,
  Sparkles,
  Terminal,
  Users,
  Zap,
  type LucideIcon,
} from "lucide-react";

type Tehdit = {
  baslik: string;
  kaynak: string;
  seviye: "KRİTİK" | "YÜKSEK" | "ORTA";
  zaman: string;
  ikon: LucideIcon;
};

type NavigasyonOgeleri = {
  ikon: LucideIcon;
  etiket: string;
  aktif: boolean;
};

type YonetimOgeleri = {
  ikon: LucideIcon;
  etiket: string;
};

type OzetKarti = {
  ikon: LucideIcon;
  baslik: string;
  deger: string;
  ek: string;
  bilgi: string;
};

type SistemKarti = {
  ikon: LucideIcon;
  baslik: string;
  durum: string;
  deger: string;
};

type Aktivite = {
  baslik: string;
  kaynak: string;
  zaman: string;
};

const tehditler: Tehdit[] = [
  {
    baslik: "Kimlik doğrulama anomalisi",
    kaynak: "Identity Engine",
    seviye: "KRİTİK",
    zaman: "2 dk önce",
    ikon: KeyRound,
  },
  {
    baslik: "Şüpheli PowerShell aktivitesi",
    kaynak: "Endpoint Security",
    seviye: "YÜKSEK",
    zaman: "7 dk önce",
    ikon: Terminal,
  },
  {
    baslik: "Anormal API trafiği",
    kaynak: "API Gateway",
    seviye: "YÜKSEK",
    zaman: "12 dk önce",
    ikon: Network,
  },
  {
    baslik: "Yeni dış IP bağlantısı",
    kaynak: "Network Sensor",
    seviye: "ORTA",
    zaman: "18 dk önce",
    ikon: Globe2,
  },
];

const aktiviteler: Aktivite[] = [
  {
    baslik: "Admin hesabı MFA doğrulaması",
    kaynak: "Kimlik",
    zaman: "1 dk önce",
  },
  {
    baslik: "Firewall policy güncellendi",
    kaynak: "Ağ",
    zaman: "4 dk önce",
  },
  {
    baslik: "Endpoint taraması tamamlandı",
    kaynak: "Endpoint",
    zaman: "8 dk önce",
  },
  {
    baslik: "Yeni güvenlik raporu oluşturuldu",
    kaynak: "Rapor",
    zaman: "11 dk önce",
  },
  {
    baslik: "AI risk analizi tamamlandı",
    kaynak: "VELTRIS AI",
    zaman: "15 dk önce",
  },
];

const navigasyonOgeleri: NavigasyonOgeleri[] = [
  { ikon: Gauge, etiket: "Dashboard", aktif: true },
  { ikon: ShieldAlert, etiket: "Güvenlik Merkezi", aktif: false },
  { ikon: Radar, etiket: "Tehdit İstihbaratı", aktif: false },
  { ikon: Siren, etiket: "Olaylar", aktif: false },
  { ikon: Bug, etiket: "Zafiyetler", aktif: false },
  { ikon: Server, etiket: "Varlıklar", aktif: false },
  { ikon: Bot, etiket: "VELTRIS AI", aktif: false },
  { ikon: FileWarning, etiket: "Raporlar", aktif: false },
  { ikon: Network, etiket: "Entegrasyonlar", aktif: false },
];

const yonetimOgeleri: YonetimOgeleri[] = [
  { ikon: Users, etiket: "Kullanıcılar" },
  { ikon: LockKeyhole, etiket: "Erişim Kontrolü" },
  { ikon: Database, etiket: "Veri Kaynakları" },
];

const ozetKartlari: OzetKarti[] = [
  {
    ikon: ShieldCheck,
    baslik: "Güvenlik Skoru",
    deger: "94",
    ek: "/100",
    bilgi: "+4.8% bu hafta",
  },
  {
    ikon: ShieldAlert,
    baslik: "Aktif Tehditler",
    deger: "12",
    ek: "",
    bilgi: "3 kritik tehdit",
  },
  {
    ikon: Siren,
    baslik: "Açık Olaylar",
    deger: "7",
    ek: "",
    bilgi: "2 yüksek öncelik",
  },
  {
    ikon: Bug,
    baslik: "Zafiyetler",
    deger: "38",
    ek: "",
    bilgi: "5 kritik CVSS",
  },
];

const sistemKartlari: SistemKarti[] = [
  {
    ikon: Cpu,
    baslik: "AI Motoru",
    durum: "Çalışıyor",
    deger: "98.7%",
  },
  {
    ikon: Database,
    baslik: "Veri İşleme",
    durum: "Sağlıklı",
    deger: "99.9%",
  },
  {
    ikon: Network,
    baslik: "Sensör Ağı",
    durum: "Bağlı",
    deger: "24/24",
  },
];

const aktiviteGrafikDegerleri: number[] = [
  32, 44, 37, 62, 55, 72, 48, 82, 67, 76, 91, 64,
  78, 88, 70, 95, 81, 74, 92, 86, 98, 83, 89, 94,
];

function navigasyonAdresi(etiket: string): string {
  switch (etiket) {
    case "Dashboard":
      return "/";
    case "Güvenlik Merkezi":
      return "/risk";
    case "Tehdit İstihbaratı":
      return "/tehditler";
    case "Olaylar":
      return "/olaylar";
    case "Zafiyetler":
      return "/zafiyetler";
    case "Varlıklar":
      return "/varliklar";
    case "VELTRIS AI":
      return "/ai";
    default:
      return "#";
  }
}
function durumRengi(seviye: string): string {
  if (seviye === "KRİTİK") {
    return "text-red-600 bg-red-50 border-red-200";
  }

  if (seviye === "YÜKSEK") {
    return "text-orange-600 bg-orange-50 border-orange-200";
  }

  return "text-amber-600 bg-amber-50 border-amber-200";
}

function Kart({
  children,
  className = "",
}: {
  children: React.ReactNode;
  className?: string;
}) {
  return (
    <section
      className={`rounded-2xl border border-slate-200 bg-white shadow-[0_8px_30px_rgba(15,23,42,0.05)] ${className}`}
    >
      {children}
    </section>
  );
}

function Baslik({
  ikon: Ikon,
  baslik,
  aciklama,
}: {
  ikon: LucideIcon;
  baslik: string;
  aciklama: string;
}) {
  return (
    <div className="mb-5 flex items-center justify-between">
      <div className="flex items-center gap-3">
        <div className="flex h-10 w-10 items-center justify-center rounded-xl bg-slate-100 text-slate-700">
          <Ikon size={19} />
        </div>

        <div>
          <h2 className="text-sm font-bold text-slate-950">{baslik}</h2>
          <p className="mt-0.5 text-xs text-slate-500">{aciklama}</p>
        </div>
      </div>

      <button
        type="button"
        className="flex items-center gap-1 text-xs font-semibold text-slate-500 transition hover:text-slate-950"
      >
        Tümünü gör
        <ChevronRight size={14} />
      </button>
    </div>
  );
}

type DashboardProps = {
  veri: import("@/lib/api/veltris-api").DashboardOzetYaniti | null;
  kullaniciEposta: string | null;
  onCikis: () => void;
};

export function VELTRISDashboard({
  veri,
  kullaniciEposta,
  onCikis,
}: DashboardProps) {

  const ozetKartlariGercek = [
    {
      ikon: ShieldCheck,
      baslik: "Güvenlik Skoru",
      deger: String(veri?.guvenlikSkoru ?? 0),
      ek: "/100",
      bilgi: veri ? "API verisi" : "Veri bekleniyor",
    },
    {
      ikon: ShieldAlert,
      baslik: "Aktif Tehditler",
      deger: String(veri?.aktifTehditSayisi ?? 0),
      ek: "",
      bilgi: `${veri?.kritikTehditSayisi ?? 0} kritik tehdit`,
    },
    {
      ikon: Siren,
      baslik: "Açık Olaylar",
      deger: String(veri?.acikOlaySayisi ?? 0),
      ek: "",
      bilgi: `${veri?.yuksekOncelikliOlaySayisi ?? 0} yüksek öncelik`,
    },
    {
      ikon: Bug,
      baslik: "Zafiyetler",
      deger: String(veri?.zafiyetSayisi ?? 0),
      ek: "",
      bilgi: `${veri?.kritikZafiyetSayisi ?? 0} kritik CVSS`,
    },
  ];

  const sistemKartlariGercek = [
    {
      ikon: Cpu,
      baslik: "AI Motoru",
      durum: veri?.aiMotoru.durum ?? "Bekliyor",
      deger: veri?.aiMotoru.deger ?? "—",
    },
    {
      ikon: Database,
      baslik: "Veri İşleme",
      durum: veri?.veriIsleme.durum ?? "Bekliyor",
      deger: veri?.veriIsleme.deger ?? "—",
    },
    {
      ikon: Network,
      baslik: "Sensör Ağı",
      durum: veri?.sensorAgi.durum ?? "Bekliyor",
      deger: veri?.sensorAgi.deger ?? "—",
    },
  ];

  const tehditlerGercek =
    veri?.aktifTehditler ?? [];

  const aktivitelerGercek =
    veri?.aktiviteler ?? [];
  return (
    <div className="min-h-screen bg-[#f6f8fb] text-slate-950">
      <div className="flex min-h-screen">
        <aside className="hidden w-[260px] shrink-0 border-r border-slate-200 bg-white lg:flex lg:flex-col">
          <div className="flex h-[76px] items-center border-b border-slate-200 px-6">
            <div className="flex items-center gap-3">
              <div className="flex h-10 w-10 items-center justify-center rounded-xl bg-slate-950 text-white shadow-lg">
                <ShieldCheck size={21} />
              </div>

              <div>
                <div className="text-[17px] font-black tracking-[0.12em]">
                  VELTRIS
                </div>

                <div className="text-[9px] font-semibold uppercase tracking-[0.18em] text-slate-400">
                  Security Intelligence
                </div>
              </div>
            </div>
          </div>

          <div className="flex-1 px-3 py-5">
            <p className="px-3 pb-3 text-[10px] font-bold uppercase tracking-[0.18em] text-slate-400">
              Platform
            </p>

            <nav className="space-y-1">
              {navigasyonOgeleri.map((oge) => {
                const Icon = oge.ikon;

                return (
                  <button
                    type="button"
                    key={oge.etiket}
                    className={`flex w-full items-center gap-3 rounded-xl px-3 py-2.5 text-left text-[13px] font-semibold transition ${
                      oge.aktif
                        ? "bg-slate-950 text-white shadow-md"
                        : "text-slate-600 hover:bg-slate-100 hover:text-slate-950"
                    }`}
                  >
                    <Icon size={17} />
                    {oge.etiket}
                  </button>
                );
              })}
            </nav>

            <p className="mt-8 px-3 pb-3 text-[10px] font-bold uppercase tracking-[0.18em] text-slate-400">
              Yönetim
            </p>

            <nav className="space-y-1">
              {yonetimOgeleri.map((oge) => {
                const Icon = oge.ikon;

                return (
                  <button
                    type="button"
                    key={oge.etiket}
                    className="flex w-full items-center gap-3 rounded-xl px-3 py-2.5 text-left text-[13px] font-semibold text-slate-600 transition hover:bg-slate-100 hover:text-slate-950"
                  >
                    <Icon size={17} />
                    {oge.etiket}
                  </button>
                );
              })}
            </nav>
          </div>

          <div className="border-t border-slate-200 p-4">
            <div className="rounded-xl bg-slate-50 p-3">
              <div className="flex items-center gap-2">
                <span className="h-2 w-2 rounded-full bg-emerald-500" />
                <span className="text-xs font-bold text-slate-700">
                  Sistemler aktif
                </span>
              </div>

              <p className="mt-1 text-[11px] text-slate-500">
                Tüm güvenlik motorları çalışıyor.
              </p>
            </div>
          </div>
        </aside>

        <main className="min-w-0 flex-1">
          <header className="sticky top-0 z-20 flex h-[76px] items-center justify-between border-b border-slate-200 bg-white/95 px-5 backdrop-blur-xl lg:px-8">
            <div>
              <p className="text-[11px] font-bold uppercase tracking-[0.16em] text-slate-400">
                Security Operations Center
              </p>

              <h1 className="mt-1 text-lg font-black tracking-tight text-slate-950">
                Güvenlik Genel Bakışı
              </h1>
            </div>

            <div className="flex items-center gap-3">
              <button
                type="button"
                className="hidden items-center gap-2 rounded-xl border border-slate-200 bg-white px-3 py-2 text-xs font-semibold text-slate-600 shadow-sm transition hover:border-slate-300 md:flex"
              >
                <RefreshCw size={14} />
                Son güncelleme: şimdi
              </button>

              <button
                type="button"
                aria-label="Arama"
                className="flex h-10 w-10 items-center justify-center rounded-xl border border-slate-200 bg-white text-slate-600 shadow-sm transition hover:bg-slate-50"
              >
                <Search size={17} />
              </button>

              <div
                aria-label="Kullanıcı profili"
                className="flex h-10 w-10 items-center justify-center rounded-xl bg-slate-950 text-sm font-black text-white cursor-pointer"
              >
                V
              </div>
            </div>
          </header>

          <div className="mx-auto max-w-[1700px] space-y-6 p-5 lg:p-8">
            <div className="grid gap-4 sm:grid-cols-2 xl:grid-cols-4">
              {ozetKartlariGercek.map((kart) => {
                const Icon = kart.ikon;

                return (
                  <Kart key={kart.baslik} className="p-5">
                    <div className="flex items-start justify-between">
                      <div className="flex h-10 w-10 items-center justify-center rounded-xl bg-slate-100 text-slate-700">
                        <Icon size={19} />
                      </div>

                      <ArrowUpRight
                        size={16}
                        className="text-emerald-500"
                      />
                    </div>

                    <p className="mt-5 text-xs font-semibold text-slate-500">
                      {kart.baslik}
                    </p>

                    <div className="mt-1 flex items-baseline gap-1">
                      <span className="text-3xl font-black tracking-tight">
                        {kart.deger}
                      </span>

                      <span className="text-xs font-semibold text-slate-400">
                        {kart.ek}
                      </span>
                    </div>

                    <p className="mt-2 text-[11px] font-semibold text-slate-500">
                      {kart.bilgi}
                    </p>
                  </Kart>
                );
              })}
            </div>

            <div className="grid gap-6 xl:grid-cols-[1.55fr_1fr]">
              <Kart className="overflow-hidden">
                <div className="p-6">
                  <Baslik
                    ikon={Activity}
                    baslik="Güvenlik Aktivitesi"
                    aciklama="Son 24 saatteki olay ve tehdit yoğunluğu"
                  />

                  <div className="relative flex h-[250px] items-end gap-2 overflow-hidden rounded-xl border border-slate-100 bg-slate-50 px-4 pb-4 pt-8">
                    <div className="absolute inset-x-0 top-1/4 border-t border-dashed border-slate-200" />
                    <div className="absolute inset-x-0 top-2/4 border-t border-dashed border-slate-200" />
                    <div className="absolute inset-x-0 top-3/4 border-t border-dashed border-slate-200" />

                    {aktiviteGrafikDegerleri.map((deger, index) => (
                      <div
                        key={`grafik-${index}`}
                        className="group relative flex h-full flex-1 items-end"
                      >
                        <div
                          className="w-full rounded-t-md bg-slate-900 transition-all group-hover:bg-slate-700"
                          style={{ height: `${deger}%` }}
                        />
                      </div>
                    ))}
                  </div>

                  <div className="mt-4 flex justify-between text-[10px] font-semibold text-slate-400">
                    <span>00:00</span>
                    <span>06:00</span>
                    <span>12:00</span>
                    <span>18:00</span>
                    <span>Şimdi</span>
                  </div>
                </div>
              </Kart>

              <Kart className="p-6">
                <Baslik
                  ikon={Sparkles}
                  baslik="VELTRIS AI Risk Analizi"
                  aciklama="Yapay zekâ destekli güvenlik değerlendirmesi"
                />

                <div className="flex items-center gap-6">
                  <div className="relative flex h-32 w-32 shrink-0 items-center justify-center rounded-full border-[10px] border-slate-100">
                    <div className="absolute inset-0 rounded-full border-[10px] border-slate-900 border-b-transparent border-l-transparent" />

                    <div className="text-center">
                      <div className="text-3xl font-black">A+</div>

                      <div className="text-[9px] font-bold uppercase tracking-wider text-slate-400">
                        Risk Rating
                      </div>
                    </div>
                  </div>

                  <div className="space-y-3">
                    <div>
                      <p className="text-xs font-bold text-slate-700">
                        Genel risk seviyesi
                      </p>

                      <p className="mt-1 text-[11px] leading-5 text-slate-500">
                        Ortamınızın mevcut güvenlik durumu kontrollü seviyede.
                      </p>
                    </div>

                    <div className="flex items-center gap-2 text-xs font-bold text-emerald-600">
                      <CheckCircle2 size={15} />
                      Kritik risk bulunamadı
                    </div>
                  </div>
                </div>

                <div className="mt-6 rounded-xl bg-slate-950 p-4 text-white">
                  <div className="flex items-center gap-2">
                    <Bot size={16} />
                    <span className="text-xs font-bold">
                      AI Security Analyst
                    </span>
                  </div>

                  <p className="mt-2 text-[11px] leading-5 text-slate-300">
                    12 aktif tehdidin 3&apos;ü öncelikli inceleme gerektiriyor.
                    Kimlik doğrulama anomalisi en yüksek riskli olay olarak
                    değerlendirildi.
                  </p>
                </div>
              </Kart>
            </div>

            <div className="grid gap-6 xl:grid-cols-[1.2fr_0.8fr]">
              <Kart className="p-6">
                <Baslik
                  ikon={Radar}
                  baslik="Aktif Tehditler"
                  aciklama="Tehdit istihbaratı ve güvenlik sensörlerinden gelen olaylar"
                />

                <div className="space-y-2">
                  {tehditlerGercek.map((tehdit) => {
                    const Icon = Radar;

                    return (
                      <div
                        key={tehdit.baslik}
                        className="flex items-center gap-4 rounded-xl border border-slate-100 p-3.5 transition hover:border-slate-200 hover:bg-slate-50"
                      >
                        <div className="flex h-10 w-10 shrink-0 items-center justify-center rounded-xl bg-slate-100 text-slate-700">
                          <Icon size={17} />
                        </div>

                        <div className="min-w-0 flex-1">
                          <p className="truncate text-xs font-bold text-slate-800">
                            {tehdit.baslik}
                          </p>

                          <p className="mt-1 text-[10px] font-medium text-slate-400">
                            {tehdit.kaynak} · {tehdit.zaman}
                          </p>
                        </div>

                        <span
                          className={`rounded-lg border px-2 py-1 text-[9px] font-black tracking-wide ${durumRengi(
                            tehdit.seviye,
                          )}`}
                        >
                          {tehdit.seviye}
                        </span>

                        <ChevronRight
                          size={15}
                          className="hidden text-slate-300 sm:block"
                        />
                      </div>
                    );
                  })}
                </div>
              </Kart>

              <Kart className="p-6">
                <Baslik
                  ikon={Zap}
                  baslik="Canlı Aktivite"
                  aciklama="Platform üzerindeki son işlemler"
                />

                <div className="space-y-5">
                  {aktivitelerGercek.map((aktivite) => (
                    <div key={aktivite.baslik} className="flex gap-3">
                      <div className="relative flex w-5 justify-center">
                        <CircleDot
                          size={11}
                          className="mt-1.5 text-slate-400"
                        />
                      </div>

                      <div className="min-w-0 flex-1">
                        <p className="text-xs font-bold text-slate-700">
                          {aktivite.baslik}
                        </p>

                        <div className="mt-1 flex gap-2 text-[10px] font-medium text-slate-400">
                          <span>{aktivite.kaynak}</span>
                          <span>•</span>
                          <span>{aktivite.zaman}</span>
                        </div>
                      </div>
                    </div>
                  ))}
                </div>
              </Kart>
            </div>

            <div className="grid gap-4 md:grid-cols-3">
              {sistemKartlariGercek.map((sistem) => {
                const Icon = sistem.ikon;

                return (
                  <Kart key={sistem.baslik} className="p-5">
                    <div className="flex items-center justify-between">
                      <div className="flex items-center gap-3">
                        <div className="flex h-9 w-9 items-center justify-center rounded-lg bg-slate-100 text-slate-700">
                          <Icon size={17} />
                        </div>

                        <div>
                          <p className="text-xs font-bold">
                            {sistem.baslik}
                          </p>

                          <p className="mt-0.5 text-[10px] text-emerald-600">
                            ● {sistem.durum}
                          </p>
                        </div>
                      </div>

                      <span className="text-xs font-black text-slate-700">
                        {sistem.deger}
                      </span>
                    </div>
                  </Kart>
                );
              })}
            </div>
          </div>
        </main>
      </div>
    </div>
  );
}



