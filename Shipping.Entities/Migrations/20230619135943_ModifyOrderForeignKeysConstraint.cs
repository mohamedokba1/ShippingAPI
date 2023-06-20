using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class ModifyOrderForeignKeysConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SalesRepresentatives_SalesRepresentativeId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Traders_TraderId",
                table: "Orders");

            migrationBuilder.AlterColumn<long>(
                name: "TraderId",
                table: "Orders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "SalesRepresentativeId",
                table: "Orders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Orders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerId",
                table: "Orders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SalesRepresentatives_SalesRepresentativeId",
                table: "Orders",
                column: "SalesRepresentativeId",
                principalTable: "SalesRepresentatives",
                principalColumn: "SalesRepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Traders_TraderId",
                table: "Orders",
                column: "TraderId",
                principalTable: "Traders",
                principalColumn: "TraderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SalesRepresentatives_SalesRepresentativeId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Traders_TraderId",
                table: "Orders");

            migrationBuilder.AlterColumn<long>(
                name: "TraderId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SalesRepresentativeId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CustomerId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SalesRepresentatives_SalesRepresentativeId",
                table: "Orders",
                column: "SalesRepresentativeId",
                principalTable: "SalesRepresentatives",
                principalColumn: "SalesRepresentativeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Traders_TraderId",
                table: "Orders",
                column: "TraderId",
                principalTable: "Traders",
                principalColumn: "TraderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
