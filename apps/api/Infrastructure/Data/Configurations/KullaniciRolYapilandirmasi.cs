/*
 * VELTRIS — Kullanıcı Rolü Veritabanı Yapılandırması
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veltris.Api.Domain.Entities;

namespace Veltris.Api.Infrastructure.Data.Configurations;

public sealed class KullaniciRolYapilandirmasi : IEntityTypeConfiguration<KullaniciRol>
{
    public void Configure(EntityTypeBuilder<KullaniciRol> builder)
    {
        builder.ToTable("KullaniciRolleri");

        builder.HasKey(x => new { x.KullaniciId, x.RolId });

        builder.HasOne(x => x.Kullanici)
            .WithMany(x => x.KullaniciRolleri)
            .HasForeignKey(x => x.KullaniciId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Rol)
            .WithMany(x => x.KullaniciRolleri)
            .HasForeignKey(x => x.RolId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
