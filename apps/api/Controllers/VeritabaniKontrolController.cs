/*
 * VELTRIS — Veritabanı Kontrol Controller
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veltris.Api.Infrastructure.Data;

namespace Veltris.Api.Controllers;

[ApiController]
[Route("api/veritabani-kontrol")]
[Authorize]
public sealed class VeritabaniKontrolController : ControllerBase
{
    private readonly VeritabaniKontrolServisi _kontrolServisi;

    public VeritabaniKontrolController(
        VeritabaniKontrolServisi kontrolServisi)
    {
        _kontrolServisi = kontrolServisi;
    }

    [HttpGet("kullanicilar")]
    public async Task<IActionResult> Kullanicilar(
        CancellationToken cancellationToken)
    {
        var sonuc = await _kontrolServisi.KullanicilariOkuAsync(
            cancellationToken);

        return Ok(new
        {
            Basarili = true,
            sonuc.KayitSayisi,
            sonuc.Kullanicilar
        });
    }
    [AllowAnonymous]
    [HttpGet("kullanici-sayisi")]
    public async Task<IActionResult> KullaniciSayisi(
        CancellationToken cancellationToken)
    {
        var sonuc = await _kontrolServisi.KullanicilariOkuAsync(
            cancellationToken);

        return Ok(new
        {
            Basarili = true,
            sonuc.KayitSayisi
        });
    }
}

