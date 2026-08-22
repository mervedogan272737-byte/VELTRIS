/*
 * VELTRIS — Tehdit Yönetimi Controller
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veltris.Api.Application.Guvenlik;

namespace Veltris.Api.Controllers;

[ApiController]
[Route("api/tehditler")]
[Authorize]
public sealed class TehditlerController : ControllerBase
{
    private readonly GuvenlikModulleriServisi _servis;

    public TehditlerController(GuvenlikModulleriServisi servis) => _servis = servis;

    [HttpGet]
    public async Task<IActionResult> Liste(CancellationToken ct) => Ok(await _servis.TehditleriGetirAsync(ct));

    [HttpPost]
    public async Task<IActionResult> Olustur(TehditOlusturmaIstegi istek, CancellationToken ct)
        => Ok(await _servis.TehditOlusturAsync(istek, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Sil(Guid id, CancellationToken ct)
        => (await _servis.TehditSilAsync(id, ct)) ? NoContent() : NotFound();
}
