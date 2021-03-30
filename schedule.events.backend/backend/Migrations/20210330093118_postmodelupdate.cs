using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class postmodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Posts");
        }
    }
}
