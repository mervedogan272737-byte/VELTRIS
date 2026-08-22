/*
 * VELTRIS — API Başlangıç Yapılandırması
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Veltris.Api.Application.Auth;
using Veltris.Api.Application.Dashboard;
using Veltris.Api.Application.Kurulum;
using Veltris.Api.Application.Guvenlik;
using Veltris.Api.Application.Ai;
using Veltris.Api.Infrastructure.Data;
using Veltris.Api.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "VeltrisFrontend",
        policy =>
        {
            policy
                .WithOrigins(
                    "http://localhost:3000",
                    "http://127.0.0.1:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var jwtAyarlari = builder.Configuration
    .GetSection(JwtAyarlari.BolumAdi)
    .Get<JwtAyarlari>()
    ?? throw new InvalidOperationException(
        "Jwt yapılandırması bulunamadı.");

builder.Services.AddSingleton(jwtAyarlari);
builder.Services.AddSingleton<JwtTokenServisi>();
builder.Services.AddSingleton<SifreHashServisi>();
builder.Services.AddScoped<VeritabaniKontrolServisi>();
builder.Services.AddScoped<LoginServisi>();
builder.Services.AddScoped<DashboardServisi>();
builder.Services.AddScoped<IlkKurulumServisi>();
builder.Services.AddScoped<GuvenlikModulleriServisi>();
builder.Services.AddScoped<RiskMotoruServisi>();
builder.Services.AddScoped<AiRiskAnalizServisi>();
builder.Services.AddScoped<IAiRiskAnalizSaglayicisi, YerelAiRiskAnalizSaglayicisi>();

var veritabaniBaglantisi =
    builder.Configuration.GetConnectionString("VeltrisPostgreSql")
    ?? throw new InvalidOperationException(
        "VeltrisPostgreSql bağlantı dizesi bulunamadı.");

builder.Services.AddDbContext<VeltrisDbContext>(options =>
{
    options.UseNpgsql(veritabaniBaglantisi);
});

var imzalamaAnahtari = new SymmetricSecurityKey(
    Encoding.UTF8.GetBytes(jwtAyarlari.GizliAnahtar));

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = imzalamaAnahtari,
            ValidateIssuer = true,
            ValidIssuer = jwtAyarlari.Veren,
            ValidateAudience = true,
            ValidAudience = jwtAyarlari.HedefKitle,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30)
        };
    });

builder.Services.AddAuthorization();

var uygulama = builder.Build();

if (uygulama.Environment.IsDevelopment())
{
    uygulama.UseSwagger();
    uygulama.UseSwaggerUI();
}
else
{
    uygulama.UseHttpsRedirection();
}

uygulama.UseCors("VeltrisFrontend");
uygulama.UseAuthentication();
uygulama.UseAuthorization();
uygulama.MapControllers();

uygulama.Run();


