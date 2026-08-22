using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veltris.Api.Migrations
{
    /// <inheritdoc />
    public partial class GuvenlikModulleri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuvenlikOlaylari",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KurumId = table.Column<Guid>(type: "uuid", nullable: false),
                    Baslik = table.Column<string>(type: "text", nullable: false),
                    Aciklama = table.Column<string>(type: "text", nullable: true),
                    Oncelik = table.Column<string>(type: "text", nullable: false),
                    Durum = table.Column<string>(type: "text", nullable: false),
                    RiskSkoru = table.Column<int>(type: "integer", nullable: false),
                    TehditId = table.Column<Guid>(type: "uuid", nullable: true),
                    OlusturulmaTarihiUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GuncellenmeTarihiUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuvenlikOlaylari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuvenlikTehditleri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KurumId = table.Column<Guid>(type: "uuid", nullable: false),
                    Baslik = table.Column<string>(type: "text", nullable: false),
                    Aciklama = table.Column<string>(type: "text", nullable: true),
                    Kaynak = table.Column<string>(type: "text", nullable: false),
                    Seviye = table.Column<string>(type: "text", nullable: false),
                    Durum = table.Column<string>(type: "text", nullable: false),
                    RiskSkoru = table.Column<int>(type: "integer", nullable: false),
                    Gosterge = table.Column<string>(type: "text", nullable: true),
                    OlusturulmaTarihiUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GuncellenmeTarihiUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuvenlikTehditleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuvenlikVarliklari",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KurumId = table.Column<Guid>(type: "uuid", nullable: false),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    VarlikTuru = table.Column<string>(type: "text", nullable: false),
                    HostAdi = table.Column<string>(type: "text", nullable: true),
                    IpAdresi = table.Column<string>(type: "text", nullable: true),
                    IsletimSistemi = table.Column<string>(type: "text", nullable: true),
                    Kritiklik = table.Column<string>(type: "text", nullable: false),
                    Durum = table.Column<string>(type: "text", nullable: false),
                    OlusturulmaTarihiUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GuncellenmeTarihiUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuvenlikVarliklari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuvenlikZafiyetleri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KurumId = table.Column<Guid>(type: "uuid", nullable: false),
                    Baslik = table.Column<string>(type: "text", nullable: false),
                    CveKodu = table.Column<string>(type: "text", nullable: true),
                    CvssSkoru = table.Column<decimal>(type: "numeric", nullable: false),
                    Seviye = table.Column<string>(type: "text", nullable: false),
                    Durum = table.Column<string>(type: "text", nullable: false),
                    EtkilenenVarlikSayisi = table.Column<int>(type: "integer", nullable: false),
                    CozumNotu = table.Column<string>(type: "text", nullable: true),
                    OlusturulmaTarihiUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GuncellenmeTarihiUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuvenlikZafiyetleri", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuvenlikOlaylari");

            migrationBuilder.DropTable(
                name: "GuvenlikTehditleri");

            migrationBuilder.DropTable(
                name: "GuvenlikVarliklari");

            migrationBuilder.DropTable(
                name: "GuvenlikZafiyetleri");
        }
    }
}
