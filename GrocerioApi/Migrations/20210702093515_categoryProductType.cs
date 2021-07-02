using Microsoft.EntityFrameworkCore.Migrations;

namespace GrocerioApi.Migrations
{
    public partial class categoryProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Trackings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Trackings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Trackings");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Trackings");
        }
    }
}
