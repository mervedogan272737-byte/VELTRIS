/*
 * VELTRIS — Risk Motoru Ekranı
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

"use client";

import { useEffect, useState } from "react";
import { ArrowLeft, ShieldAlert, RefreshCw } from "lucide-react";
import { veltrisGet } from "@/lib/api/veltris-api";

type Risk = {
  veriVar: boolean;
  riskSkoru: number;
  guvenlikSkoru: number;
  aktifTehditSayisi: number;
  kritikTehditSayisi: number;
  acikOlaySayisi: number;
  yuksekOncelikliOlaySayisi: number;
  zafiyetSayisi: number;
  kritikZafiyetSayisi: number;
  kritikVarlikSayisi: number;
  seviye: string;
  aciklama: string;
};

export default function Page() {
  const [veri, setVeri] = useState<Risk | null>(null);

  async function yukle() {
    setVeri(await veltrisGet<Risk>("/risk/ozet"));
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
          <div>
            <div className="flex items-center gap-3">
              <div className="flex h-12 w-12 items-center justify-center rounded-2xl bg-slate-950 text-white">
                <ShieldAlert size={23} />
              </div>
              <div>
                <h1 className="text-2xl font-black">Risk Motoru</h1>
                <p className="text-sm text-slate-500">
                  VELTRIS gerçek güvenlik verilerinden risk hesaplar.
                </p>
              </div>
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
            <p className="text-xs font-bold text-slate-500">Risk Skoru</p>
            <p className="mt-2 text-4xl font-black">{veri?.riskSkoru ?? 0}</p>
            <p className="mt-1 text-xs font-bold text-slate-400">/100</p>
          </div>

          <div className="rounded-2xl border border-slate-200 bg-white p-6">
            <p className="text-xs font-bold text-slate-500">Güvenlik Skoru</p>
            <p className="mt-2 text-4xl font-black">{veri?.guvenlikSkoru ?? 0}</p>
            <p className="mt-1 text-xs font-bold text-slate-400">/100</p>
          </div>

          <div className="rounded-2xl border border-slate-200 bg-white p-6">
            <p className="text-xs font-bold text-slate-500">Seviye</p>
            <p className="mt-2 text-2xl font-black">{veri?.seviye ?? "VERİ YOK"}</p>
          </div>
        </div>

        <div className="mt-6 rounded-2xl border border-slate-200 bg-white p-6">
          <h2 className="text-sm font-black">Risk bileşenleri</h2>

          <div className="mt-5 grid gap-3 md:grid-cols-2">
            <p className="text-sm text-slate-600">Aktif tehdit: <b>{veri?.aktifTehditSayisi ?? 0}</b></p>
            <p className="text-sm text-slate-600">Kritik tehdit: <b>{veri?.kritikTehditSayisi ?? 0}</b></p>
            <p className="text-sm text-slate-600">Açık olay: <b>{veri?.acikOlaySayisi ?? 0}</b></p>
            <p className="text-sm text-slate-600">Yüksek öncelikli olay: <b>{veri?.yuksekOncelikliOlaySayisi ?? 0}</b></p>
            <p className="text-sm text-slate-600">Zafiyet: <b>{veri?.zafiyetSayisi ?? 0}</b></p>
            <p className="text-sm text-slate-600">Kritik zafiyet: <b>{veri?.kritikZafiyetSayisi ?? 0}</b></p>
            <p className="text-sm text-slate-600">Kritik varlık: <b>{veri?.kritikVarlikSayisi ?? 0}</b></p>
          </div>

          <p className="mt-6 rounded-xl bg-slate-50 p-4 text-sm text-slate-600">
            {veri?.aciklama ?? "Risk verisi yükleniyor..."}
          </p>
        </div>
      </div>
    </main>
  );
}
