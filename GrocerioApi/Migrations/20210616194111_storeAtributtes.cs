using Microsoft.EntityFrameworkCore.Migrations;

namespace GrocerioApi.Migrations
{
    public partial class storeAtributtes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Membership",
                table: "Stores",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Membership",
                table: "Stores");
        }
    }
}
