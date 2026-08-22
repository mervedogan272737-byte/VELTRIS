/*
 * VELTRIS — Kullanıcı Rol İlişkisi
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

namespace Veltris.Api.Domain.Entities;

public sealed class KullaniciRol
{
    public Guid KullaniciId { get; set; }

    public Guid RolId { get; set; }

    public Kullanici? Kullanici { get; set; }

    public Rol? Rol { get; set; }
}
