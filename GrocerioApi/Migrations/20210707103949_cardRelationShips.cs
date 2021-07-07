using Microsoft.EntityFrameworkCore.Migrations;

namespace GrocerioApi.Migrations
{
    public partial class cardRelationShips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "Trackings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "Purchases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "CreditCards",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Trackings_CreditCardId",
                table: "Trackings",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CreditCardId",
                table: "Purchases",
                column: "CreditCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_CreditCards_CreditCardId",
                table: "Purchases",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Trackings_CreditCards_CreditCardId",
                table: "Trackings",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_CreditCards_CreditCardId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Trackings_CreditCards_CreditCardId",
                table: "Trackings");

            migrationBuilder.DropIndex(
                name: "IX_Trackings_CreditCardId",
                table: "Trackings");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_CreditCardId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "Trackings");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "CreditCards");
        }
    }
}
