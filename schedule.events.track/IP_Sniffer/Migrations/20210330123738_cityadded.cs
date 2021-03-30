using Microsoft.EntityFrameworkCore.Migrations;

namespace IP_Sniffer.Migrations
{
    public partial class cityadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "GeoLocations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "GeoLocations");
        }
    }
}
