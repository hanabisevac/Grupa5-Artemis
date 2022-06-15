using Microsoft.EntityFrameworkCore.Migrations;

namespace GoldenLilies.Data.Migrations
{
    public partial class drugaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropForeignKey(
                name: "FK_Prijavljeni_Atrakcija_atrakcijaID",
                table: "Prijavljeni");

            migrationBuilder.RenameColumn(
                name: "atrakcijaID",
                table: "Prijavljeni",
                newName: "korisnikID");

            /*migrationBuilder.RenameIndex(
                name: "IX_Prijavljeni_atrakcijaID",
                table: "Prijavljeni",
                newName: "IX_Prijavljeni_korisnikID");*/

            migrationBuilder.AddForeignKey(
                name: "FK_Prijavljeni_Korisnik_korisnikID",
                table: "Prijavljeni",
                column: "korisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prijavljeni_Korisnik_korisnikID",
                table: "Prijavljeni");

            migrationBuilder.RenameColumn(
                name: "korisnikID",
                table: "Prijavljeni",
                newName: "atrakcijaID");

            migrationBuilder.RenameIndex(
                name: "IX_Prijavljeni_korisnikID",
                table: "Prijavljeni",
                newName: "IX_Prijavljeni_atrakcijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prijavljeni_Atrakcija_atrakcijaID",
                table: "Prijavljeni",
                column: "atrakcijaID",
                principalTable: "Atrakcija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
