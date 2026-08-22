/*
 * VELTRIS — Güvenlik Risk Hesaplama Motoru
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

import type { RiskSeviyesi } from "@/types/security";

export function riskSeviyesiniBelirle(
  skor: number,
): RiskSeviyesi {
  const guvenliSkor = Math.min(
    100,
    Math.max(0, skor),
  );

  if (guvenliSkor >= 90) {
    return "KRITIK";
  }

  if (guvenliSkor >= 70) {
    return "YUKSEK";
  }

  if (guvenliSkor >= 40) {
    return "ORTA";
  }

  if (guvenliSkor > 0) {
    return "DUSUK";
  }

  return "BILINMIYOR";
}

export function riskEtiketi(
  seviye: RiskSeviyesi,
): string {
  const etiketler: Record<RiskSeviyesi, string> = {
    KRITIK: "Kritik",
    YUKSEK: "Yüksek",
    ORTA: "Orta",
    DUSUK: "Düşük",
    BILINMIYOR: "Bilinmiyor",
  };

  return etiketler[seviye];
}

export function riskSkorunuNormalizeEt(
  skor: number,
): number {
  return Math.min(
    100,
    Math.max(0, Math.round(skor)),
  );
}
