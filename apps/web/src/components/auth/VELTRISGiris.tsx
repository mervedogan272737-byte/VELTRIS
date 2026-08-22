/*
 * VELTRIS — Giriş Ekranı
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

"use client";

import { FormEvent, useState } from "react";
import {
  AlertCircle,
  ArrowRight,
  LockKeyhole,
  ShieldCheck,
} from "lucide-react";
import {
  VELTRISApiHatasi,
  veltrisGiris,
} from "@/lib/api/veltris-api";

type Props = {
  onBasarili: () => void;
};

export function VELTRISGiris({
  onBasarili,
}: Props) {
  const [eposta, setEposta] = useState("");
  const [sifre, setSifre] = useState("");
  const [yukleniyor, setYukleniyor] = useState(false);
  const [hata, setHata] = useState("");

  async function gonder(
    olay: FormEvent<HTMLFormElement>,
  ) {
    olay.preventDefault();
    setHata("");
    setYukleniyor(true);

    try {
      await veltrisGiris(eposta, sifre);
      onBasarili();
    } catch (hata) {
      if (hata instanceof VELTRISApiHatasi) {
        setHata(hata.message);
      } else {
        setHata(
          "Giriş sırasında beklenmeyen bir hata oluştu.",
        );
      }
    } finally {
      setYukleniyor(false);
    }
  }

  return (
    <main className="flex min-h-screen items-center justify-center bg-[#f6f8fb] px-5">
      <section className="w-full max-w-md rounded-3xl border border-slate-200 bg-white p-8 shadow-[0_20px_60px_rgba(15,23,42,0.08)]">
        <div className="flex items-center gap-3">
          <div className="flex h-12 w-12 items-center justify-center rounded-2xl bg-slate-950 text-white">
            <ShieldCheck size={24} />
          </div>

          <div>
            <div className="text-xl font-black tracking-[0.12em]">
              VELTRIS
            </div>
            <div className="text-[10px] font-bold uppercase tracking-[0.18em] text-slate-400">
              Security Intelligence
            </div>
          </div>
        </div>

        <div className="mt-8">
          <h1 className="text-2xl font-black tracking-tight text-slate-950">
            Güvenli giriş
          </h1>
          <p className="mt-2 text-sm leading-6 text-slate-500">
            VELTRIS güvenlik platformuna erişmek için
            kimlik bilgilerinizi girin.
          </p>
        </div>

        <form
          onSubmit={gonder}
          className="mt-7 space-y-5"
        >
          <label className="block">
            <span className="mb-2 block text-xs font-bold text-slate-700">
              E-posta
            </span>

            <input
              type="email"
              required
              autoComplete="email"
              value={eposta}
              onChange={(olay) =>
                setEposta(olay.target.value)
              }
              className="w-full rounded-xl border border-slate-200 bg-white px-4 py-3 text-sm text-slate-900 outline-none transition focus:border-slate-400 focus:ring-4 focus:ring-slate-100"
              placeholder="ornek@gmail.com"
            />
          </label>

          <label className="block">
            <span className="mb-2 block text-xs font-bold text-slate-700">
              Şifre
            </span>

            <div className="relative">
              <LockKeyhole
                size={16}
                className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400"
              />

              <input
                type="password"
                required
                autoComplete="current-password"
                value={sifre}
                onChange={(olay) =>
                  setSifre(olay.target.value)
                }
                className="w-full rounded-xl border border-slate-200 bg-white py-3 pl-11 pr-4 text-sm text-slate-900 outline-none transition focus:border-slate-400 focus:ring-4 focus:ring-slate-100"
                placeholder="Şifreniz"
              />
            </div>
          </label>

          {hata && (
            <div className="flex items-start gap-2 rounded-xl border border-red-200 bg-red-50 p-3 text-xs font-semibold text-red-700">
              <AlertCircle
                size={16}
                className="mt-0.5 shrink-0"
              />
              <span>{hata}</span>
            </div>
          )}

          <button
            type="submit"
            disabled={yukleniyor}
            className="flex w-full items-center justify-center gap-2 rounded-xl bg-slate-950 px-4 py-3 text-sm font-bold text-white transition hover:bg-slate-800 disabled:cursor-not-allowed disabled:opacity-60"
          >
            {yukleniyor
              ? "Giriş yapılıyor..."
              : "Giriş yap"}

            {!yukleniyor && (
              <ArrowRight size={16} />
            )}
          </button>
        </form>
      </section>
    </main>
  );
}
