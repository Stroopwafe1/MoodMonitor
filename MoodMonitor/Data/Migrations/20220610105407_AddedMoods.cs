using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodMonitor.Data.Migrations
{
    public partial class AddedMoods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Happiness = table.Column<int>(type: "INTEGER", nullable: false),
                    Sadness = table.Column<int>(type: "INTEGER", nullable: false),
                    Fear = table.Column<int>(type: "INTEGER", nullable: false),
                    Anger = table.Column<int>(type: "INTEGER", nullable: false),
                    Stress = table.Column<int>(type: "INTEGER", nullable: false),
                    Emptiness = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "datetime()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moods", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moods");
        }
    }
}
