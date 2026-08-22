/*
 * VELTRIS — Uygulama Oturum Katmanı
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

"use client";

import { useEffect, useState } from "react";
import { VELTRISDashboard } from "@/components/dashboard/VELTRISDashboard";
import { VELTRISGiris } from "@/components/auth/VELTRISGiris";
import { VELTRISIlkKurulum } from "@/components/kurulum/VELTRISIlkKurulum";
import {
  veltrisBen,
  veltrisDashboard,
  veltrisKurulumDurumu,
  veltrisOturumuKapat,
  veltrisTokeniniAl,
  type BenCevabi,
  type DashboardOzetYaniti,
} from "@/lib/api/veltris-api";

export function VELTRISUygulamasi() {
  const [hazir, setHazir] = useState(false);
  const [kurulumGerekli, setKurulumGerekli] = useState(false);
  const [oturumVar, setOturumVar] = useState(false);
  const [kullanici, setKullanici] = useState<BenCevabi | null>(null);
  const [dashboard, setDashboard] = useState<DashboardOzetYaniti | null>(null);

  async function oturumuYukle() {
    const [ben, ozet] = await Promise.all([
      veltrisBen(),
      veltrisDashboard(),
    ]);

    setKullanici(ben);
    setDashboard(ozet);
    setOturumVar(true);
  }

  useEffect(() => {
    Promise.all([
      veltrisKurulumDurumu(),
      Promise.resolve(veltrisTokeniniAl()),
    ])
      .then(async ([durum, token]) => {
        if (durum.kurulumGerekli) {
          setKurulumGerekli(true);
          return;
        }

        if (!token) {
          return;
        }

        try {
          await oturumuYukle();
        } catch {
          veltrisOturumuKapat();
          setOturumVar(false);
        }
      })
      .finally(() => {
        setHazir(true);
      });
  }, []);

  if (!hazir) {
    return (
      <main className="flex min-h-screen items-center justify-center bg-[#f6f8fb]">
        <div className="rounded-2xl border border-slate-200 bg-white px-6 py-5 text-sm font-bold text-slate-600 shadow-sm">
          VELTRIS başlatılıyor...
        </div>
      </main>
    );
  }

  if (kurulumGerekli) {
    return (
      <VELTRISIlkKurulum
        onBasarili={() => {
          setKurulumGerekli(false);
          void oturumuYukle();
        }}
      />
    );
  }

  if (!oturumVar) {
    return (
      <VELTRISGiris
        onBasarili={() => {
          void oturumuYukle();
        }}
      />
    );
  }

  return (
    <VELTRISDashboard
      veri={dashboard}
      kullaniciEposta={kullanici?.eposta ?? null}
      onCikis={() => {
        veltrisOturumuKapat();
        setKullanici(null);
        setDashboard(null);
        setOturumVar(false);
      }}
    />
  );
}
