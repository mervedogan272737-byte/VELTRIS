/*
 * VELTRIS — Kimlik Controller Login İşlemleri
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Veltris.Api.Controllers;

public sealed partial class KimlikController
{
    [AllowAnonymous]
    [HttpPost("giris")]
    public async Task<IActionResult> Giris(
        [FromBody] Application.Auth.GirisIstegi istek,
        [FromServices] Application.Auth.LoginServisi loginServisi,
        CancellationToken cancellationToken)
    {
        var sonuc = await loginServisi.GirisYapAsync(
            istek,
            cancellationToken);

        if (sonuc is null)
        {
            return Unauthorized(new
            {
                Basarili = false,
                Mesaj = "E-posta veya şifre hatalı."
            });
        }

        return Ok(new
        {
            Basarili = true,
            Mesaj = "Giriş başarılı.",
            sonuc.ErisimTokeni,
            sonuc.SonGecerlilikUtc
        });
    }
}
