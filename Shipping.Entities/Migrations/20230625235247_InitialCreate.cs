using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goverment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Village = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Goverments",
                columns: table => new
                {
                    Goverment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovermentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goverments", x => x.Goverment_Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesRepresentatives",
                columns: table => new
                {
                    SalesRepresentativeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyPercentage = table.Column<double>(type: "float", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRepresentatives", x => x.SalesRepresentativeId);
                    table.ForeignKey(
                        name: "FK_SalesRepresentatives_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Traders",
                columns: table => new
                {
                    TraderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostPerRefusedOrder = table.Column<double>(type: "float", nullable: false),
                    CompanyBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traders", x => x.TraderId);
                    table.ForeignKey(
                        name: "FK_Traders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    branchid = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Branches_branchid",
                        column: x => x.branchid,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    City_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalShippingCost = table.Column<double>(type: "float", nullable: false),
                    PickupShippingCost = table.Column<double>(type: "float", nullable: false),
                    GovermentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.City_Id);
                    table.ForeignKey(
                        name: "FK_Cities_Goverments_GovermentId",
                        column: x => x.GovermentId,
                        principalTable: "Goverments",
                        principalColumn: "Goverment_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchSalesRepresentative",
                columns: table => new
                {
                    BranchesId = table.Column<int>(type: "int", nullable: false),
                    SalesRepresentativesSalesRepresentativeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchSalesRepresentative", x => new { x.BranchesId, x.SalesRepresentativesSalesRepresentativeId });
                    table.ForeignKey(
                        name: "FK_BranchSalesRepresentative_Branches_BranchesId",
                        column: x => x.BranchesId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchSalesRepresentative_SalesRepresentatives_SalesRepresentativesSalesRepresentativeId",
                        column: x => x.SalesRepresentativesSalesRepresentativeId,
                        principalTable: "SalesRepresentatives",
                        principalColumn: "SalesRepresentativeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GovermentSalesRepresentative",
                columns: table => new
                {
                    GovermentsGoverment_Id = table.Column<int>(type: "int", nullable: false),
                    SalesRepresentativesSalesRepresentativeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovermentSalesRepresentative", x => new { x.GovermentsGoverment_Id, x.SalesRepresentativesSalesRepresentativeId });
                    table.ForeignKey(
                        name: "FK_GovermentSalesRepresentative_Goverments_GovermentsGoverment_Id",
                        column: x => x.GovermentsGoverment_Id,
                        principalTable: "Goverments",
                        principalColumn: "Goverment_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GovermentSalesRepresentative_SalesRepresentatives_SalesRepresentativesSalesRepresentativeId",
                        column: x => x.SalesRepresentativesSalesRepresentativeId,
                        principalTable: "SalesRepresentatives",
                        principalColumn: "SalesRepresentativeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExtraWeightCost = table.Column<double>(type: "float", nullable: false),
                    CompanyBranch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Government = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingType = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    TotalWeight = table.Column<int>(type: "int", nullable: false),
                    DeliveredToVillage = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    TraderId = table.Column<long>(type: "bigint", nullable: true),
                    SalesRepresentativeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Orders_SalesRepresentatives_SalesRepresentativeId",
                        column: x => x.SalesRepresentativeId,
                        principalTable: "SalesRepresentatives",
                        principalColumn: "SalesRepresentativeId");
                    table.ForeignKey(
                        name: "FK_Orders_Traders_TraderId",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "TraderId");
                });

            migrationBuilder.CreateTable(
                name: "SpecialPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingCost = table.Column<double>(type: "float", nullable: false),
                    Goverment_Id = table.Column<int>(type: "int", nullable: true),
                    City_Id = table.Column<int>(type: "int", nullable: true),
                    TraderId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialPackages_Cities_City_Id",
                        column: x => x.City_Id,
                        principalTable: "Cities",
                        principalColumn: "City_Id");
                    table.ForeignKey(
                        name: "FK_SpecialPackages_Goverments_Goverment_Id",
                        column: x => x.Goverment_Id,
                        principalTable: "Goverments",
                        principalColumn: "Goverment_Id");
                    table.ForeignKey(
                        name: "FK_SpecialPackages_Traders_TraderId",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "TraderId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_Id);
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Date", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "6/26/2023 2:52:46 AM", "admin", "ADMIN" },
                    { "2", null, "6/26/2023 2:52:46 AM", "trader", "TRADER" },
                    { "3", null, "6/26/2023 2:52:46 AM", "employee", "EMPLOYEE" },
                    { "4", null, "6/26/2023 2:52:46 AM", "salesrepresentative", "SALESREPRESENTATIVE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "f6c8acb1-7e7d-4d9a-a7a9-346b27ad0f8b", "Admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEGafl+tGxCha7aNve8EFDHE/02oGmo6D2dZUXCcHWrX5ZY/mGJtfyFuurJ7BLu4oVg==", "01234567890", false, "569b396d-acd4-40af-b856-addf61483d1f", false, "Admin" },
                    { "2", 0, "53bdf592-3239-4262-b407-00485609805e", "trader1@example.com", false, false, null, "TRADER1@EXAMPLE.COM", "TRADER1", "AQAAAAIAAYagAAAAEEUUkX54bBF4d9ydnd+MS5dpRBSgGbFiji8sxd7unsSS5jIa8lySQIjWmBd/gZnqiA==", "01278555861", false, "65bb88ed-27ce-455d-8f25-6ead14c3263b", false, "trader1" },
                    { "3", 0, "09f39ff3-6a29-409c-9dc5-880adeaf58e3", "employee1@example.com", false, false, null, "EMPLOYEE1@EXAMPLE.COM", "EMPLOYEE1", "AQAAAAIAAYagAAAAENe1uCYhXXDNjW9nJV9gQB/BB0IYRbKo9G4bVAZjvLM47JB/4P3Un/hQ6yFukrhDkw==", "01033325256", false, "8fedb014-53e8-45a2-8f1c-740468e1a939", false, "employee1" },
                    { "4", 0, "6c4c37cd-7e96-403f-b9e8-0abc0660d17c", "sales1@example.com", false, false, null, "SALES1@EXAMPLE.COM", "SALES1", "AQAAAAIAAYagAAAAEMKarBObMAdH3nA6Y0vtgA6Xj8y0T9JHaM0rAZ7BDAK5UPhNQp+XJ5B8UQAgL2E2/A==", "01033325256", false, "d5111de0-1923-4ba8-9b77-7e6dfe2dcd86", false, "sales1" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedAt", "State" },
                values: new object[] { 1, "Cairo", new DateTime(2023, 6, 26, 2, 52, 47, 101, DateTimeKind.Local).AddTicks(3956), true });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "permission.goverments.add", "true", "1" },
                    { 2, "permission.goverments.update", "true", "1" },
                    { 3, "permission.goverments.delete", "true", "1" },
                    { 4, "permission.goverments.read", "true", "1" },
                    { 5, "permission.cities.add", "true", "1" },
                    { 6, "permission.cities.update", "true", "1" },
                    { 7, "permission.cities.delete", "true", "1" },
                    { 8, "permission.cities.read", "true", "1" },
                    { 9, "permission.traders.add", "true", "1" },
                    { 10, "permission.traders.delete", "true", "1" },
                    { 11, "permission.traders.update", "true", "1" },
                    { 12, "permission.traders.read", "true", "1" },
                    { 13, "permission.employees.add", "true", "1" },
                    { 14, "permission.employees.delete", "true", "1" },
                    { 15, "permission.employees.update", "true", "1" },
                    { 16, "permission.employees.read", "true", "1" },
                    { 17, "permission.branches.add", "true", "1" },
                    { 18, "permission.branches.delete", "true", "1" },
                    { 19, "permission.branches.update", "true", "1" },
                    { 20, "permission.branches.read", "true", "1" },
                    { 21, "permission.sales.add", "true", "1" },
                    { 22, "permission.sales.update", "true", "1" },
                    { 23, "permission.sales.delete", "true", "1" },
                    { 24, "permission.sales.read", "true", "1" },
                    { 25, "permission.orders.add", "true", "1" },
                    { 26, "permission.orders.update", "true", "1" },
                    { 27, "permission.orders.delete", "true", "1" },
                    { 28, "permission.orders.read", "true", "1" },
                    { 29, "permission.orders.add", "true", "2" },
                    { 30, "permission.orders.update", "true", "2" },
                    { 31, "permission.orders.delete", "true", "2" },
                    { 32, "permission.orders.read", "true", "2" },
                    { 33, "permission.orders.update", "true", "3" },
                    { 34, "permission.orders.read", "true", "3" },
                    { 35, "permission.branches.read", "true", "3" },
                    { 36, "permission.cities.read", "true", "3" },
                    { 37, "permission.cities.update", "true", "3" },
                    { 38, "permission.cities.add", "true", "3" },
                    { 39, "permission.goverments.read", "true", "3" },
                    { 40, "permission.goverments.update", "true", "3" },
                    { 41, "permission.goverments.add", "true", "3" },
                    { 42, "permission.orders.update", "true", "4" },
                    { 43, "permission.orders.read", "true", "4" },
                    { 44, "permission.branches.read", "true", "4" },
                    { 45, "permission.cities.read", "true", "4" },
                    { 46, "permission.goverments.read", "true", "4" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "3", "3" },
                    { "4", "4" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BranchSalesRepresentative_SalesRepresentativesSalesRepresentativeId",
                table: "BranchSalesRepresentative",
                column: "SalesRepresentativesSalesRepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_GovermentId",
                table: "Cities",
                column: "GovermentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_branchid",
                table: "Employees",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GovermentSalesRepresentative_SalesRepresentativesSalesRepresentativeId",
                table: "GovermentSalesRepresentative",
                column: "SalesRepresentativesSalesRepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SalesRepresentativeId",
                table: "Orders",
                column: "SalesRepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TraderId",
                table: "Orders",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRepresentatives_UserId",
                table: "SalesRepresentatives",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPackages_City_Id",
                table: "SpecialPackages",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPackages_Goverment_Id",
                table: "SpecialPackages",
                column: "Goverment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPackages_TraderId",
                table: "SpecialPackages",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_Traders_UserId",
                table: "Traders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BranchSalesRepresentative");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "GovermentSalesRepresentative");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SpecialPackages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SalesRepresentatives");

            migrationBuilder.DropTable(
                name: "Traders");

            migrationBuilder.DropTable(
                name: "Goverments");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
