/*
 * VELTRIS — Hata Sınırı
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

"use client";

import { useEffect } from "react";
import { AlertTriangle, RefreshCw } from "lucide-react";

interface VELTRISErrorProps {
  error: Error & { digest?: string };
  reset: () => void;
}

export default function Error({
  error,
  reset,
}: VELTRISErrorProps) {
  useEffect(() => {
    console.error("VELTRIS uygulama hatası:", error);
  }, [error]);

  return (
    <main className="flex min-h-screen items-center justify-center bg-[#f6f8fb] p-6">
      <section className="w-full max-w-md rounded-2xl border border-slate-200 bg-white p-8 text-center shadow-[0_12px_40px_rgba(15,23,42,0.08)]">
        <div className="mx-auto flex h-14 w-14 items-center justify-center rounded-2xl bg-red-50 text-red-600">
          <AlertTriangle size={25} />
        </div>

        <h1 className="mt-5 text-lg font-black text-slate-950">
          Beklenmeyen bir hata oluştu
        </h1>

        <p className="mt-2 text-sm leading-6 text-slate-500">
          VELTRIS bu ekranı yüklerken beklenmeyen bir
          uygulama hatasıyla karşılaştı.
        </p>

        <button
          type="button"
          onClick={reset}
          className="mx-auto mt-6 flex items-center gap-2 rounded-xl bg-slate-950 px-4 py-2.5 text-xs font-bold text-white transition hover:bg-slate-800"
        >
          <RefreshCw size={14} />
          Tekrar dene
        </button>
      </section>
    </main>
  );
}
