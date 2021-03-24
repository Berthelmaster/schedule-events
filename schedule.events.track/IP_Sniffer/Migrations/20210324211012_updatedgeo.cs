using Microsoft.EntityFrameworkCore.Migrations;

namespace IP_Sniffer.Migrations
{
    public partial class updatedgeo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "As",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "City",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Isp",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Org",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Query",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "RegionName",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "GeoLocations");

            migrationBuilder.AddColumn<string>(
                name: "Continent_code",
                table: "GeoLocations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Country_area",
                table: "GeoLocations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Country_calling_code",
                table: "GeoLocations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country_capital",
                table: "GeoLocations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country_code",
                table: "GeoLocations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country_name",
                table: "GeoLocations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Country_population",
                table: "GeoLocations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "GeoLocations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "GeoLocations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Languages",
                table: "GeoLocations",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "GeoLocations",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "GeoLocations",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Postal",
                table: "GeoLocations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Continent_code",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Country_area",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Country_calling_code",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Country_capital",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Country_code",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Country_name",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Country_population",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Ip",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Languages",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "Postal",
                table: "GeoLocations");

            migrationBuilder.AddColumn<string>(
                name: "As",
                table: "GeoLocations",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "GeoLocations",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "GeoLocations",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Isp",
                table: "GeoLocations",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Lat",
                table: "GeoLocations",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Lon",
                table: "GeoLocations",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Org",
                table: "GeoLocations",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Query",
                table: "GeoLocations",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionName",
                table: "GeoLocations",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "GeoLocations",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
