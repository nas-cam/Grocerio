using Microsoft.EntityFrameworkCore.Migrations;

namespace GrocerioApi.Migrations
{
    public partial class storeAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StoreAddress",
                table: "Trackings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreAddress",
                table: "Trackings");
        }
    }
}
