/*
 * VELTRIS — Rol Veritabanı Yapılandırması
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veltris.Api.Domain.Entities;

namespace Veltris.Api.Infrastructure.Data.Configurations;

public sealed class RolYapilandirmasi : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("Roller");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Ad)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Aciklama)
            .HasMaxLength(2000);

        builder.Property(x => x.SistemRolu)
            .IsRequired();

        builder.Property(x => x.Aktif)
            .IsRequired();

        builder.Property(x => x.OlusturulmaTarihiUtc)
            .IsRequired();

        builder.HasIndex(x => new { x.KurumId, x.Ad })
            .IsUnique();
    }
}
