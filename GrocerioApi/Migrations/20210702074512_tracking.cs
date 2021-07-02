using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrocerioApi.Migrations
{
    public partial class tracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trackings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Store = table.Column<string>(nullable: true),
                    Product = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    DaysLeft = table.Column<int>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trackings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trackings");
        }
    }
}
