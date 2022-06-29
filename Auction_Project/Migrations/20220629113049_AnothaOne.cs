using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    public partial class AnothaOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsForApproval_Items_ItemId",
                table: "ItemsForApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsForApproval_Users_UserId",
                table: "ItemsForApproval");

            migrationBuilder.DropIndex(
                name: "IX_ItemsForApproval_ItemId",
                table: "ItemsForApproval");

            migrationBuilder.DropIndex(
                name: "IX_ItemsForApproval_UserId",
                table: "ItemsForApproval");

            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "ItemsForApproval");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemsForApproval");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ItemsForApproval");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "ItemsForApproval",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "ItemsForApproval",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImagesAddress",
                table: "ItemsForApproval",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                table: "ItemsForApproval",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ItemsForApproval",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Items",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "ItemsForApproval");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "ItemsForApproval");

            migrationBuilder.DropColumn(
                name: "ImagesAddress",
                table: "ItemsForApproval");

            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "ItemsForApproval");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ItemsForApproval");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "Items");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentPrice",
                table: "ItemsForApproval",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ItemsForApproval",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ItemsForApproval",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsForApproval_ItemId",
                table: "ItemsForApproval",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsForApproval_UserId",
                table: "ItemsForApproval",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsForApproval_Items_ItemId",
                table: "ItemsForApproval",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsForApproval_Users_UserId",
                table: "ItemsForApproval",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
