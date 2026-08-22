/*
 * VELTRIS — Kimlik Token Servisi
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Veltris.Api.Domain.Entities;

namespace Veltris.Api.Infrastructure.Security;

public sealed class JwtTokenServisi
{
    private readonly JwtAyarlari _ayarlari;

    public JwtTokenServisi(JwtAyarlari ayarlari)
    {
        _ayarlari = ayarlari;
    }

    public string TokenOlustur(
        Kullanici kullanici,
        IEnumerable<string> roller,
        IEnumerable<string> yetkiler)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, kullanici.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, kullanici.Eposta),
            new(ClaimTypes.NameIdentifier, kullanici.Id.ToString()),
            new(ClaimTypes.Email, kullanici.Eposta),
            new(ClaimTypes.Name, $"{kullanici.Ad} {kullanici.Soyad}"),
            new("kurum_id", kullanici.KurumId.ToString())
        };

        claims.AddRange(
            roller.Select(rol => new Claim(ClaimTypes.Role, rol)));

        claims.AddRange(
            yetkiler.Select(yetki => new Claim("yetki", yetki)));

        var anahtar = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_ayarlari.GizliAnahtar));

        var kimlikBilgileri = new SigningCredentials(
            anahtar,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _ayarlari.Veren,
            audience: _ayarlari.HedefKitle,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_ayarlari.Dakika),
            signingCredentials: kimlikBilgileri);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

