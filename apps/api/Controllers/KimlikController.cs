/*
 * VELTRIS — Kimlik Controller
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Veltris.Api.Controllers;

[ApiController]
[Route("api/kimlik")]
public sealed partial class KimlikController : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("durum")]
    public IActionResult Durum()
    {
        return Ok(new
        {
            Basarili = true,
            Mesaj = "VELTRIS kimlik servisi aktif.",
            ZamanUtc = DateTime.UtcNow
        });
    }

    [Authorize]
    [HttpGet("ben")]
    public IActionResult Ben()
    {
        var kullaniciId =
            User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? User.FindFirstValue("sub");

        var kurumId =
            User.FindFirstValue("kurum_id");

        var eposta =
            User.FindFirstValue(ClaimTypes.Email)
            ?? User.FindFirstValue("email");

        var roller = User
            .FindAll(ClaimTypes.Role)
            .Select(x => x.Value)
            .Distinct(StringComparer.Ordinal)
            .ToArray();

        var yetkiler = User
            .FindAll("yetki")
            .Select(x => x.Value)
            .Distinct(StringComparer.Ordinal)
            .ToArray();

        return Ok(new
        {
            Basarili = true,
            KullaniciId = kullaniciId,
            KurumId = kurumId,
            Eposta = eposta,
            Roller = roller,
            Yetkiler = yetkiler
        });
    }
}
