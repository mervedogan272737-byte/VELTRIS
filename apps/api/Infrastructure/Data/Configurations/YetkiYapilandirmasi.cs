/*
 * VELTRIS — Yetki Veritabanı Yapılandırması
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veltris.Api.Domain.Entities;

namespace Veltris.Api.Infrastructure.Data.Configurations;

public sealed class YetkiYapilandirmasi : IEntityTypeConfiguration<Yetki>
{
    public void Configure(EntityTypeBuilder<Yetki> builder)
    {
        builder.ToTable("Yetkiler");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Kod)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Ad)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Aciklama)
            .HasMaxLength(2000);

        builder.Property(x => x.Aktif)
            .IsRequired();

        builder.HasIndex(x => x.Kod)
            .IsUnique();
    }
}
