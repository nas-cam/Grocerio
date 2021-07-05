using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrocerioApi.Migrations
{
    public partial class PurchaseHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Store = table.Column<string>(nullable: true),
                    StoreAddress = table.Column<string>(nullable: true),
                    StoreCity = table.Column<string>(nullable: true),
                    Product = table.Column<string>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    ProductType = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    ShippingAddress = table.Column<string>(nullable: true),
                    PaymentIdentifier = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    ArrivedAt = table.Column<DateTime>(nullable: false),
                    OriginalPurchaseId = table.Column<int>(nullable: false),
                    Stored = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseHistory");
        }
    }
}
