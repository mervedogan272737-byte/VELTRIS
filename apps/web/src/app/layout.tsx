/*
 * VELTRIS — Uygulama Kök Yerleşimi
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

import type { Metadata, Viewport } from "next";
import "./globals.css";
import {
  VELTRIS_METADATA,
  VELTRIS_VIEWPORT,
} from "@/config/metadata";

export const metadata: Metadata = VELTRIS_METADATA;

export const viewport: Viewport = VELTRIS_VIEWPORT;

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="tr">
      <body>{children}</body>
    </html>
  );
}
