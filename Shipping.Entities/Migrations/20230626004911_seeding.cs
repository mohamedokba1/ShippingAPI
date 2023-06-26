using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 47, "permission.permissions.read", "true", "1" },
                    { 48, "permission.permissions.update", "true", "1" },
                    { 49, "permission.permissions.add", "true", "1" },
                    { 50, "permission.permissions.delete", "true", "1" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "Date",
                value: "6/26/2023 3:49:11 AM");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "Date",
                value: "6/26/2023 3:49:11 AM");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "Date",
                value: "6/26/2023 3:49:11 AM");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "Date",
                value: "6/26/2023 3:49:11 AM");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99bcbc7a-3ea7-4335-9630-c5ac913d9e6a", "AQAAAAIAAYagAAAAEL/WjhIkKkrollWf+sjRQFzy3XswFN7wEVqHPOQnEyFfutOc5oeAJ/wlGC+PR1rTbw==", "f1fa5c4c-6811-4505-a324-02f8f58f3e82" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "Date",
                value: "6/26/2023 2:16:54 AM");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "Date",
                value: "6/26/2023 2:16:54 AM");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "Date",
                value: "6/26/2023 2:16:54 AM");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "Date",
                value: "6/26/2023 2:16:54 AM");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50537c0a-97c4-4b57-890c-aafb8142cf14", "AQAAAAIAAYagAAAAEO3OgP8/bvG9jPHQnmAy64tTjkzNoeYGZ7ddjmDxuvEPphlqEtM5/TXCee1D4rzIKg==", "a849bff8-8561-4fcc-8cd9-8ed08956521f" });
        }
    }
}
