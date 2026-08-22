/*
 * VELTRIS — Risk Motoru Controller
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veltris.Api.Application.Guvenlik;

namespace Veltris.Api.Controllers;

[ApiController]
[Route("api/risk")]
[Authorize]
public sealed class RiskController : ControllerBase
{
    private readonly RiskMotoruServisi _servis;

    public RiskController(RiskMotoruServisi servis) => _servis = servis;

    [HttpGet("ozet")]
    public async Task<IActionResult> Ozet(CancellationToken ct)
        => Ok(await _servis.HesaplaAsync(ct));
}
