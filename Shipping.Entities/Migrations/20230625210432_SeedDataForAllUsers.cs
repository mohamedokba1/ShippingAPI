using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForAllUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "Date",
                value: new DateTime(2023, 6, 26, 0, 4, 32, 39, DateTimeKind.Local).AddTicks(4347));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "Date",
                value: new DateTime(2023, 6, 26, 0, 4, 32, 39, DateTimeKind.Local).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "Date",
                value: new DateTime(2023, 6, 26, 0, 4, 32, 39, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "Date",
                value: new DateTime(2023, 6, 26, 0, 4, 32, 39, DateTimeKind.Local).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edc51b7a-755f-4e3a-bffd-7cad0ac896fa", "AQAAAAIAAYagAAAAEGwnAf3UkgmV5Lm1iIlhU6oK/0JcH/Lzc6ih2kC5Bhwh+YwrSSSzasByfdXgoFX3vw==", "c1d64d6b-31f2-44d1-8b9c-27cb425aeeda" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2", 0, "77601562-d6f9-498a-a4a0-fed366a8d653", "trader1@example.com", false, false, null, "TRADER1@EXAMPLE.COM", "TRADER1", "AQAAAAIAAYagAAAAEMidNcWYByzSVaXjLJjTwOVbYvrp//ezY2ncT0NW+my6w3Sr6RajxFRcB4mwoq+1Pg==", "01278555861", false, "6f839348-6e37-4c30-8e1e-0699568d65fe", false, "trader1" },
                    { "3", 0, "c7c4959a-7c73-49f6-99ff-9bca0d2beb4a", "employee1@example.com", false, false, null, "EMPLOYEE1@EXAMPLE.COM", "EMPLOYEE1", "AQAAAAIAAYagAAAAEHadq8P15jzm6pJghp5uQRbpDc9MD+OPUFm7nnB52qATZgltl+9ZA6PLsOYaU4uyqQ==", "01033325256", false, "574d58f1-739c-437e-ae9e-33b472a33dd0", false, "employee1" },
                    { "4", 0, "dffc6f0d-badb-4682-bc99-5a8f6e1a8c7b", "sales1@example.com", false, false, null, "SALES1@EXAMPLE.COM", "SALES1", "AQAAAAIAAYagAAAAEInVgH0MmiocVUmkKg/1mKSxoSmS/G4VLC/TsKhG6BFlSQ2sSgB3yae9/9rqAv0qnA==", "01033325256", false, "ed3057bb-f5f0-4eb4-97a4-8b553f51828f", false, "sales1" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedAt", "State" },
                values: new object[] { 1, "Cairo", new DateTime(2023, 6, 26, 0, 4, 32, 325, DateTimeKind.Local).AddTicks(6117), true });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "IsActive", "Name", "Password", "PhoneNumber", "UserId", "UserName", "branchid" },
                values: new object[] { 1L, "employee1@example.com", true, "Ahmed Mohamed", "Employee@123", "01033325256", "3", "employee1", 1 });

            migrationBuilder.InsertData(
                table: "SalesRepresentatives",
                columns: new[] { "SalesRepresentativeId", "Address", "CompanyPercentage", "DiscountType", "Email", "IsActive", "Name", "Password", "UserId", "UserName" },
                values: new object[] { 1L, "Cairo", 60.0, 1, "sales1@example.com", true, "Mohamed Khaled", "Sales@123", "4", "sales1" });

            migrationBuilder.InsertData(
                table: "Traders",
                columns: new[] { "TraderId", "Address", "CompanyBranch", "CostPerRefusedOrder", "Email", "PhoneNumber", "UserId", "UserName" },
                values: new object[] { 1L, "Cairo", "Cairo", 1.0, "trader1@example.com", "01278555861", "2", "trader1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "SalesRepresentatives",
                keyColumn: "SalesRepresentativeId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Traders",
                keyColumn: "TraderId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "Date",
                value: new DateTime(2023, 6, 24, 23, 42, 33, 422, DateTimeKind.Local).AddTicks(7107));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "Date",
                value: new DateTime(2023, 6, 24, 23, 42, 33, 422, DateTimeKind.Local).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "Date",
                value: new DateTime(2023, 6, 24, 23, 42, 33, 422, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "Date",
                value: new DateTime(2023, 6, 24, 23, 42, 33, 422, DateTimeKind.Local).AddTicks(7123));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cc2525f-ebea-431c-87ef-a0db23a1502c", "AQAAAAIAAYagAAAAEDOFk1KDrcI67B/n01RrBkGPlMaEbmjVSxeRRc25h3amNOoDSS3Cxy0PCRWKSGgZnA==", "e0741776-6dcb-4ced-9ae1-51f89e3a40fb" });
        }
    }
}
