/*
 * VELTRIS — PostgreSQL Veritabanı Bağlamı
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using Microsoft.EntityFrameworkCore;
using Veltris.Api.Domain.Entities;

namespace Veltris.Api.Infrastructure.Data;

public sealed class VeltrisDbContext : DbContext
{
    public VeltrisDbContext(
        DbContextOptions<VeltrisDbContext> options)
        : base(options)
    {
    }

    public DbSet<Kurum> Kurumlar => Set<Kurum>();

    public DbSet<Kullanici> Kullanicilar => Set<Kullanici>();

    public DbSet<Rol> Roller => Set<Rol>();

    public DbSet<Yetki> Yetkiler => Set<Yetki>();

    public DbSet<KullaniciRol> KullaniciRolleri => Set<KullaniciRol>();

    public DbSet<RolYetki> RolYetkileri => Set<RolYetki>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(VeltrisDbContext).Assembly);
    }

    public DbSet<GuvenlikTehdidi> GuvenlikTehditleri => Set<GuvenlikTehdidi>();
    public DbSet<GuvenlikOlayi> GuvenlikOlaylari => Set<GuvenlikOlayi>();
    public DbSet<GuvenlikZafiyeti> GuvenlikZafiyetleri => Set<GuvenlikZafiyeti>();
    public DbSet<GuvenlikVarligi> GuvenlikVarliklari => Set<GuvenlikVarligi>();
}

