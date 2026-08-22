/*
 * VELTRIS — Varlık Yönetimi Controller
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veltris.Api.Application.Guvenlik;

namespace Veltris.Api.Controllers;

[ApiController]
[Route("api/varliklar")]
[Authorize]
public sealed class VarliklarController : ControllerBase
{
    private readonly GuvenlikModulleriServisi _servis;

    public VarliklarController(GuvenlikModulleriServisi servis) => _servis = servis;

    [HttpGet]
    public async Task<IActionResult> Liste(CancellationToken ct) => Ok(await _servis.VarliklariGetirAsync(ct));

    [HttpPost]
    public async Task<IActionResult> Olustur(VarlikOlusturmaIstegi istek, CancellationToken ct)
        => Ok(await _servis.VarlikOlusturAsync(istek, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Sil(Guid id, CancellationToken ct)
        => (await _servis.VarlikSilAsync(id, ct)) ? NoContent() : NotFound();
}
