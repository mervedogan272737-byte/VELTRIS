/*
 * VELTRIS — Kimlik DTO'ları
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

namespace Veltris.Api.Application.Auth;

public sealed record GirisIstegi(
    string Eposta,
    string Sifre);

public sealed record GirisCevabi(
    string ErisimTokeni,
    DateTime SonGecerlilikUtc);
