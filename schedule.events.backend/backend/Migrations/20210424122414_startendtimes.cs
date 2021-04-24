using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class startendtimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ends",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Starts",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ends",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Starts",
                table: "Posts");
        }
    }
}
