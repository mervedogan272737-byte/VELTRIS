/*
 * VELTRIS — Güvenlik Alan Tipleri
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

export type RiskSeviyesi =
  | "KRITIK"
  | "YUKSEK"
  | "ORTA"
  | "DUSUK"
  | "BILINMIYOR";

export type OlayDurumu =
  | "ACIK"
  | "INCELEMEDE"
  | "AZALTILIYOR"
  | "COZULDU"
  | "KAPATILDI";

export type TehditDurumu =
  | "AKTIF"
  | "IZLENIYOR"
  | "AZALTILDI"
  | "ORTADAN_KALDIRILDI";

export interface GuvenlikSkoru {
  skor: number;
  oncekiSkor: number;
  degisimYuzdesi: number;
  riskSeviyesi: RiskSeviyesi;
  guncellemeZamani: string;
}

export interface Tehdit {
  id: string;
  baslik: string;
  aciklama: string;
  kaynak: string;
  riskSeviyesi: RiskSeviyesi;
  durum: TehditDurumu;
  tespitZamani: string;
  sonGuncelleme: string;
  etkilenenVarlikSayisi: number;
}

export interface GuvenlikOlayi {
  id: string;
  baslik: string;
  aciklama: string;
  durum: OlayDurumu;
  oncelik: RiskSeviyesi;
  kaynak: string;
  sorumlu?: string;
  olusturulmaZamani: string;
  guncellenmeZamani: string;
}

export interface Zafiyet {
  id: string;
  cve?: string;
  baslik: string;
  aciklama: string;
  cvssSkoru: number;
  riskSeviyesi: RiskSeviyesi;
  durum: "ACIK" | "AZALTILIYOR" | "COZULDU";
  etkilenenVarlikSayisi: number;
}

export interface Varlik {
  id: string;
  ad: string;
  tur: "SUNUCU" | "CIHAZ" | "UYGULAMA" | "VERITABANI" | "AG" | "BULUT";
  adres?: string;
  durum: "AKTIF" | "PASIF" | "BILINMIYOR";
  kritik: boolean;
  sonGorulme: string;
}

export interface SistemSagligi {
  ad: string;
  durum: "AKTIF" | "UYARI" | "HATA";
  kullanilabilirlikYuzdesi: number;
  sonKontrol: string;
}
