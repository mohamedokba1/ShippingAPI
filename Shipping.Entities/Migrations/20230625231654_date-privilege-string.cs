using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class dateprivilegestring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "Date",
                value: new DateTime(2023, 6, 26, 1, 54, 26, 673, DateTimeKind.Local).AddTicks(9658));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "Date",
                value: new DateTime(2023, 6, 26, 1, 54, 26, 673, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "Date",
                value: new DateTime(2023, 6, 26, 1, 54, 26, 673, DateTimeKind.Local).AddTicks(9683));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "Date",
                value: new DateTime(2023, 6, 26, 1, 54, 26, 673, DateTimeKind.Local).AddTicks(9694));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4126469d-5a00-4552-99d7-80c9bb530ef9", "AQAAAAIAAYagAAAAEI/0DkhcbZ0UBDA8W6eY7pK0eLTMLVYEVwWrXiq6byT8+Y465O9sxL/D9mtijbkKqA==", "b0df4fdd-26d3-4d95-aa4d-40d9da45004f" });
        }
    }
}
