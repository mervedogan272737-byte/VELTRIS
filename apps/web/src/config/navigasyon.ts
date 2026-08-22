/*
 * VELTRIS — Uygulama Navigasyon Yapısı
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

export interface VELTRISNavigasyonOgelesi {
  kimlik: string;
  etiket: string;
  yol: string;
  ikon: string;
  grup: "PLATFORM" | "YONETIM";
}

export const VELTRIS_NAVIGASYON: readonly VELTRISNavigasyonOgelesi[] = [
  {
    kimlik: "dashboard",
    etiket: "Dashboard",
    yol: "/",
    ikon: "gauge",
    grup: "PLATFORM",
  },
  {
    kimlik: "guvenlik",
    etiket: "Güvenlik Merkezi",
    yol: "/guvenlik",
    ikon: "shield-alert",
    grup: "PLATFORM",
  },
  {
    kimlik: "tehditler",
    etiket: "Tehdit İstihbaratı",
    yol: "/tehditler",
    ikon: "radar",
    grup: "PLATFORM",
  },
  {
    kimlik: "olaylar",
    etiket: "Olaylar",
    yol: "/olaylar",
    ikon: "siren",
    grup: "PLATFORM",
  },
  {
    kimlik: "zafiyetler",
    etiket: "Zafiyetler",
    yol: "/zafiyetler",
    ikon: "bug",
    grup: "PLATFORM",
  },
  {
    kimlik: "varliklar",
    etiket: "Varlıklar",
    yol: "/varliklar",
    ikon: "server",
    grup: "PLATFORM",
  },
  {
    kimlik: "ai",
    etiket: "VELTRIS AI",
    yol: "/ai",
    ikon: "bot",
    grup: "PLATFORM",
  },
  {
    kimlik: "raporlar",
    etiket: "Raporlar",
    yol: "/raporlar",
    ikon: "file-warning",
    grup: "PLATFORM",
  },
  {
    kimlik: "entegrasyonlar",
    etiket: "Entegrasyonlar",
    yol: "/entegrasyonlar",
    ikon: "network",
    grup: "PLATFORM",
  },
  {
    kimlik: "kullanicilar",
    etiket: "Kullanıcılar",
    yol: "/kullanicilar",
    ikon: "users",
    grup: "YONETIM",
  },
  {
    kimlik: "erisim",
    etiket: "Erişim Kontrolü",
    yol: "/erisim",
    ikon: "lock",
    grup: "YONETIM",
  },
  {
    kimlik: "veri-kaynaklari",
    etiket: "Veri Kaynakları",
    yol: "/veri-kaynaklari",
    ikon: "database",
    grup: "YONETIM",
  },
] as const;
