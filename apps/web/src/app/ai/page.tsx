/*
 * VELTRIS — AI Security Analyst Ekranı
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

"use client";

import { useEffect, useState } from "react";
import { ArrowLeft, Bot, RefreshCw } from "lucide-react";
import { veltrisGet } from "@/lib/api/veltris-api";

type AiYaniti = {
  saglayici: string;
  durum: string;
  derece: string;
  ozet: string;
  oneriler: string[];
};

export default function Page() {
  const [veri, setVeri] = useState<AiYaniti | null>(null);

  async function yukle() {
    setVeri(
      await veltrisGet<AiYaniti>(
        "/ai/risk-analizi",
      ),
    );
  }

  useEffect(() => {
    void yukle();
  }, []);

  return (
    <main className="min-h-screen bg-[#f6f8fb] p-6">
      <div className="mx-auto max-w-5xl">
        <a href="/" className="inline-flex items-center gap-2 text-xs font-bold text-slate-500 hover:text-slate-950">
          <ArrowLeft size={14} />
          Dashboard
        </a>

        <div className="mt-6 flex items-center justify-between">
          <div className="flex items-center gap-3">
            <div className="flex h-12 w-12 items-center justify-center rounded-2xl bg-slate-950 text-white">
              <Bot size={23} />
            </div>

            <div>
              <h1 className="text-2xl font-black">
                VELTRIS AI
              </h1>
              <p className="text-sm text-slate-500">
                Risk motoru çıktılarının AI analiz katmanı.
              </p>
            </div>
          </div>

          <button
            onClick={() => void yukle()}
            className="rounded-xl border border-slate-200 bg-white p-3"
          >
            <RefreshCw size={16} />
          </button>
        </div>

        <div className="mt-8 grid gap-4 md:grid-cols-3">
          <div className="rounded-2xl border border-slate-200 bg-white p-6">
            <p className="text-xs font-bold text-slate-500">
              Sağlayıcı
            </p>
            <p className="mt-2 text-lg font-black">
              {veri?.saglayici ?? "—"}
            </p>
          </div>

          <div className="rounded-2xl border border-slate-200 bg-white p-6">
            <p className="text-xs font-bold text-slate-500">
              Durum
            </p>
            <p className="mt-2 text-lg font-black">
              {veri?.durum ?? "—"}
            </p>
          </div>

          <div className="rounded-2xl border border-slate-200 bg-white p-6">
            <p className="text-xs font-bold text-slate-500">
              Risk Derecesi
            </p>
            <p className="mt-2 text-lg font-black">
              {veri?.derece ?? "—"}
            </p>
          </div>
        </div>

        <section className="mt-6 rounded-2xl border border-slate-200 bg-white p-6">
          <h2 className="text-sm font-black">
            AI Analizi
          </h2>

          <p className="mt-4 rounded-xl bg-slate-50 p-4 text-sm leading-6 text-slate-600">
            {veri?.ozet ?? "Analiz yükleniyor..."}
          </p>

          <h2 className="mt-7 text-sm font-black">
            Öneriler
          </h2>

          <div className="mt-4 space-y-3">
            {(veri?.oneriler ?? []).map(
              (oner) => (
                <div
                  key={oner}
                  className="rounded-xl border border-slate-100 p-4 text-sm font-semibold text-slate-700"
                >
                  {oner}
                </div>
              ),
            )}
          </div>
        </section>
      </div>
    </main>
  );
}
