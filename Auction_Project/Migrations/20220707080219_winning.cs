using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    public partial class winning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "winningBidId",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feadea3e-34b7-44a1-bafd-134749c706dc",
                column: "ConcurrencyStamp",
                value: "18667095-a5c2-43ef-b46c-c8e1660a53fc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5d9114f-c911-49b4-af7c-137ce9488dd7",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9665025-ed70-456a-a506-d4e8a3dddbf8", new DateTime(2022, 7, 7, 8, 2, 19, 597, DateTimeKind.Utc).AddTicks(1341), "AQAAAAEAACcQAAAAEL7aAJ3R0MYJYPxL8Ssd1O0GPcu1TQYoI8J6tvpT+scwcP9v0SDp5GMcmxkNFcHOmA==", "ac24e3de-da0f-4de9-970a-53472a6f8487" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "winningBidId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feadea3e-34b7-44a1-bafd-134749c706dc",
                column: "ConcurrencyStamp",
                value: "5a6257f4-670b-4114-8713-d23e8fc4b669");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5d9114f-c911-49b4-af7c-137ce9488dd7",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8140afb-a83d-4425-a174-b66ce7e42e8e", new DateTime(2022, 7, 6, 13, 35, 58, 275, DateTimeKind.Utc).AddTicks(8145), "AQAAAAEAACcQAAAAEAArOr77Gk3PXfJ5hD2qnp3Ni+Y9C2Z6/sr5Kek+PayJl8Xnj56It3aJQKqCoyiZyQ==", "e51b0cf6-1c57-4592-87d0-c2406bea0a49" });
        }
    }
}
