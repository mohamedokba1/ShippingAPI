using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionWithRolesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrivellgeSalesRepresentative");

            migrationBuilder.DropTable(
                name: "PrivellgeTrader");

            migrationBuilder.AddColumn<long>(
                name: "SalesRepresentativeId",
                table: "Privellges",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TraderId",
                table: "Privellges",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserRolePrivellge",
                columns: table => new
                {
                    PrivellgesPrivellge_Id = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRolePrivellge", x => new { x.PrivellgesPrivellge_Id, x.RolesId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRolePrivellge_AspNetRoles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRolePrivellge_Privellges_PrivellgesPrivellge_Id",
                        column: x => x.PrivellgesPrivellge_Id,
                        principalTable: "Privellges",
                        principalColumn: "Privellge_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Privellges_SalesRepresentativeId",
                table: "Privellges",
                column: "SalesRepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Privellges_TraderId",
                table: "Privellges",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRolePrivellge_RolesId",
                table: "ApplicationUserRolePrivellge",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Privellges_SalesRepresentatives_SalesRepresentativeId",
                table: "Privellges",
                column: "SalesRepresentativeId",
                principalTable: "SalesRepresentatives",
                principalColumn: "SalesRepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Privellges_Traders_TraderId",
                table: "Privellges",
                column: "TraderId",
                principalTable: "Traders",
                principalColumn: "TraderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Privellges_SalesRepresentatives_SalesRepresentativeId",
                table: "Privellges");

            migrationBuilder.DropForeignKey(
                name: "FK_Privellges_Traders_TraderId",
                table: "Privellges");

            migrationBuilder.DropTable(
                name: "ApplicationUserRolePrivellge");

            migrationBuilder.DropIndex(
                name: "IX_Privellges_SalesRepresentativeId",
                table: "Privellges");

            migrationBuilder.DropIndex(
                name: "IX_Privellges_TraderId",
                table: "Privellges");

            migrationBuilder.DropColumn(
                name: "SalesRepresentativeId",
                table: "Privellges");

            migrationBuilder.DropColumn(
                name: "TraderId",
                table: "Privellges");

            migrationBuilder.CreateTable(
                name: "PrivellgeSalesRepresentative",
                columns: table => new
                {
                    PrivellgesPrivellge_Id = table.Column<int>(type: "int", nullable: false),
                    SalesRepresentativesSalesRepresentativeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivellgeSalesRepresentative", x => new { x.PrivellgesPrivellge_Id, x.SalesRepresentativesSalesRepresentativeId });
                    table.ForeignKey(
                        name: "FK_PrivellgeSalesRepresentative_Privellges_PrivellgesPrivellge_Id",
                        column: x => x.PrivellgesPrivellge_Id,
                        principalTable: "Privellges",
                        principalColumn: "Privellge_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivellgeSalesRepresentative_SalesRepresentatives_SalesRepresentativesSalesRepresentativeId",
                        column: x => x.SalesRepresentativesSalesRepresentativeId,
                        principalTable: "SalesRepresentatives",
                        principalColumn: "SalesRepresentativeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivellgeTrader",
                columns: table => new
                {
                    PrivellgesPrivellge_Id = table.Column<int>(type: "int", nullable: false),
                    TradersTraderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivellgeTrader", x => new { x.PrivellgesPrivellge_Id, x.TradersTraderId });
                    table.ForeignKey(
                        name: "FK_PrivellgeTrader_Privellges_PrivellgesPrivellge_Id",
                        column: x => x.PrivellgesPrivellge_Id,
                        principalTable: "Privellges",
                        principalColumn: "Privellge_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivellgeTrader_Traders_TradersTraderId",
                        column: x => x.TradersTraderId,
                        principalTable: "Traders",
                        principalColumn: "TraderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrivellgeSalesRepresentative_SalesRepresentativesSalesRepresentativeId",
                table: "PrivellgeSalesRepresentative",
                column: "SalesRepresentativesSalesRepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivellgeTrader_TradersTraderId",
                table: "PrivellgeTrader",
                column: "TradersTraderId");
        }
    }
}
