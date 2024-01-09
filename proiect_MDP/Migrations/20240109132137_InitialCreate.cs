using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect_MDP.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zbor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destinatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Companie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zbor", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zbor");
        }
    }
}
