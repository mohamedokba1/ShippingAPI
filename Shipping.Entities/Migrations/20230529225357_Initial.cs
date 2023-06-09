using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Customers", x => x.Customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Employee_Id);
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
                name: "Privellges",
                columns: table => new
                {
                    Privellge_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrivellgeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privellges", x => x.Privellge_Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesRepresentatives",
                columns: table => new
                {
                    SalesRepresentative_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CompanyPercentage = table.Column<double>(type: "float", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goverment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRepresentatives", x => x.SalesRepresentative_Id);
                });

            migrationBuilder.CreateTable(
                name: "Traders",
                columns: table => new
                {
                    Trader_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TraderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostPerRefusedOrder = table.Column<double>(type: "float", nullable: false),
                    CompanyBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traders", x => x.Trader_Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    City_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalShippingCost = table.Column<double>(type: "float", nullable: false),
                    Goverment_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.City_Id);
                    table.ForeignKey(
                        name: "FK_Cities_Goverments_Goverment_Id",
                        column: x => x.Goverment_Id,
                        principalTable: "Goverments",
                        principalColumn: "Goverment_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePrivellge",
                columns: table => new
                {
                    EmployeesEmployee_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrivillagesPrivellge_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePrivellge", x => new { x.EmployeesEmployee_Id, x.PrivillagesPrivellge_Id });
                    table.ForeignKey(
                        name: "FK_EmployeePrivellge_Employees_EmployeesEmployee_Id",
                        column: x => x.EmployeesEmployee_Id,
                        principalTable: "Employees",
                        principalColumn: "Employee_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeePrivellge_Privellges_PrivillagesPrivellge_Id",
                        column: x => x.PrivillagesPrivellge_Id,
                        principalTable: "Privellges",
                        principalColumn: "Privellge_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PrivellgeSalesRepresentative",
                columns: table => new
                {
                    PrivellgesPrivellge_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesRepresentativesSalesRepresentative_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivellgeSalesRepresentative", x => new { x.PrivellgesPrivellge_Id, x.SalesRepresentativesSalesRepresentative_Id });
                    table.ForeignKey(
                        name: "FK_PrivellgeSalesRepresentative_Privellges_PrivellgesPrivellge_Id",
                        column: x => x.PrivellgesPrivellge_Id,
                        principalTable: "Privellges",
                        principalColumn: "Privellge_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrivellgeSalesRepresentative_SalesRepresentatives_SalesRepresentativesSalesRepresentative_Id",
                        column: x => x.SalesRepresentativesSalesRepresentative_Id,
                        principalTable: "SalesRepresentatives",
                        principalColumn: "SalesRepresentative_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExtraWeightCost = table.Column<double>(type: "float", nullable: false),
                    CompanyBranch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultCost = table.Column<double>(type: "float", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shipping_type = table.Column<int>(type: "int", nullable: false),
                    traderIdTrader_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    salesRepresentativeIdSalesRepresentative_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_Id);
                    table.ForeignKey(
                        name: "FK_Orders_SalesRepresentatives_salesRepresentativeIdSalesRepresentative_Id",
                        column: x => x.salesRepresentativeIdSalesRepresentative_Id,
                        principalTable: "SalesRepresentatives",
                        principalColumn: "SalesRepresentative_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Orders_Traders_traderIdTrader_Id",
                        column: x => x.traderIdTrader_Id,
                        principalTable: "Traders",
                        principalColumn: "Trader_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PrivellgeTrader",
                columns: table => new
                {
                    PrivellgesPrivellge_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TradersTrader_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivellgeTrader", x => new { x.PrivellgesPrivellge_Id, x.TradersTrader_Id });
                    table.ForeignKey(
                        name: "FK_PrivellgeTrader_Privellges_PrivellgesPrivellge_Id",
                        column: x => x.PrivellgesPrivellge_Id,
                        principalTable: "Privellges",
                        principalColumn: "Privellge_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrivellgeTrader_Traders_TradersTrader_Id",
                        column: x => x.TradersTrader_Id,
                        principalTable: "Traders",
                        principalColumn: "Trader_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                columns: table => new
                {
                    CustomersCustomer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrdersOrder_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrder", x => new { x.CustomersCustomer_Id, x.OrdersOrder_Id });
                    table.ForeignKey(
                        name: "FK_CustomerOrder_Customers_CustomersCustomer_Id",
                        column: x => x.CustomersCustomer_Id,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CustomerOrder_Orders_OrdersOrder_Id",
                        column: x => x.OrdersOrder_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersOrder_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsProduct_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersOrder_Id, x.ProductsProduct_Id });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersOrder_Id",
                        column: x => x.OrdersOrder_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductsProduct_Id",
                        column: x => x.ProductsProduct_Id,
                        principalTable: "Products",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Goverment_Id",
                table: "Cities",
                column: "Goverment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_OrdersOrder_Id",
                table: "CustomerOrder",
                column: "OrdersOrder_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePrivellge_PrivillagesPrivellge_Id",
                table: "EmployeePrivellge",
                column: "PrivillagesPrivellge_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsProduct_Id",
                table: "OrderProduct",
                column: "ProductsProduct_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_salesRepresentativeIdSalesRepresentative_Id",
                table: "Orders",
                column: "salesRepresentativeIdSalesRepresentative_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_traderIdTrader_Id",
                table: "Orders",
                column: "traderIdTrader_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PrivellgeSalesRepresentative_SalesRepresentativesSalesRepresentative_Id",
                table: "PrivellgeSalesRepresentative",
                column: "SalesRepresentativesSalesRepresentative_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PrivellgeTrader_TradersTrader_Id",
                table: "PrivellgeTrader",
                column: "TradersTrader_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "CustomerOrder");

            migrationBuilder.DropTable(
                name: "EmployeePrivellge");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "PrivellgeSalesRepresentative");

            migrationBuilder.DropTable(
                name: "PrivellgeTrader");

            migrationBuilder.DropTable(
                name: "Goverments");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Privellges");

            migrationBuilder.DropTable(
                name: "SalesRepresentatives");

            migrationBuilder.DropTable(
                name: "Traders");
        }
    }
}
