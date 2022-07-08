using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc14d44e-1e5e-4c92-aa04-8208242fdbcf", "b5d9114f-c911-49b4-af7c-137ce9488dd7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc14d44e-1e5e-4c92-aa04-8208242fdbcf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feadea3e-34b7-44a1-bafd-134749c706dc",
                column: "ConcurrencyStamp",
                value: "d842937d-014c-4566-a438-98ec7f997d5c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1a678cf-d7a2-415a-9a8f-52d51e067e88", "fd2ac5f1-d870-4e1f-b3b0-5c5bbf564f30", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5d9114f-c911-49b4-af7c-137ce9488dd7",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4ead0d5-0baa-42e5-ab09-473c58ffdab1", new DateTime(2022, 7, 7, 10, 53, 34, 413, DateTimeKind.Utc).AddTicks(7440), "AQAAAAEAACcQAAAAELZpc7wA8gAnNzjN/BE/YsS1K/wuXfJqRKAKwChM4Ms7FeS45TD3jlfZu1+hizRNyw==", "32e8b4fa-033f-4f16-bb3e-24b3ec999c3f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b1a678cf-d7a2-415a-9a8f-52d51e067e88", "b5d9114f-c911-49b4-af7c-137ce9488dd7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b1a678cf-d7a2-415a-9a8f-52d51e067e88", "b5d9114f-c911-49b4-af7c-137ce9488dd7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1a678cf-d7a2-415a-9a8f-52d51e067e88");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feadea3e-34b7-44a1-bafd-134749c706dc",
                column: "ConcurrencyStamp",
                value: "5a7e15bd-6de8-450e-b2e7-627654cad0f0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc14d44e-1e5e-4c92-aa04-8208242fdbcf", "a94b4ce9-85b3-4ed5-ab88-68e57c7bdb78", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5d9114f-c911-49b4-af7c-137ce9488dd7",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d66dd33-990c-4893-a75c-76a2f407142e", new DateTime(2022, 7, 7, 10, 50, 26, 124, DateTimeKind.Utc).AddTicks(7903), "AQAAAAEAACcQAAAAEGPAXa6+j8FBDZ63N/FAjj0KGLIHIDVoREZuujrYIqMih+8qoVoAjR1DwUe++jeJYA==", "358ca53c-41ca-4eba-a5b4-b2d261875f05" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fc14d44e-1e5e-4c92-aa04-8208242fdbcf", "b5d9114f-c911-49b4-af7c-137ce9488dd7" });
        }
    }
}
