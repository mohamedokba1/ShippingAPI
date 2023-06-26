using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class dateprivilege : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54773c11-9a1d-4a9f-a705-aa659f460519", "AQAAAAIAAYagAAAAEJ8DhtJzu8G3CqQnBVT5eBbIWiFAL4D0hCBSEchUo19byt4nNqLi1ajvwWz67Efv7g==", "df011e50-1512-4b76-b563-81263fede5ee" });
        }
    }
}
