/*
 * VELTRIS — Kullanıcı Veritabanı Yapılandırması
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veltris.Api.Domain.Entities;

namespace Veltris.Api.Infrastructure.Data.Configurations;

public sealed class KullaniciYapilandirmasi : IEntityTypeConfiguration<Kullanici>
{
    public void Configure(EntityTypeBuilder<Kullanici> builder)
    {
        builder.ToTable("Kullanicilar");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Ad)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Soyad)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Eposta)
            .HasMaxLength(320)
            .IsRequired();

        builder.Property(x => x.SifreOzeti)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Aktif)
            .IsRequired();

        builder.Property(x => x.OlusturulmaTarihiUtc)
            .IsRequired();

        builder.HasIndex(x => new { x.KurumId, x.Eposta })
            .IsUnique();
    }
}
