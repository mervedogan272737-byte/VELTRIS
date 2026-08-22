/*
 * VELTRIS — Güvenlik Modülü Arayüzü
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

"use client";

import { FormEvent, useEffect, useState } from "react";
import {
  AlertTriangle,
  ArrowLeft,
  Bot,
  Bug,
  CheckCircle2,
  Database,
  Plus,
  Radar,
  RefreshCw,
  Server,
  ShieldAlert,
  ShieldCheck,
  Trash2,
} from "lucide-react";
import {
  veltrisBen,
  veltrisGet,
  veltrisPost,
  veltrisIstek,
  type BenCevabi,
} from "@/lib/api/veltris-api";

type Modul =
  | "tehdit"
  | "olay"
  | "zafiyet"
  | "varlik";

type Kayit = Record<string, unknown>;

type Props = {
  modul: Modul;
};

const AYARLAR = {
  tehdit: {
    baslik: "Tehdit Yönetimi",
    aciklama: "Tehdit istihbaratı ve güvenlik tehditlerini yönetin.",
    endpoint: "/tehditler",
    ikon: Radar,
    alanlar: [
      ["baslik", "Başlık", "text"],
      ["aciklama", "Açıklama", "textarea"],
      ["kaynak", "Kaynak", "text"],
      ["seviye", "Seviye", "text"],
      ["durum", "Durum", "text"],
      ["riskSkoru", "Risk Skoru", "number"],
      ["gosterge", "Gösterge / IOC", "text"],
    ],
  },
  olay: {
    baslik: "Olay Yönetimi",
    aciklama: "Güvenlik olaylarını izleyin ve müdahale kayıtlarını yönetin.",
    endpoint: "/olaylar",
    ikon: AlertTriangle,
    alanlar: [
      ["baslik", "Başlık", "text"],
      ["aciklama", "Açıklama", "textarea"],
      ["oncelik", "Öncelik", "text"],
      ["durum", "Durum", "text"],
      ["riskSkoru", "Risk Skoru", "number"],
    ],
  },
  zafiyet: {
    baslik: "Zafiyet Yönetimi",
    aciklama: "CVSS ve zafiyet kayıtlarını merkezi olarak yönetin.",
    endpoint: "/zafiyetler",
    ikon: Bug,
    alanlar: [
      ["baslik", "Başlık", "text"],
      ["cveKodu", "CVE Kodu", "text"],
      ["cvssSkoru", "CVSS Skoru", "number"],
      ["seviye", "Seviye", "text"],
      ["durum", "Durum", "text"],
      ["etkilenenVarlikSayisi", "Etkilenen Varlık", "number"],
      ["cozumNotu", "Çözüm Notu", "textarea"],
    ],
  },
  varlik: {
    baslik: "Varlık Yönetimi",
    aciklama: "Kurumsal varlıkları ve kritik sistemleri yönetin.",
    endpoint: "/varliklar",
    ikon: Server,
    alanlar: [
      ["ad", "Varlık Adı", "text"],
      ["varlikTuru", "Varlık Türü", "text"],
      ["hostAdi", "Host Adı", "text"],
      ["ipAdresi", "IP Adresi", "text"],
      ["isletimSistemi", "İşletim Sistemi", "text"],
      ["kritiklik", "Kritiklik", "text"],
      ["durum", "Durum", "text"],
    ],
  },
} as const;

export function GuvenlikModuluSayfasi({ modul }: Props) {
  const ayar = AYARLAR[modul];
  const Icon = ayar.ikon;

  const [kayitlar, setKayitlar] = useState<Kayit[]>([]);
  const [kurumId, setKurumId] = useState<string | null>(null);
  const [form, setForm] = useState<Record<string, string>>({});
  const [acik, setAcik] = useState(false);
  const [yukleniyor, setYukleniyor] = useState(true);
  const [hata, setHata] = useState("");

  async function yukle() {
    setYukleniyor(true);
    setHata("");

    try {
      const [ben, liste] = await Promise.all([
        veltrisBen(),
        veltrisGet<Kayit[]>(ayar.endpoint),
      ]);

      setKurumId(ben.kurumId);
      setKayitlar(liste);
    } catch (e) {
      setHata(e instanceof Error ? e.message : "Veriler alınamadı.");
    } finally {
      setYukleniyor(false);
    }
  }

  useEffect(() => {
    void yukle();
  }, []);

  function alanDegeri(alan: string): string {
    return form[alan] ?? "";
  }

  async function kaydet(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();

    if (!kurumId) {
      setHata("Kurum bilgisi alınamadı.");
      return;
    }

    try {
      const govde: Record<string, unknown> = {
        kurumId,
        ...form,
      };

      for (const key of Object.keys(govde)) {
        if (
          [
            "riskSkoru",
            "cvssSkoru",
            "etkilenenVarlikSayisi",
          ].includes(key)
        ) {
          govde[key] =
            key === "cvssSkoru"
              ? Number(govde[key] ?? 0)
              : Number(govde[key] ?? 0);
        }
      }

      const cevap = await veltrisPost<Kayit, Record<string, unknown>>(
        ayar.endpoint,
        govde,
      );

      setKayitlar((onceki) => [cevap, ...onceki]);
      setForm({});
      setAcik(false);
      setHata("");
    } catch (e) {
      setHata(e instanceof Error ? e.message : "Kayıt oluşturulamadı.");
    }
  }

  async function sil(id: unknown) {
    if (!id) return;

    try {
      await veltrisIstek<void>(
        `${ayar.endpoint}/${String(id)}`,
        { method: "DELETE" },
      );

      setKayitlar((onceki) =>
        onceki.filter((x) => String(x.id) !== String(id)),
      );
    } catch (e) {
      setHata(e instanceof Error ? e.message : "Kayıt silinemedi.");
    }
  }

  return (
    <main className="min-h-screen bg-[#f6f8fb] px-5 py-8 text-slate-950 lg:px-8">
      <div className="mx-auto max-w-[1500px]">
        <div className="mb-6 flex flex-wrap items-center justify-between gap-4">
          <div>
            <a
              href="/"
              className="mb-3 inline-flex items-center gap-2 text-xs font-bold text-slate-500 hover:text-slate-950"
            >
              <ArrowLeft size={14} />
              Dashboard
            </a>

            <div className="flex items-center gap-3">
              <div className="flex h-12 w-12 items-center justify-center rounded-2xl bg-slate-950 text-white">
                <Icon size={23} />
              </div>

              <div>
                <h1 className="text-2xl font-black tracking-tight">
                  {ayar.baslik}
                </h1>
                <p className="mt-1 text-sm text-slate-500">
                  {ayar.aciklama}
                </p>
              </div>
            </div>
          </div>

          <div className="flex gap-2">
            <button
              type="button"
              onClick={() => void yukle()}
              className="flex items-center gap-2 rounded-xl border border-slate-200 bg-white px-4 py-2.5 text-xs font-bold text-slate-600 shadow-sm hover:bg-slate-50"
            >
              <RefreshCw size={15} />
              Yenile
            </button>

            <button
              type="button"
              onClick={() => setAcik((x) => !x)}
              className="flex items-center gap-2 rounded-xl bg-slate-950 px-4 py-2.5 text-xs font-bold text-white hover:bg-slate-800"
            >
              <Plus size={15} />
              Yeni Kayıt
            </button>
          </div>
        </div>

        {hata && (
          <div className="mb-5 rounded-xl border border-red-200 bg-red-50 p-4 text-sm font-semibold text-red-700">
            {hata}
          </div>
        )}

        {acik && (
          <form
            onSubmit={kaydet}
            className="mb-6 rounded-2xl border border-slate-200 bg-white p-6 shadow-sm"
          >
            <h2 className="text-sm font-black text-slate-950">
              Yeni kayıt
            </h2>

            <div className="mt-5 grid gap-4 md:grid-cols-2">
              {ayar.alanlar.map(([alan, etiket, tip]) => (
                <label
                  key={alan}
                  className={tip === "textarea" ? "md:col-span-2" : ""}
                >
                  <span className="mb-2 block text-xs font-bold text-slate-700">
                    {etiket}
                  </span>

                  {tip === "textarea" ? (
                    <textarea
                      value={alanDegeri(alan)}
                      onChange={(e) =>
                        setForm({
                          ...form,
                          [alan]: e.target.value,
                        })
                      }
                      className="min-h-24 w-full rounded-xl border border-slate-200 px-4 py-3 text-sm outline-none focus:border-slate-400 focus:ring-4 focus:ring-slate-100"
                    />
                  ) : (
                    <input
                      type={tip}
                      value={alanDegeri(alan)}
                      onChange={(e) =>
                        setForm({
                          ...form,
                          [alan]: e.target.value,
                        })
                      }
                      required={["baslik", "ad", "kaynak", "seviye", "durum", "varlikTuru", "kritiklik", "oncelik"].includes(alan)}
                      className="w-full rounded-xl border border-slate-200 px-4 py-3 text-sm outline-none focus:border-slate-400 focus:ring-4 focus:ring-slate-100"
                    />
                  )}
                </label>
              ))}
            </div>

            <div className="mt-5 flex justify-end gap-2">
              <button
                type="button"
                onClick={() => setAcik(false)}
                className="rounded-xl border border-slate-200 bg-white px-4 py-2.5 text-xs font-bold text-slate-600"
              >
                Vazgeç
              </button>

              <button
                type="submit"
                className="rounded-xl bg-slate-950 px-5 py-2.5 text-xs font-bold text-white"
              >
                Kaydet
              </button>
            </div>
          </form>
        )}

        <section className="rounded-2xl border border-slate-200 bg-white shadow-sm">
          <div className="border-b border-slate-100 p-5">
            <div className="flex items-center justify-between">
              <div>
                <h2 className="text-sm font-black">
                  Kayıtlar
                </h2>
                <p className="mt-1 text-xs text-slate-500">
                  PostgreSQL üzerindeki gerçek kayıtlar.
                </p>
              </div>

              <span className="rounded-lg bg-slate-100 px-3 py-1 text-xs font-black text-slate-700">
                {kayitlar.length} kayıt
              </span>
            </div>
          </div>

          {yukleniyor ? (
            <div className="p-8 text-center text-sm font-semibold text-slate-500">
              Veriler yükleniyor...
            </div>
          ) : kayitlar.length === 0 ? (
            <div className="p-12 text-center">
              <Database
                size={32}
                className="mx-auto text-slate-300"
              />

              <p className="mt-4 text-sm font-bold text-slate-700">
                Henüz kayıt bulunmuyor.
              </p>

              <p className="mt-1 text-xs text-slate-400">
                Sahte/demo veri kullanılmıyor. Yeni kaydı doğrudan
                PostgreSQL'e ekleyebilirsiniz.
              </p>
            </div>
          ) : (
            <div className="divide-y divide-slate-100">
              {kayitlar.map((kayit, index) => (
                <div
                  key={String(kayit.id ?? index)}
                  className="flex items-center justify-between gap-4 p-5"
                >
                  <div className="min-w-0">
                    <p className="truncate text-sm font-black text-slate-800">
                      {String(
                        kayit.baslik ??
                        kayit.ad ??
                        kayit.cveKodu ??
                        "Kayıt",
                      )}
                    </p>

                    <p className="mt-1 text-xs text-slate-400">
                      {Object.entries(kayit)
                        .filter(
                          ([key]) =>
                            !["id", "kurumId", "aciklama"].includes(key),
                        )
                        .slice(0, 3)
                        .map(
                          ([key, value]) =>
                            `${key}: ${String(value)}`,
                        )
                        .join(" · ")}
                    </p>
                  </div>

                  <div className="flex items-center gap-2">
                    <CheckCircle2
                      size={17}
                      className="text-emerald-500"
                    />

                    <button
                      type="button"
                      onClick={() => void sil(kayit.id)}
                      className="rounded-lg p-2 text-slate-400 hover:bg-red-50 hover:text-red-600"
                      title="Sil"
                    >
                      <Trash2 size={16} />
                    </button>
                  </div>
                </div>
              ))}
            </div>
          )}
        </section>
      </div>
    </main>
  );
}
