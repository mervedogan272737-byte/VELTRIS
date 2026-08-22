/*
 * VELTRIS — Platform Yapılandırması
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

export const VELTRIS_YAPILANDIRMASI = {
  uygulama: {
    ad: "VELTRIS",
    surum: "1.0.0",
    ortam:
      process.env.NODE_ENV === "production"
        ? "production"
        : "development",
  },

  api: {
    temelAdres:
      process.env.NEXT_PUBLIC_VELTRIS_API_URL ??
      "http://127.0.0.1:4000/api",
    zamanAsimiMs: 15000,
  },

  guvenlik: {
    varsayilanRiskSkoru: 0,
    maksimumRiskSkoru: 100,
    kritikEsik: 90,
    yuksekEsik: 70,
    ortaEsik: 40,
  },

  sayfalama: {
    varsayilanSayfaBoyutu: 25,
    maksimumSayfaBoyutu: 100,
  },
} as const;

