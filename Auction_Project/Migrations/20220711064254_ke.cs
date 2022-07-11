using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    public partial class ke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1a678cf-d7a2-415a-9a8f-52d51e067e88",
                column: "ConcurrencyStamp",
                value: "8e327fb5-240a-4836-86db-06057410f1d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feadea3e-34b7-44a1-bafd-134749c706dc",
                column: "ConcurrencyStamp",
                value: "0eafcbc8-dc26-4a7e-86ba-dd2af8cabcf3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5d9114f-c911-49b4-af7c-137ce9488dd7",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17e7dbaf-f7fb-4094-9aa2-e410e6c02961", new DateTime(2022, 7, 11, 6, 42, 54, 270, DateTimeKind.Utc).AddTicks(5181), "AQAAAAEAACcQAAAAEKrqUVgMlO1H+/Pzk+mWiYj0ry/wSc6+IIQXCft5RyYaPx1x6vmzd7sMowKcI/h1mA==", "2d1c143b-dc54-4b8f-9737-db53afa86e4a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
