using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddBranchesWithSalesRepresentativeAndEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Goverment",
                table: "SalesRepresentatives");

            migrationBuilder.AddColumn<int>(
                name: "branchId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    branchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    salesPersonSalesRepresentative_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_SalesRepresentatives_salesPersonSalesRepresentative_Id",
                        column: x => x.salesPersonSalesRepresentative_Id,
                        principalTable: "SalesRepresentatives",
                        principalColumn: "SalesRepresentative_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GovermentSalesRepresentative",
                columns: table => new
                {
                    GovermentsGoverment_Id = table.Column<int>(type: "int", nullable: false),
                    SalesRepresentativesSalesRepresentative_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovermentSalesRepresentative", x => new { x.GovermentsGoverment_Id, x.SalesRepresentativesSalesRepresentative_Id });
                    table.ForeignKey(
                        name: "FK_GovermentSalesRepresentative_Goverments_GovermentsGoverment_Id",
                        column: x => x.GovermentsGoverment_Id,
                        principalTable: "Goverments",
                        principalColumn: "Goverment_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GovermentSalesRepresentative_SalesRepresentatives_SalesRepresentativesSalesRepresentative_Id",
                        column: x => x.SalesRepresentativesSalesRepresentative_Id,
                        principalTable: "SalesRepresentatives",
                        principalColumn: "SalesRepresentative_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_branchId",
                table: "Employees",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_salesPersonSalesRepresentative_Id",
                table: "Branch",
                column: "salesPersonSalesRepresentative_Id");

            migrationBuilder.CreateIndex(
                name: "IX_GovermentSalesRepresentative_SalesRepresentativesSalesRepresentative_Id",
                table: "GovermentSalesRepresentative",
                column: "SalesRepresentativesSalesRepresentative_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Branch_branchId",
                table: "Employees",
                column: "branchId",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Branch_branchId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "GovermentSalesRepresentative");

            migrationBuilder.DropIndex(
                name: "IX_Employees_branchId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "branchId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Goverment",
                table: "SalesRepresentatives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
