/*
 * VELTRIS — İlk Kurulum Controller
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veltris.Api.Application.Kurulum;

namespace Veltris.Api.Controllers;

[ApiController]
[Route("api/kurulum")]
public sealed class KurulumController : ControllerBase
{
    private readonly IlkKurulumServisi _servis;

    public KurulumController(IlkKurulumServisi servis)
    {
        _servis = servis;
    }

    [AllowAnonymous]
    [HttpGet("durum")]
    public async Task<IActionResult> Durum(
        CancellationToken cancellationToken)
    {
        return Ok(
            await _servis.DurumuGetirAsync(
                cancellationToken));
    }

    [AllowAnonymous]
    [HttpPost("yonetici")]
    public async Task<IActionResult> YoneticiOlustur(
        [FromBody] IlkYoneticiOlusturmaIstegi istek,
        CancellationToken cancellationToken)
    {
        var sonuc =
            await _servis.YoneticiOlusturAsync(
                istek,
                cancellationToken);

        if (sonuc is null)
        {
            return Conflict(new
            {
                Basarili = false,
                Mesaj = "VELTRIS zaten yapılandırılmış. İlk kurulum yalnızca ilk kullanıcı için kullanılabilir."
            });
        }

        return Ok(new
        {
            Basarili = true,
            Mesaj = "Yönetici hesabı başarıyla oluşturuldu.",
            sonuc.ErisimTokeni,
            sonuc.SonGecerlilikUtc
        });
    }
}
