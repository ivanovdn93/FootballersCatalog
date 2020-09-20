using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballersCatalog.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Footballers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Surname = table.Column<string>(maxLength: 100, nullable: true),
                    Gender = table.Column<byte>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    TeamName = table.Column<string>(maxLength: 100, nullable: false),
                    Country = table.Column<byte>(nullable: false),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footballers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Footballers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Footballers_TeamId",
                table: "Footballers",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Footballers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
