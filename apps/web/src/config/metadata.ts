/*
 * VELTRIS — Global SEO ve Uygulama Metadata Yapısı
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

import type { Metadata, Viewport } from "next";

export const VELTRIS_METADATA: Metadata = {
  title: {
    default: "VELTRIS | Enterprise Security Intelligence",
    template: "%s | VELTRIS",
  },
  description:
    "Kurumsal siber güvenlik, tehdit istihbaratı, risk analizi ve yapay zekâ destekli güvenlik platformu.",
  applicationName: "VELTRIS",
  generator: "VELTRIS Security Intelligence Platform",
  keywords: [
    "VELTRIS",
    "cyber security",
    "security intelligence",
    "threat intelligence",
    "SIEM",
    "SOC",
    "risk management",
    "vulnerability management",
    "AI security",
  ],
  robots: {
    index: false,
    follow: false,
  },
};

export const VELTRIS_VIEWPORT: Viewport = {
  width: "device-width",
  initialScale: 1,
  viewportFit: "cover",
  colorScheme: "light",
};
