using Microsoft.EntityFrameworkCore.Migrations;

namespace GrocerioApi.Migrations
{
    public partial class purchaseLogModifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "PurchaseLogs");

            migrationBuilder.DropColumn(
                name: "Stored",
                table: "PurchaseLogs");

            migrationBuilder.AddColumn<string>(
                name: "ReturnReason",
                table: "PurchaseLogs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Returned",
                table: "PurchaseLogs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Seriousness",
                table: "PurchaseLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StringSeriousness",
                table: "PurchaseLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnReason",
                table: "PurchaseLogs");

            migrationBuilder.DropColumn(
                name: "Returned",
                table: "PurchaseLogs");

            migrationBuilder.DropColumn(
                name: "Seriousness",
                table: "PurchaseLogs");

            migrationBuilder.DropColumn(
                name: "StringSeriousness",
                table: "PurchaseLogs");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "PurchaseLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Stored",
                table: "PurchaseLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
