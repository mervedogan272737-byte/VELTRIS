/*
 * VELTRIS — Kurum Veritabanı Yapılandırması
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veltris.Api.Domain.Entities;

namespace Veltris.Api.Infrastructure.Data.Configurations;

public sealed class KurumYapilandirmasi : IEntityTypeConfiguration<Kurum>
{
    public void Configure(EntityTypeBuilder<Kurum> builder)
    {
        builder.ToTable("Kurumlar");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Ad)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Aciklama)
            .HasMaxLength(2000);

        builder.Property(x => x.Aktif)
            .IsRequired();

        builder.Property(x => x.OlusturulmaTarihiUtc)
            .IsRequired();

        builder.HasMany(x => x.Kullanicilar)
            .WithOne(x => x.Kurum)
            .HasForeignKey(x => x.KurumId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.Ad)
            .IsUnique();
    }
}
