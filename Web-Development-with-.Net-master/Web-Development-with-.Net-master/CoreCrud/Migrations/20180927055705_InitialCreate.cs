using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCrud.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country_name = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Population = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Athlete",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    athlete_name = table.Column<string>(maxLength: 100, nullable: false),
                    game_start_time = table.Column<DateTime>(nullable: false),
                    game_end_time = table.Column<DateTime>(nullable: true),
                    win = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athlete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Athlete_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Athlete_CountryId",
                table: "Athlete",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Athlete");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
