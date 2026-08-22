/*
 * VELTRIS — Sistem Controller
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Veltris.Api.Application.Services;

namespace Veltris.Api.Controllers;

[ApiController]
[Route("api/sistem")]
public sealed class SistemController : ControllerBase
{
    private readonly SistemSaglikServisi _sistemSaglikServisi;
    private readonly IHostEnvironment _ortam;

    public SistemController(
        SistemSaglikServisi sistemSaglikServisi,
        IHostEnvironment ortam)
    {
        _sistemSaglikServisi = sistemSaglikServisi;
        _ortam = ortam;
    }

    [HttpGet("bilgi")]
    public ActionResult GetirBilgi()
    {
        return Ok(
            _sistemSaglikServisi.ApiBilgisiniGetir(_ortam)
        );
    }

    [HttpGet("saglik")]
    public ActionResult GetirSaglik()
    {
        return Ok(
            _sistemSaglikServisi.SaglikDurumunuGetir()
        );
    }
}
