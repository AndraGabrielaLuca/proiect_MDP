using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect_MDP.Migrations
{
    public partial class Companie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Companie",
                table: "Zbor");

            migrationBuilder.AddColumn<int>(
                name: "CompanieID",
                table: "Zbor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zbor_CompanieID",
                table: "Zbor",
                column: "CompanieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zbor_Companie_CompanieID",
                table: "Zbor",
                column: "CompanieID",
                principalTable: "Companie",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zbor_Companie_CompanieID",
                table: "Zbor");

            migrationBuilder.DropTable(
                name: "Companie");

            migrationBuilder.DropIndex(
                name: "IX_Zbor_CompanieID",
                table: "Zbor");

            migrationBuilder.DropColumn(
                name: "CompanieID",
                table: "Zbor");

            migrationBuilder.AddColumn<string>(
                name: "Companie",
                table: "Zbor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
