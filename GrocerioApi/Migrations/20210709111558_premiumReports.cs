using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrocerioApi.Migrations
{
    public partial class premiumReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PremiumReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(nullable: false),
                    ReportName = table.Column<string>(nullable: true),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    Revenue = table.Column<double>(nullable: false),
                    ProductsSold = table.Column<int>(nullable: false),
                    ProductsReturned = table.Column<int>(nullable: false),
                    CurrentCartEntries = table.Column<int>(nullable: false),
                    CurrentTrackingEntries = table.Column<int>(nullable: false),
                    TopProduct = table.Column<string>(nullable: true),
                    MainReturnReason = table.Column<string>(nullable: true),
                    SuccessRate = table.Column<double>(nullable: false),
                    MostPopularClientAddress = table.Column<string>(nullable: true),
                    MostPopularCategory = table.Column<string>(nullable: true),
                    MostPopularProductType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiumReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PremiumReports_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PremiumReports_StoreId",
                table: "PremiumReports",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PremiumReports");
        }
    }
}
