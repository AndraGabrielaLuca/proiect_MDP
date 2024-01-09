using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect_MDP.Migrations
{
    public partial class ZborCategorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ZborCategorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZborID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZborCategorie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ZborCategorie_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZborCategorie_Zbor_ZborID",
                        column: x => x.ZborID,
                        principalTable: "Zbor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZborCategorie_CategorieID",
                table: "ZborCategorie",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_ZborCategorie_ZborID",
                table: "ZborCategorie",
                column: "ZborID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZborCategorie");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
