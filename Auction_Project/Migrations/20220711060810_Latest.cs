using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    public partial class Latest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1a678cf-d7a2-415a-9a8f-52d51e067e88",
                column: "ConcurrencyStamp",
                value: "c2b2ab98-7b03-4752-a296-767a7454c8c4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feadea3e-34b7-44a1-bafd-134749c706dc",
                column: "ConcurrencyStamp",
                value: "60092cb9-7e07-4ba3-8415-b8cd2a5dca78");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5d9114f-c911-49b4-af7c-137ce9488dd7",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13b0e106-9687-4c07-88a5-828f11a8ef62", new DateTime(2022, 7, 11, 6, 8, 10, 757, DateTimeKind.Utc).AddTicks(640), "AQAAAAEAACcQAAAAENF6vEsYXr459/kG1P14DESmLLAtBxYNJW+xdtN2MOK54odnoC3TyJvzLQmEW7I1Iw==", "f0df440b-49b1-49f9-b331-1f80664be229" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1a678cf-d7a2-415a-9a8f-52d51e067e88",
                column: "ConcurrencyStamp",
                value: "4582bff2-fed8-42fc-97f2-9e342412428c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feadea3e-34b7-44a1-bafd-134749c706dc",
                column: "ConcurrencyStamp",
                value: "6ed33473-b365-4a0e-bbe8-9b0ac3d44beb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5d9114f-c911-49b4-af7c-137ce9488dd7",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57dd2276-b325-41c5-a723-2bb2892148ee", new DateTime(2022, 7, 8, 12, 5, 20, 733, DateTimeKind.Utc).AddTicks(6476), "AQAAAAEAACcQAAAAEHX8AbrmpdtfoQtVrh8L1mCuC4qD6OR6BO3OAY+OiGzWn2BRlQ8OASrwQpdsPuJX8A==", "8d71602b-378d-4d59-aad2-a5ebe96f59ee" });
        }
    }
}
