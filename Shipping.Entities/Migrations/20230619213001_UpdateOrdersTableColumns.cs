using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrdersTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrder_Customers_CustomersCustomer_Id",
                table: "CustomerOrder");

            migrationBuilder.DropColumn(
                name: "DefaultCost",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Customer_Id",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomersCustomer_Id",
                table: "CustomerOrder",
                newName: "CustomersCustomerId");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Government",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrder_Customers_CustomersCustomerId",
                table: "CustomerOrder",
                column: "CustomersCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrder_Customers_CustomersCustomerId",
                table: "CustomerOrder");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Government",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Customer_Id");

            migrationBuilder.RenameColumn(
                name: "CustomersCustomerId",
                table: "CustomerOrder",
                newName: "CustomersCustomer_Id");

            migrationBuilder.AddColumn<double>(
                name: "DefaultCost",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrder_Customers_CustomersCustomer_Id",
                table: "CustomerOrder",
                column: "CustomersCustomer_Id",
                principalTable: "Customers",
                principalColumn: "Customer_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
