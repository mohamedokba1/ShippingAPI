using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class empbranchidprivilegeid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Branches_branchId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "branchId",
                table: "Employees",
                newName: "branchid");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_branchId",
                table: "Employees",
                newName: "IX_Employees_branchid");

            migrationBuilder.AlterColumn<int>(
                name: "branchid",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Branches_branchid",
                table: "Employees",
                column: "branchid",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Branches_branchid",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "branchid",
                table: "Employees",
                newName: "branchId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_branchid",
                table: "Employees",
                newName: "IX_Employees_branchId");

            migrationBuilder.AlterColumn<int>(
                name: "branchId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Branches_branchId",
                table: "Employees",
                column: "branchId",
                principalTable: "Branches",
                principalColumn: "Id");
        }
    }
}
