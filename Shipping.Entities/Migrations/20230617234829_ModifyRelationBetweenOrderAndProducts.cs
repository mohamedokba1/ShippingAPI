using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRelationBetweenOrderAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrder_Orders_OrdersOrder_Id",
                table: "CustomerOrder");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.RenameColumn(
                name: "Order_Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "OrdersOrder_Id",
                table: "CustomerOrder",
                newName: "OrdersOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrder_OrdersOrder_Id",
                table: "CustomerOrder",
                newName: "IX_CustomerOrder_OrdersOrderId");

            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "DeliveredToVillage",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TotalCost",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TotalWeight",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrder_Orders_OrdersOrderId",
                table: "CustomerOrder",
                column: "OrdersOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrder_Orders_OrdersOrderId",
                table: "CustomerOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeliveredToVillage",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalWeight",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Order_Id");

            migrationBuilder.RenameColumn(
                name: "OrdersOrderId",
                table: "CustomerOrder",
                newName: "OrdersOrder_Id");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrder_OrdersOrderId",
                table: "CustomerOrder",
                newName: "IX_CustomerOrder_OrdersOrder_Id");

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersOrder_Id = table.Column<long>(type: "bigint", nullable: false),
                    ProductsProduct_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersOrder_Id, x.ProductsProduct_Id });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersOrder_Id",
                        column: x => x.OrdersOrder_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductsProduct_Id",
                        column: x => x.ProductsProduct_Id,
                        principalTable: "Products",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsProduct_Id",
                table: "OrderProduct",
                column: "ProductsProduct_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrder_Orders_OrdersOrder_Id",
                table: "CustomerOrder",
                column: "OrdersOrder_Id",
                principalTable: "Orders",
                principalColumn: "Order_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
