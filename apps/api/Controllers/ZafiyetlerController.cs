/*
 * VELTRIS — Zafiyet Yönetimi Controller
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veltris.Api.Application.Guvenlik;

namespace Veltris.Api.Controllers;

[ApiController]
[Route("api/zafiyetler")]
[Authorize]
public sealed class ZafiyetlerController : ControllerBase
{
    private readonly GuvenlikModulleriServisi _servis;

    public ZafiyetlerController(GuvenlikModulleriServisi servis) => _servis = servis;

    [HttpGet]
    public async Task<IActionResult> Liste(CancellationToken ct) => Ok(await _servis.ZafiyetleriGetirAsync(ct));

    [HttpPost]
    public async Task<IActionResult> Olustur(ZafiyetOlusturmaIstegi istek, CancellationToken ct)
        => Ok(await _servis.ZafiyetOlusturAsync(istek, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Sil(Guid id, CancellationToken ct)
        => (await _servis.ZafiyetSilAsync(id, ct)) ? NoContent() : NotFound();
}
