/*
 * VELTRIS — Olay Yönetimi Controller
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veltris.Api.Application.Guvenlik;

namespace Veltris.Api.Controllers;

[ApiController]
[Route("api/olaylar")]
[Authorize]
public sealed class OlaylarController : ControllerBase
{
    private readonly GuvenlikModulleriServisi _servis;

    public OlaylarController(GuvenlikModulleriServisi servis) => _servis = servis;

    [HttpGet]
    public async Task<IActionResult> Liste(CancellationToken ct) => Ok(await _servis.OlaylariGetirAsync(ct));

    [HttpPost]
    public async Task<IActionResult> Olustur(OlayOlusturmaIstegi istek, CancellationToken ct)
        => Ok(await _servis.OlayOlusturAsync(istek, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Sil(Guid id, CancellationToken ct)
        => (await _servis.OlaySilAsync(id, ct)) ? NoContent() : NotFound();
}
