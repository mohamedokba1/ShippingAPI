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
                    BranchId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Employees_Branches_BranchId",
                        column: x => x.BranchId,
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
                    { "1", null, "6/26/2023 5:09:51 AM", "admin", "ADMIN" },
                    { "2", null, "6/26/2023 5:09:51 AM", "trader", "TRADER" },
                    { "3", null, "6/26/2023 5:09:51 AM", "employee", "EMPLOYEE" },
                    { "4", null, "6/26/2023 5:09:51 AM", "salesrepresentative", "SALESREPRESENTATIVE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "3befd5c7-8e19-47ce-957a-dae8c1d18bee", "Admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEAmlUv4kTN7XO+ogvN4wpOM8qcrUl07+sNIMkpxSktFodVJzCNGoSytLnxF94TSnrA==", "01234567890", false, "a76db55e-9797-4059-b606-5f3565ad9d99", false, "Admin" },
                    { "2", 0, "52dd26ab-395e-48bb-bd28-3212afdcd0c0", "trader1@example.com", false, false, null, "TRADER1@EXAMPLE.COM", "TRADER1", "AQAAAAIAAYagAAAAEF+x2RAX0hrF4L9e2qiBNTZN4NgSlJKHwPBk9QMy37OBGIPQgqxtz+tdaIF7SMpNMA==", "01278555861", false, "a06dadae-6215-4545-b521-95ccc570573b", false, "trader1" },
                    { "3", 0, "2dda741e-443f-48b2-a1f0-9f99f9f12fca", "employee1@example.com", false, false, null, "EMPLOYEE1@EXAMPLE.COM", "EMPLOYEE1", "AQAAAAIAAYagAAAAEPBDgW2Q+fYmkBFqPtPl7xFK+xzY3IuAcJhTmmjd2XskxQH4sOFIxUOOFnIlDv0bRQ==", "01033325256", false, "523b9c2a-93b7-4d86-b21b-466ca782b5a5", false, "employee1" },
                    { "4", 0, "003b2cf0-a4e8-4585-a4ad-909e06c15b97", "sales1@example.com", false, false, null, "SALES1@EXAMPLE.COM", "SALES1", "AQAAAAIAAYagAAAAEJ2ofZ1rZzdFAUiPOHZ1Dl1oDTOLi5xkw/yU1l6lUlwG/ushIjuF+mVWAQ6qxGlSMg==", "01033325256", false, "9e9a3ff7-757c-4d02-ad69-e547e33d562a", false, "sales1" },
                    { "5", 0, "39f6c50d-ee04-45f4-a974-14d08eb28381", "employee2@example.com", false, false, null, "EMPLOYEE2@EXAMPLE.COM", "EMPLOYEE2", "AQAAAAIAAYagAAAAEFgtu3wXd+NwbxLqDVXlTbR9NunYlmL/ayCSc91kvX3IxOPbUAyvciqMoshrWq4LAw==", "01033325256", false, "5d3b76d7-bfd7-458a-a6bc-80c661099d8d", false, "employee2" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedAt", "State" },
                values: new object[,]
                {
                    { 1, "Cairo", new DateTime(2023, 6, 26, 5, 9, 51, 701, DateTimeKind.Local).AddTicks(518), true },
                    { 2, "Giza", new DateTime(2023, 6, 26, 5, 9, 51, 701, DateTimeKind.Local).AddTicks(610), true },
                    { 3, "Alexandria", new DateTime(2023, 6, 26, 5, 9, 51, 701, DateTimeKind.Local).AddTicks(636), true },
                    { 4, "Sharqia", new DateTime(2023, 6, 26, 5, 9, 51, 701, DateTimeKind.Local).AddTicks(640), false }
                });

            migrationBuilder.InsertData(
                table: "Goverments",
                columns: new[] { "Goverment_Id", "GovermentName", "State" },
                values: new object[,]
                {
                    { 1, "Cairo", true },
                    { 2, "Alexandria", true },
                    { 3, "Giza", true },
                    { 4, "Dakahlia", false },
                    { 5, "Sharqia", false }
                });

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
                    { 46, "permission.goverments.read", "true", "4" },
                    { 47, "permission.permissions.read", "true", "1" },
                    { 48, "permission.permissions.update", "true", "1" },
                    { 49, "permission.permissions.add", "true", "1" },
                    { 50, "permission.permissions.delete", "true", "1" }
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
                table: "Cities",
                columns: new[] { "City_Id", "CityName", "GovermentId", "NormalShippingCost", "PickupShippingCost" },
                values: new object[,]
                {
                    { 1, "Cairo", 1, 30.0, 10.0 },
                    { 2, "Giza", 1, 15.0, 5.0 },
                    { 3, "Shubra El-Kheima", 1, 20.0, 15.0 },
                    { 4, "Cairo", 1, 30.0, 10.0 },
                    { 5, "Helwan", 1, 35.0, 20.0 },
                    { 6, "Alexandria", 2, 30.0, 10.0 },
                    { 7, "Borg El Arab", 2, 15.0, 5.0 },
                    { 8, "Abu Qir", 2, 20.0, 15.0 },
                    { 9, "Montaza", 2, 30.0, 10.0 },
                    { 10, "Miami", 2, 35.0, 20.0 },
                    { 11, "Giza", 3, 30.0, 10.0 },
                    { 12, "Al Haram", 3, 15.0, 5.0 },
                    { 13, "Sheikh Zayed City", 3, 20.0, 15.0 },
                    { 14, "6th of October City", 3, 30.0, 10.0 },
                    { 15, "Bulaq ad Dakrur", 3, 35.0, 20.0 },
                    { 16, "Mansoura", 4, 30.0, 10.0 },
                    { 17, "Talkha", 4, 15.0, 5.0 },
                    { 18, "Mit Ghamr", 4, 20.0, 15.0 },
                    { 19, "Aga", 4, 30.0, 10.0 },
                    { 20, "Sherbin", 4, 35.0, 20.0 },
                    { 21, "Zagazig", 5, 30.0, 10.0 },
                    { 22, "Belbeis", 5, 15.0, 5.0 },
                    { 23, "Abu Hammad", 5, 20.0, 15.0 },
                    { 24, "Abu Kebir", 5, 30.0, 10.0 },
                    { 25, "Kafr Saqr", 5, 35.0, 20.0 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BranchId", "Email", "IsActive", "Name", "Password", "PhoneNumber", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1L, 1, "employee1@example.com", true, "Ahmed Mohamed", "Employee@123", "01033325256", "3", "employee1" },
                    { 2L, 2, "employee2@example.com", false, "Sayed Sameh", "Employee@123", "01033325256", "5", "employee2" }
                });

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
                name: "IX_Employees_BranchId",
                table: "Employees",
                column: "BranchId");

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
