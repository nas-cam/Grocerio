using Microsoft.EntityFrameworkCore.Migrations;

namespace GrocerioApi.Migrations
{
    public partial class userTrackingRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Trackings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trackings_UserId",
                table: "Trackings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trackings_Users_UserId",
                table: "Trackings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trackings_Users_UserId",
                table: "Trackings");

            migrationBuilder.DropIndex(
                name: "IX_Trackings_UserId",
                table: "Trackings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trackings");
        }
    }
}
