using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class branchaddCollectionofsales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_SalesRepresentatives_salesPersonSalesRepresentativeId",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_salesPersonSalesRepresentativeId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "salesPersonSalesRepresentativeId",
                table: "Branches");

            migrationBuilder.AddColumn<int>(
                name: "DiscountType",
                table: "SalesRepresentatives",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_BranchSalesRepresentative_SalesRepresentativesSalesRepresentativeId",
                table: "BranchSalesRepresentative",
                column: "SalesRepresentativesSalesRepresentativeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchSalesRepresentative");

            migrationBuilder.DropColumn(
                name: "DiscountType",
                table: "SalesRepresentatives");

            migrationBuilder.AddColumn<long>(
                name: "salesPersonSalesRepresentativeId",
                table: "Branches",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_salesPersonSalesRepresentativeId",
                table: "Branches",
                column: "salesPersonSalesRepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_SalesRepresentatives_salesPersonSalesRepresentativeId",
                table: "Branches",
                column: "salesPersonSalesRepresentativeId",
                principalTable: "SalesRepresentatives",
                principalColumn: "SalesRepresentativeId");
        }
    }
}
