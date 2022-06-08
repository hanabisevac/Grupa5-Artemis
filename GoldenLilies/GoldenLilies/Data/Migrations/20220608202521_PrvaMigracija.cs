using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoldenLilies.Data.Migrations
{
    public partial class PrvaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    drzava = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    informacija = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VrstaAtrakcije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaAtrakcije", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VrstaKorisnika",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaKorisnika", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Atrakcija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lokacijaID = table.Column<int>(type: "int", nullable: false),
                    vrstaAtrakcijeID = table.Column<int>(type: "int", nullable: false),
                    informacije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    radnoVrijeme = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atrakcija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Atrakcija_Lokacija_lokacijaID",
                        column: x => x.lokacijaID,
                        principalTable: "Lokacija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atrakcija_VrstaAtrakcije_vrstaAtrakcijeID",
                        column: x => x.vrstaAtrakcijeID,
                        principalTable: "VrstaAtrakcije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adresaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lokacijaID = table.Column<int>(type: "int", nullable: true),
                    telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aspNetUsersID = table.Column<int>(type: "int", nullable: false),
                    vrstaKorisnikaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Lokacija_lokacijaID",
                        column: x => x.lokacijaID,
                        principalTable: "Lokacija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Korisnik_VrstaKorisnika_vrstaKorisnikaID",
                        column: x => x.vrstaKorisnikaID,
                        principalTable: "VrstaKorisnika",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fotografija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    putanja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    korisnikID = table.Column<int>(type: "int", nullable: false),
                    atrakcijaID = table.Column<int>(type: "int", nullable: false),
                    verifikovano = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fotografija_Atrakcija_atrakcijaID",
                        column: x => x.atrakcijaID,
                        principalTable: "Atrakcija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fotografija_Korisnik_korisnikID",
                        column: x => x.korisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posjete",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnikID = table.Column<int>(type: "int", nullable: false),
                    atrakcijaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posjete", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Posjete_Atrakcija_atrakcijaID",
                        column: x => x.atrakcijaID,
                        principalTable: "Atrakcija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posjete_Korisnik_korisnikID",
                        column: x => x.korisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tura",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vodicID = table.Column<int>(type: "int", nullable: false),
                    vrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    informacije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    korisnikID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tura", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tura_Korisnik_korisnikID",
                        column: x => x.korisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtrakcijeTure",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    atrakcijaID = table.Column<int>(type: "int", nullable: false),
                    turaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtrakcijeTure", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AtrakcijeTure_Atrakcija_atrakcijaID",
                        column: x => x.atrakcijaID,
                        principalTable: "Atrakcija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtrakcijeTure_Tura_turaID",
                        column: x => x.turaID,
                        principalTable: "Tura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prijavljeni",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    atrakcijaID = table.Column<int>(type: "int", nullable: false),
                    turaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prijavljeni", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prijavljeni_Atrakcija_atrakcijaID",
                        column: x => x.atrakcijaID,
                        principalTable: "Atrakcija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prijavljeni_Tura_turaID",
                        column: x => x.turaID,
                        principalTable: "Tura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atrakcija_lokacijaID",
                table: "Atrakcija",
                column: "lokacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Atrakcija_vrstaAtrakcijeID",
                table: "Atrakcija",
                column: "vrstaAtrakcijeID");

            migrationBuilder.CreateIndex(
                name: "IX_AtrakcijeTure_atrakcijaID",
                table: "AtrakcijeTure",
                column: "atrakcijaID");

            migrationBuilder.CreateIndex(
                name: "IX_AtrakcijeTure_turaID",
                table: "AtrakcijeTure",
                column: "turaID");

            migrationBuilder.CreateIndex(
                name: "IX_Fotografija_atrakcijaID",
                table: "Fotografija",
                column: "atrakcijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Fotografija_korisnikID",
                table: "Fotografija",
                column: "korisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_lokacijaID",
                table: "Korisnik",
                column: "lokacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_vrstaKorisnikaID",
                table: "Korisnik",
                column: "vrstaKorisnikaID");

            migrationBuilder.CreateIndex(
                name: "IX_Posjete_atrakcijaID",
                table: "Posjete",
                column: "atrakcijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Posjete_korisnikID",
                table: "Posjete",
                column: "korisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Prijavljeni_atrakcijaID",
                table: "Prijavljeni",
                column: "atrakcijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Prijavljeni_turaID",
                table: "Prijavljeni",
                column: "turaID");

            migrationBuilder.CreateIndex(
                name: "IX_Tura_korisnikID",
                table: "Tura",
                column: "korisnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtrakcijeTure");

            migrationBuilder.DropTable(
                name: "Fotografija");

            migrationBuilder.DropTable(
                name: "Posjete");

            migrationBuilder.DropTable(
                name: "Prijavljeni");

            migrationBuilder.DropTable(
                name: "Atrakcija");

            migrationBuilder.DropTable(
                name: "Tura");

            migrationBuilder.DropTable(
                name: "VrstaAtrakcije");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "VrstaKorisnika");
        }
    }
}
