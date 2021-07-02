using Microsoft.EntityFrameworkCore.Migrations;

namespace GrocerioApi.Migrations
{
    public partial class ProductDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                table: "Trackings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductDescription",
                table: "Trackings");
        }
    }
}
