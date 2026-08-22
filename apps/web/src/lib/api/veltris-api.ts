/*
 * VELTRIS — API İstemcisi
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

import { VELTRIS_YAPILANDIRMASI } from "@/config/veltris";

export type GirisCevabi = {
  basarili: boolean;
  mesaj: string;
  erisimTokeni: string;
  sonGecerlilikUtc: string;
};

export type BenCevabi = {
  basarili: boolean;
  kullaniciId: string | null;
  kurumId: string | null;
  eposta: string | null;
  roller: string[];
  yetkiler: string[];
};

export type DashboardOzetYaniti = {
  guvenlikSkoru: number;
  aktifTehditSayisi: number;
  kritikTehditSayisi: number;
  acikOlaySayisi: number;
  yuksekOncelikliOlaySayisi: number;
  zafiyetSayisi: number;
  kritikZafiyetSayisi: number;
  aiMotoru: {
    durum: string;
    deger: string;
  };
  veriIsleme: {
    durum: string;
    deger: string;
  };
  sensorAgi: {
    durum: string;
    deger: string;
  };
  aktifTehditler: Array<{
    baslik: string;
    kaynak: string;
    seviye: string;
    zaman: string;
  }>;
  aktiviteler: Array<{
    baslik: string;
    kaynak: string;
    zaman: string;
  }>;
  riskAnalizi: {
    derece: string;
    seviye: string;
    aciklama: string;
    kritikRiskVar: boolean;
  };
};

export class VELTRISApiHatasi extends Error {
  readonly durumKodu: number;

  constructor(mesaj: string, durumKodu: number) {
    super(mesaj);
    this.name = "VELTRISApiHatasi";
    this.durumKodu = durumKodu;
  }
}

const TOKEN_ANAHTARI = "veltris_erisim_tokeni";

export function veltrisTokeniniAl(): string | null {
  if (typeof window === "undefined") {
    return null;
  }

  return window.localStorage.getItem(TOKEN_ANAHTARI);
}

export function veltrisTokeniniKaydet(token: string): void {
  window.localStorage.setItem(TOKEN_ANAHTARI, token);
}

export function veltrisOturumuKapat(): void {
  window.localStorage.removeItem(TOKEN_ANAHTARI);
}

async function yanitGövdesiniOku<T>(
  yanit: Response,
): Promise<T | null> {
  const icerikTuru =
    yanit.headers.get("content-type") ?? "";

  if (!icerikTuru.includes("application/json")) {
    return null;
  }

  return (await yanit.json()) as T;
}

export async function veltrisIstek<T>(
  yol: string,
  secenekler: RequestInit = {},
): Promise<T> {
  const denetleyici = new AbortController();

  const zamanAsimi = window.setTimeout(
    () => denetleyici.abort(),
    VELTRIS_YAPILANDIRMASI.api.zamanAsimiMs,
  );

  try {
    const temelBasliklar = new Headers(secenekler.headers);

    temelBasliklar.set(
      "Accept",
      "application/json",
    );

    if (
      secenekler.body &&
      !temelBasliklar.has("Content-Type")
    ) {
      temelBasliklar.set(
        "Content-Type",
        "application/json",
      );
    }

    const token = veltrisTokeniniAl();

    if (token) {
      temelBasliklar.set(
        "Authorization",
        `Bearer ${token}`,
      );
    }

    const yanit = await fetch(
      `${VELTRIS_YAPILANDIRMASI.api.temelAdres}${yol}`,
      {
        ...secenekler,
        headers: temelBasliklar,
        signal: denetleyici.signal,
        credentials: "omit",
      },
    );

    const veri =
      await yanitGövdesiniOku<T>(yanit);

    if (!yanit.ok) {
      const mesaj =
        typeof veri === "object" &&
        veri !== null &&
        "mesaj" in veri &&
        typeof veri.mesaj === "string"
          ? veri.mesaj
          : `VELTRIS API isteği başarısız oldu. HTTP ${yanit.status}`;

      throw new VELTRISApiHatasi(
        mesaj,
        yanit.status,
      );
    }

    return veri as T;
  } catch (hata) {
    if (hata instanceof VELTRISApiHatasi) {
      throw hata;
    }

    if (
      hata instanceof DOMException &&
      hata.name === "AbortError"
    ) {
      throw new VELTRISApiHatasi(
        "VELTRIS API isteği zaman aşımına uğradı.",
        408,
      );
    }

    throw new VELTRISApiHatasi(
      "VELTRIS API ile iletişim kurulamadı.",
      0,
    );
  } finally {
    window.clearTimeout(zamanAsimi);
  }
}

export async function veltrisGet<T>(
  yol: string,
): Promise<T> {
  return veltrisIstek<T>(yol, {
    method: "GET",
  });
}

export async function veltrisPost<
  TResponse,
  TBody,
>(
  yol: string,
  veri: TBody,
): Promise<TResponse> {
  return veltrisIstek<TResponse>(yol, {
    method: "POST",
    body: JSON.stringify(veri),
  });
}

export async function veltrisGiris(
  eposta: string,
  sifre: string,
): Promise<GirisCevabi> {
  const cevap = await veltrisPost<
    GirisCevabi,
    { eposta: string; sifre: string }
  >(
    "/kimlik/giris",
    {
      eposta,
      sifre,
    },
  );

  veltrisTokeniniKaydet(
    cevap.erisimTokeni,
  );

  return cevap;
}

export async function veltrisBen(): Promise<BenCevabi> {
  return veltrisGet<BenCevabi>(
    "/kimlik/ben",
  );
}

export async function veltrisDashboard(): Promise<DashboardOzetYaniti> {
  return veltrisGet<DashboardOzetYaniti>(
    "/dashboard/ozet",
  );
}

export type IlkKurulumDurumuYaniti = {
  kurulumGerekli: boolean;
  kullaniciSayisi: number;
};

export type IlkKurulumCevabi = {
  basarili: boolean;
  mesaj: string;
  erisimTokeni: string;
  sonGecerlilikUtc: string;
};

export async function veltrisKurulumDurumu(): Promise<IlkKurulumDurumuYaniti> {
  return veltrisGet<IlkKurulumDurumuYaniti>(
    "/kurulum/durum",
  );
}

export async function veltrisIlkYoneticiOlustur(
  ad: string,
  soyad: string,
  eposta: string,
  sifre: string,
): Promise<IlkKurulumCevabi> {
  const cevap = await veltrisPost<
    IlkKurulumCevabi,
    {
      ad: string;
      soyad: string;
      eposta: string;
      sifre: string;
    }
  >(
    "/kurulum/yonetici",
    {
      ad,
      soyad,
      eposta,
      sifre,
    },
  );

  veltrisTokeniniKaydet(
    cevap.erisimTokeni,
  );

  return cevap;
}
