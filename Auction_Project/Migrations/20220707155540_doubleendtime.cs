using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    public partial class doubleendtime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "endTime",
                table: "Items",
                newName: "EndTime");

            migrationBuilder.AlterColumn<double>(
                name: "EndTime",
                table: "Items",
                type: "float",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feadea3e-34b7-44a1-bafd-134749c706dc",
                column: "ConcurrencyStamp",
                value: "d35bbeb6-d425-410a-9c44-001bca3fbf0c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5d9114f-c911-49b4-af7c-137ce9488dd7",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87c42c70-6821-4f1e-b67b-23909fe657d7", new DateTime(2022, 7, 7, 15, 55, 39, 696, DateTimeKind.Utc).AddTicks(2843), "AQAAAAEAACcQAAAAEPNTLoZG9hmsRKp2RZRmfWhFkR7tXwSXcTMvuy4GqjD6l1cQeOOufaBIhS19oOJGBw==", "8f020c23-2050-44dd-8cca-f4ec0ad27795" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Items",
                newName: "endTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "endTime",
                table: "Items",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
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
    }
}
