using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrocerioApi.Migrations
{
    public partial class imagesAndNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryImage",
                table: "Trackings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Trackings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreImage",
                table: "Trackings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryImage",
                table: "Purchases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Purchases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreImage",
                table: "Purchases",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    NotificationCategory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropColumn(
                name: "CategoryImage",
                table: "Trackings");

            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Trackings");

            migrationBuilder.DropColumn(
                name: "StoreImage",
                table: "Trackings");

            migrationBuilder.DropColumn(
                name: "CategoryImage",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "StoreImage",
                table: "Purchases");
        }
    }
}
