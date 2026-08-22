/*
 * VELTRIS — Bulunamayan Sayfa
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

import Link from "next/link";
import { ArrowLeft, ShieldQuestion } from "lucide-react";

export default function NotFound() {
  return (
    <main className="flex min-h-screen items-center justify-center bg-[#f6f8fb] p-6">
      <section className="w-full max-w-lg rounded-2xl border border-slate-200 bg-white p-10 text-center shadow-[0_12px_40px_rgba(15,23,42,0.08)]">
        <div className="mx-auto flex h-16 w-16 items-center justify-center rounded-2xl bg-slate-100 text-slate-700">
          <ShieldQuestion size={30} />
        </div>

        <p className="mt-6 text-6xl font-black tracking-tight text-slate-950">
          404
        </p>

        <h1 className="mt-3 text-xl font-black text-slate-950">
          Sayfa bulunamadı
        </h1>

        <p className="mx-auto mt-3 max-w-md text-sm leading-6 text-slate-500">
          Aradığınız VELTRIS kaynağı mevcut değil veya
          erişim yolu değişmiş olabilir.
        </p>

        <Link
          href="/"
          className="mx-auto mt-7 flex w-fit items-center gap-2 rounded-xl bg-slate-950 px-4 py-2.5 text-xs font-bold text-white transition hover:bg-slate-800"
        >
          <ArrowLeft size={14} />
          Dashboard'a dön
        </Link>
      </section>
    </main>
  );
}
