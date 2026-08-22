/*
 * VELTRIS — Rol Yetki İlişkisi
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

namespace Veltris.Api.Domain.Entities;

public sealed class RolYetki
{
    public Guid RolId { get; set; }

    public Guid YetkiId { get; set; }

    public Rol? Rol { get; set; }

    public Yetki? Yetki { get; set; }
}
