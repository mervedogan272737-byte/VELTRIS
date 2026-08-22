/*
 * VELTRIS — Sistem Sağlık Göstergesi
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

import type { SistemSagligi } from "@/types/security";

interface SistemSaglikGöstergesiProps {
  sistem: SistemSagligi;
}

const durumRenkleri: Record<
  SistemSagligi["durum"],
  string
> = {
  AKTIF: "bg-emerald-500",
  UYARI: "bg-amber-500",
  HATA: "bg-red-500",
};

const durumMetinleri: Record<
  SistemSagligi["durum"],
  string
> = {
  AKTIF: "Aktif",
  UYARI: "Uyarı",
  HATA: "Hata",
};

export function SistemSaglikGöstergesi({
  sistem,
}: SistemSaglikGöstergesiProps) {
  return (
    <div className="flex items-center gap-2">
      <span
        aria-hidden="true"
        className={`h-2 w-2 rounded-full ${durumRenkleri[sistem.durum]}`}
      />

      <span className="text-xs font-semibold text-slate-700">
        {sistem.ad}
      </span>

      <span className="text-[10px] font-medium text-slate-400">
        {durumMetinleri[sistem.durum]}
      </span>
    </div>
  );
}
