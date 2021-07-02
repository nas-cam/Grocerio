using Microsoft.EntityFrameworkCore.Migrations;

namespace GrocerioApi.Migrations
{
    public partial class shippingAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "Trackings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "Trackings");
        }
    }
}
