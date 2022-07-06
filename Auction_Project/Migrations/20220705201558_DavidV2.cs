using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    public partial class DavidV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_winningBidId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_winningBidId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "winningBidId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "winningBidId",
                table: "Items",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_winningBidId",
                table: "Items",
                column: "winningBidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_winningBidId",
                table: "Items",
                column: "winningBidId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
