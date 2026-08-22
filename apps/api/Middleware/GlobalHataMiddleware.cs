/*
 * VELTRIS — Global Hata Middleware
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using System.Text.Json;

namespace Veltris.Api.Middleware;

public sealed class GlobalHataMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalHataMiddleware> _logger;

    public GlobalHataMiddleware(
        RequestDelegate next,
        ILogger<GlobalHataMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "VELTRIS API beklenmeyen bir hata ile karşılaştı.");

            context.Response.StatusCode =
                StatusCodes.Status500InternalServerError;

            context.Response.ContentType = "application/json; charset=utf-8";

            var yanit = new
            {
                durum = "Error",
                mesaj = "İşlem sırasında beklenmeyen bir sunucu hatası oluştu.",
                zamanUtc = DateTime.UtcNow
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(yanit)
            );
        }
    }
}
