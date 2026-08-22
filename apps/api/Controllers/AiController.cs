/*
 * VELTRIS — AI Risk Analizi Controller
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veltris.Api.Application.Ai;

namespace Veltris.Api.Controllers;

[ApiController]
[Route("api/ai")]
[Authorize]
public sealed class AiController : ControllerBase
{
    private readonly AiRiskAnalizServisi _servis;

    public AiController(AiRiskAnalizServisi servis) => _servis = servis;

    [HttpGet("risk-analizi")]
    public async Task<IActionResult> RiskAnalizi(CancellationToken ct)
        => Ok(await _servis.AnalizEtAsync(ct));
}
