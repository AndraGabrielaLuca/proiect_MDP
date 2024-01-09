using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect_MDP.Migrations
{
    public partial class Rezervare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilizator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bilet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizatorID = table.Column<int>(type: "int", nullable: true),
                    ZborID = table.Column<int>(type: "int", nullable: true),
                    PlecareDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bilet_Utilizator_UtilizatorID",
                        column: x => x.UtilizatorID,
                        principalTable: "Utilizator",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Bilet_Zbor_ZborID",
                        column: x => x.ZborID,
                        principalTable: "Zbor",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_UtilizatorID",
                table: "Bilet",
                column: "UtilizatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_ZborID",
                table: "Bilet",
                column: "ZborID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilet");

            migrationBuilder.DropTable(
                name: "Utilizator");
        }
    }
}
