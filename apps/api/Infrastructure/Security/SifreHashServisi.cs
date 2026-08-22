/*
 * VELTRIS — Şifre Hashleme Servisi
 * Geliştirici: Yazılım Uzmanı Merve Kılıç
 * Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
 */

using System.Security.Cryptography;

namespace Veltris.Api.Infrastructure.Security;

public sealed class SifreHashServisi
{
    private const int TuzBoyutu = 16;
    private const int HashBoyutu = 32;
    private const int IterasyonSayisi = 100_000;

    public string Hashle(string sifre)
    {
        if (string.IsNullOrWhiteSpace(sifre))
        {
            throw new ArgumentException(
                "Şifre boş olamaz.",
                nameof(sifre));
        }

        var tuz = RandomNumberGenerator.GetBytes(TuzBoyutu);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            sifre,
            tuz,
            IterasyonSayisi,
            HashAlgorithmName.SHA256,
            HashBoyutu);

        return string.Join(
            '.',
            "PBKDF2",
            "SHA256",
            IterasyonSayisi,
            Convert.ToBase64String(tuz),
            Convert.ToBase64String(hash));
    }

    public bool Dogrula(string sifre, string sifreOzeti)
    {
        if (string.IsNullOrWhiteSpace(sifre) ||
            string.IsNullOrWhiteSpace(sifreOzeti))
        {
            return false;
        }

        var parcalar = sifreOzeti.Split('.');

        if (parcalar.Length != 5 ||
            !string.Equals(
                parcalar[0],
                "PBKDF2",
                StringComparison.Ordinal) ||
            !string.Equals(
                parcalar[1],
                "SHA256",
                StringComparison.Ordinal) ||
            !int.TryParse(parcalar[2], out var iterasyonSayisi))
        {
            return false;
        }

        try
        {
            var tuz = Convert.FromBase64String(parcalar[3]);
            var beklenenHash = Convert.FromBase64String(parcalar[4]);

            var gercekHash = Rfc2898DeriveBytes.Pbkdf2(
                sifre,
                tuz,
                iterasyonSayisi,
                HashAlgorithmName.SHA256,
                beklenenHash.Length);

            return CryptographicOperations.FixedTimeEquals(
                gercekHash,
                beklenenHash);
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
