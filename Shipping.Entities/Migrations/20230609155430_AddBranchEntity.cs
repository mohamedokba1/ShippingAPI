using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddBranchEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_SalesRepresentatives_salesPersonSalesRepresentative_Id",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Branch_branchId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branch",
                table: "Branch");

            migrationBuilder.RenameTable(
                name: "Branch",
                newName: "Branches");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_salesPersonSalesRepresentative_Id",
                table: "Branches",
                newName: "IX_Branches_salesPersonSalesRepresentative_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_SalesRepresentatives_salesPersonSalesRepresentative_Id",
                table: "Branches",
                column: "salesPersonSalesRepresentative_Id",
                principalTable: "SalesRepresentatives",
                principalColumn: "SalesRepresentative_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Branches_branchId",
                table: "Employees",
                column: "branchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_SalesRepresentatives_salesPersonSalesRepresentative_Id",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Branches_branchId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "Branch");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_salesPersonSalesRepresentative_Id",
                table: "Branch",
                newName: "IX_Branch_salesPersonSalesRepresentative_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branch",
                table: "Branch",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_SalesRepresentatives_salesPersonSalesRepresentative_Id",
                table: "Branch",
                column: "salesPersonSalesRepresentative_Id",
                principalTable: "SalesRepresentatives",
                principalColumn: "SalesRepresentative_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Branch_branchId",
                table: "Employees",
                column: "branchId",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
