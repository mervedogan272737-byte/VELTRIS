/*
 * VELTRIS — Health Endpoint
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

namespace Veltris.Api.Infrastructure.Health;

public static class HealthEndpoint
{
    public static IEndpointRouteBuilder MapVeltrisHealth(
        this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet(
            "/health",
            () => Results.Ok(new
            {
                durum = "Healthy",
                platform = "VELTRIS",
                surum = "1.0.0",
                zamanUtc = DateTime.UtcNow
            })
        );

        return endpoints;
    }
}
