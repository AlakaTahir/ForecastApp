using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forecast.Migrations.Migrations
{
    public partial class ForecastMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForecastInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MinimumTemperature = table.Column<double>(nullable: false),
                    MaximumTemperature = table.Column<double>(nullable: false),
                    RelativeHumidity = table.Column<double>(nullable: false),
                    Wind = table.Column<double>(nullable: false),
                    Pressure = table.Column<double>(nullable: false),
                    DefaultTemperatureSymbol = table.Column<string>(nullable: false),
                    WetBulb = table.Column<double>(nullable: false),
                    DryBulb = table.Column<double>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ForecastDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForecastInfos");
        }
    }
}
