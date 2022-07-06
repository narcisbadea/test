using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    public partial class seed_superuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feadea3e-34b7-44a1-bafd-134749c706dc",
                column: "ConcurrencyStamp",
                value: "5a6257f4-670b-4114-8713-d23e8fc4b669");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "feadea3e-34b7-44a1-bafd-134749c706dc", "b5d9114f-c911-49b4-af7c-137ce9488dd7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5d9114f-c911-49b4-af7c-137ce9488dd7",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8140afb-a83d-4425-a174-b66ce7e42e8e", new DateTime(2022, 7, 6, 13, 35, 58, 275, DateTimeKind.Utc).AddTicks(8145), "AQAAAAEAACcQAAAAEAArOr77Gk3PXfJ5hD2qnp3Ni+Y9C2Z6/sr5Kek+PayJl8Xnj56It3aJQKqCoyiZyQ==", "e51b0cf6-1c57-4592-87d0-c2406bea0a49" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "feadea3e-34b7-44a1-bafd-134749c706dc", "b5d9114f-c911-49b4-af7c-137ce9488dd7" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feadea3e-34b7-44a1-bafd-134749c706dc",
                column: "ConcurrencyStamp",
                value: "c08829af-eb5d-4c4e-aefd-447760197cd0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5d9114f-c911-49b4-af7c-137ce9488dd7",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c917586-6751-42b4-bacf-f2f7a1d93b2c", new DateTime(2022, 7, 6, 13, 34, 9, 275, DateTimeKind.Utc).AddTicks(167), "AQAAAAEAACcQAAAAELCuOynOnoKgAX63MMwQdxhDeVCMsjDGc5VFVoEUYLRlwTVHJTj2zO/K+uzt4DWUuA==", "3e2e6a2b-079a-4bf8-8d0e-18e00a864593" });
        }
    }
}
