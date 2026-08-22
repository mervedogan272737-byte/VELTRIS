/*
 * VELTRIS — Güvenlik Biçimlendiricileri
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

export function sayiyiFormatla(
  deger: number,
): string {
  return new Intl.NumberFormat("tr-TR").format(deger);
}

export function yuzdeFormatla(
  deger: number,
  ondalik = 1,
): string {
  return new Intl.NumberFormat("tr-TR", {
    style: "percent",
    minimumFractionDigits: ondalik,
    maximumFractionDigits: ondalik,
  }).format(deger / 100);
}

export function tarihSaatFormatla(
  tarih: string | Date,
): string {
  const deger =
    typeof tarih === "string"
      ? new Date(tarih)
      : tarih;

  return new Intl.DateTimeFormat("tr-TR", {
    dateStyle: "medium",
    timeStyle: "short",
  }).format(deger);
}

export function cvssFormatla(
  skor: number,
): string {
  return skor.toFixed(1);
}
