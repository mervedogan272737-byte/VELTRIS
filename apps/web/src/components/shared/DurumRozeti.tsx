/*
 * VELTRIS — Durum Rozeti
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

import type { RiskSeviyesi } from "@/types/security";
import { riskEtiketi } from "@/lib/security/risk";

interface DurumRozetiProps {
  seviye: RiskSeviyesi;
  className?: string;
}

const renkler: Record<RiskSeviyesi, string> = {
  KRITIK:
    "border-red-200 bg-red-50 text-red-700",
  YUKSEK:
    "border-orange-200 bg-orange-50 text-orange-700",
  ORTA:
    "border-amber-200 bg-amber-50 text-amber-700",
  DUSUK:
    "border-emerald-200 bg-emerald-50 text-emerald-700",
  BILINMIYOR:
    "border-slate-200 bg-slate-50 text-slate-600",
};

export function DurumRozeti({
  seviye,
  className = "",
}: DurumRozetiProps) {
  return (
    <span
      className={`inline-flex items-center rounded-lg border px-2.5 py-1 text-[10px] font-black uppercase tracking-wide ${renkler[seviye]} ${className}`}
    >
      {riskEtiketi(seviye)}
    </span>
  );
}
