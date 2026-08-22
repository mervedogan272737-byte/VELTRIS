/*
 * VELTRIS — Rol Yetkisi Veritabanı Yapılandırması
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veltris.Api.Domain.Entities;

namespace Veltris.Api.Infrastructure.Data.Configurations;

public sealed class RolYetkiYapilandirmasi : IEntityTypeConfiguration<RolYetki>
{
    public void Configure(EntityTypeBuilder<RolYetki> builder)
    {
        builder.ToTable("RolYetkileri");

        builder.HasKey(x => new { x.RolId, x.YetkiId });

        builder.HasOne(x => x.Rol)
            .WithMany(x => x.RolYetkileri)
            .HasForeignKey(x => x.RolId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Yetki)
            .WithMany(x => x.RolYetkileri)
            .HasForeignKey(x => x.YetkiId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
