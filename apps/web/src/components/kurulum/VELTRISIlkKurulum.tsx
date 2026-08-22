/*
 * VELTRIS — İlk Kurulum Ekranı
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
import { VELTRISApiHatasi, veltrisIlkYoneticiOlustur } from "@/lib/api/veltris-api";

type Props = {
  onBasarili: () => void;
};

export function VELTRISIlkKurulum({
  onBasarili,
}: Props) {
  const [ad, setAd] = useState("");
  const [soyad, setSoyad] = useState("");
  const [eposta, setEposta] = useState("");
  const [sifre, setSifre] = useState("");
  const [sifreTekrar, setSifreTekrar] = useState("");
  const [hata, setHata] = useState("");
  const [yukleniyor, setYukleniyor] = useState(false);

  async function gonder(
    olay: FormEvent<HTMLFormElement>,
  ) {
    olay.preventDefault();
    setHata("");

    if (sifre.length < 12) {
      setHata("Şifre en az 12 karakter olmalıdır.");
      return;
    }

    if (sifre !== sifreTekrar) {
      setHata("Şifreler aynı değil.");
      return;
    }

    setYukleniyor(true);

    try {
      await veltrisIlkYoneticiOlustur(
        ad,
        soyad,
        eposta,
        sifre,
      );

      onBasarili();
    } catch (error) {
      setHata(
        error instanceof VELTRISApiHatasi
          ? error.message
          : "İlk kurulum tamamlanamadı.",
      );
    } finally {
      setYukleniyor(false);
    }
  }

  return (
    <main className="flex min-h-screen items-center justify-center bg-[#f6f8fb] px-5">
      <section className="w-full max-w-lg rounded-3xl border border-slate-200 bg-white p-8 shadow-[0_20px_60px_rgba(15,23,42,0.08)]">
        <div className="flex items-center gap-3">
          <div className="flex h-12 w-12 items-center justify-center rounded-2xl bg-slate-950 text-white">
            <ShieldCheck size={24} />
          </div>

          <div>
            <div className="text-xl font-black tracking-[0.12em]">
              VELTRIS
            </div>
            <div className="text-[10px] font-bold uppercase tracking-[0.18em] text-slate-400">
              İlk Kurulum
            </div>
          </div>
        </div>

        <div className="mt-8">
          <h1 className="text-2xl font-black">
            Yönetici hesabını oluştur
          </h1>

          <p className="mt-2 text-sm leading-6 text-slate-500">
            Bu VELTRIS kurulumunda kullanılacak gerçek yönetici hesabını
            oluşturun. Herhangi bir demo hesap kullanılmaz.
          </p>
        </div>

        <form
          onSubmit={gonder}
          className="mt-7 space-y-4"
        >
          <div className="grid gap-4 sm:grid-cols-2">
            <label>
              <span className="mb-2 block text-xs font-bold text-slate-700">
                Ad
              </span>
              <input
                required
                value={ad}
                onChange={(e) => setAd(e.target.value)}
                className="w-full rounded-xl border border-slate-200 px-4 py-3 text-sm outline-none focus:border-slate-400 focus:ring-4 focus:ring-slate-100"
              />
            </label>

            <label>
              <span className="mb-2 block text-xs font-bold text-slate-700">
                Soyad
              </span>
              <input
                required
                value={soyad}
                onChange={(e) => setSoyad(e.target.value)}
                className="w-full rounded-xl border border-slate-200 px-4 py-3 text-sm outline-none focus:border-slate-400 focus:ring-4 focus:ring-slate-100"
              />
            </label>
          </div>

          <label className="block">
            <span className="mb-2 block text-xs font-bold text-slate-700">
              E-posta
            </span>
            <input
              type="email"
              required
              value={eposta}
              onChange={(e) => setEposta(e.target.value)}
              placeholder="gercek@eposta.com"
              className="w-full rounded-xl border border-slate-200 px-4 py-3 text-sm outline-none focus:border-slate-400 focus:ring-4 focus:ring-slate-100"
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
                minLength={12}
                value={sifre}
                onChange={(e) => setSifre(e.target.value)}
                className="w-full rounded-xl border border-slate-200 py-3 pl-11 pr-4 text-sm outline-none focus:border-slate-400 focus:ring-4 focus:ring-slate-100"
              />
            </div>
          </label>

          <label className="block">
            <span className="mb-2 block text-xs font-bold text-slate-700">
              Şifre tekrar
            </span>
            <input
              type="password"
              required
              minLength={12}
              value={sifreTekrar}
              onChange={(e) => setSifreTekrar(e.target.value)}
              className="w-full rounded-xl border border-slate-200 px-4 py-3 text-sm outline-none focus:border-slate-400 focus:ring-4 focus:ring-slate-100"
            />
          </label>

          {hata && (
            <div className="flex items-start gap-2 rounded-xl border border-red-200 bg-red-50 p-3 text-xs font-semibold text-red-700">
              <AlertCircle size={16} className="mt-0.5 shrink-0" />
              <span>{hata}</span>
            </div>
          )}

          <button
            type="submit"
            disabled={yukleniyor}
            className="flex w-full items-center justify-center gap-2 rounded-xl bg-slate-950 px-4 py-3 text-sm font-bold text-white transition hover:bg-slate-800 disabled:cursor-not-allowed disabled:opacity-60"
          >
            {yukleniyor
              ? "Kurulum yapılıyor..."
              : "Kurulumu tamamla"}

            {!yukleniyor && <ArrowRight size={16} />}
          </button>
        </form>
      </section>
    </main>
  );
}
