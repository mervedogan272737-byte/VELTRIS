/*
 * VELTRIS — Dashboard Controller
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veltris.Api.Application.Dashboard;

namespace Veltris.Api.Controllers;

[ApiController]
[Route("api/dashboard")]
[Authorize]
public sealed class DashboardController : ControllerBase
{
    private readonly DashboardServisi _dashboardServisi;

    public DashboardController(
        DashboardServisi dashboardServisi)
    {
        _dashboardServisi = dashboardServisi;
    }

    [HttpGet("ozet")]
    public async Task<ActionResult<DashboardOzetYaniti>> Ozet(CancellationToken ct)
    {
        return Ok(await _dashboardServisi.OzetGetirAsync(ct));
    }
}

