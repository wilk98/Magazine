using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dostawcy",
                columns: table => new
                {
                    DostawcaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaFirmy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostawcy", x => x.DostawcaId);
                });

            migrationBuilder.CreateTable(
                name: "Etykiety",
                columns: table => new
                {
                    EtykietaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etykiety", x => x.EtykietaId);
                });

            migrationBuilder.CreateTable(
                name: "Magazyny",
                columns: table => new
                {
                    MagazynId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazyny", x => x.MagazynId);
                });

            migrationBuilder.CreateTable(
                name: "Towary",
                columns: table => new
                {
                    TowarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towary", x => x.TowarId);
                });

            migrationBuilder.CreateTable(
                name: "DokumentyPrzyjecia",
                columns: table => new
                {
                    DokumentPrzyjeciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrzyjecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MagazynId = table.Column<int>(type: "int", nullable: false),
                    DostawcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DokumentyPrzyjecia", x => x.DokumentPrzyjeciaId);
                    table.ForeignKey(
                        name: "FK_DokumentyPrzyjecia_Dostawcy_DostawcaId",
                        column: x => x.DostawcaId,
                        principalTable: "Dostawcy",
                        principalColumn: "DostawcaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DokumentyPrzyjecia_Magazyny_MagazynId",
                        column: x => x.MagazynId,
                        principalTable: "Magazyny",
                        principalColumn: "MagazynId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DokumentPrzyjeciaEtykieta",
                columns: table => new
                {
                    DokumentyPrzyjeciaDokumentPrzyjeciaId = table.Column<int>(type: "int", nullable: false),
                    EtykietyEtykietaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DokumentPrzyjeciaEtykieta", x => new { x.DokumentyPrzyjeciaDokumentPrzyjeciaId, x.EtykietyEtykietaId });
                    table.ForeignKey(
                        name: "FK_DokumentPrzyjeciaEtykieta_DokumentyPrzyjecia_DokumentyPrzyjeciaDokumentPrzyjeciaId",
                        column: x => x.DokumentyPrzyjeciaDokumentPrzyjeciaId,
                        principalTable: "DokumentyPrzyjecia",
                        principalColumn: "DokumentPrzyjeciaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DokumentPrzyjeciaEtykieta_Etykiety_EtykietyEtykietaId",
                        column: x => x.EtykietyEtykietaId,
                        principalTable: "Etykiety",
                        principalColumn: "EtykietaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PozycjeTowaru",
                columns: table => new
                {
                    PozycjaTowaruId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TowarId = table.Column<int>(type: "int", nullable: false),
                    DokumentPrzyjeciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozycjeTowaru", x => x.PozycjaTowaruId);
                    table.ForeignKey(
                        name: "FK_PozycjeTowaru_DokumentyPrzyjecia_DokumentPrzyjeciaId",
                        column: x => x.DokumentPrzyjeciaId,
                        principalTable: "DokumentyPrzyjecia",
                        principalColumn: "DokumentPrzyjeciaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PozycjeTowaru_Towary_TowarId",
                        column: x => x.TowarId,
                        principalTable: "Towary",
                        principalColumn: "TowarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DokumentPrzyjeciaEtykieta_EtykietyEtykietaId",
                table: "DokumentPrzyjeciaEtykieta",
                column: "EtykietyEtykietaId");

            migrationBuilder.CreateIndex(
                name: "IX_DokumentyPrzyjecia_DostawcaId",
                table: "DokumentyPrzyjecia",
                column: "DostawcaId");

            migrationBuilder.CreateIndex(
                name: "IX_DokumentyPrzyjecia_MagazynId",
                table: "DokumentyPrzyjecia",
                column: "MagazynId");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjeTowaru_DokumentPrzyjeciaId",
                table: "PozycjeTowaru",
                column: "DokumentPrzyjeciaId");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjeTowaru_TowarId",
                table: "PozycjeTowaru",
                column: "TowarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DokumentPrzyjeciaEtykieta");

            migrationBuilder.DropTable(
                name: "PozycjeTowaru");

            migrationBuilder.DropTable(
                name: "Etykiety");

            migrationBuilder.DropTable(
                name: "DokumentyPrzyjecia");

            migrationBuilder.DropTable(
                name: "Towary");

            migrationBuilder.DropTable(
                name: "Dostawcy");

            migrationBuilder.DropTable(
                name: "Magazyny");
        }
    }
}
