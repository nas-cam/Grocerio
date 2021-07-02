using Microsoft.EntityFrameworkCore.Migrations;

namespace GrocerioApi.Migrations
{
    public partial class locationWork2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreCity",
                table: "Trackings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreCity",
                table: "Purchases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StoreCity",
                table: "Trackings");

            migrationBuilder.DropColumn(
                name: "StoreCity",
                table: "Purchases");
        }
    }
}
