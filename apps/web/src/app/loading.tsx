/*
 * VELTRIS — Yükleme Ekranı
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

export default function Loading() {
  return (
    <main
      aria-label="VELTRIS yükleniyor"
      className="flex min-h-screen items-center justify-center bg-[#f6f8fb]"
    >
      <div className="flex flex-col items-center gap-4">
        <div className="flex h-12 w-12 animate-pulse items-center justify-center rounded-2xl bg-slate-950 text-white">
          <span className="text-sm font-black">V</span>
        </div>

        <div className="text-center">
          <p className="text-sm font-black tracking-[0.16em] text-slate-950">
            VELTRIS
          </p>
          <p className="mt-1 text-[10px] font-semibold uppercase tracking-[0.14em] text-slate-400">
            Security Intelligence
          </p>
        </div>
      </div>
    </main>
  );
}
