using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRolePrivellge");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Privellges",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "PrivellgeName",
                table: "Privellges",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Privellge_Id",
                table: "Privellges",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "Add",
                table: "Privellges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserRoleId",
                table: "Privellges",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Privellges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Read",
                table: "Privellges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Update",
                table: "Privellges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Privellges_ApplicationUserRoleId",
                table: "Privellges",
                column: "ApplicationUserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Privellges_AspNetRoles_ApplicationUserRoleId",
                table: "Privellges",
                column: "ApplicationUserRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Privellges_AspNetRoles_ApplicationUserRoleId",
                table: "Privellges");

            migrationBuilder.DropIndex(
                name: "IX_Privellges_ApplicationUserRoleId",
                table: "Privellges");

            migrationBuilder.DropColumn(
                name: "Add",
                table: "Privellges");

            migrationBuilder.DropColumn(
                name: "ApplicationUserRoleId",
                table: "Privellges");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Privellges");

            migrationBuilder.DropColumn(
                name: "Read",
                table: "Privellges");

            migrationBuilder.DropColumn(
                name: "Update",
                table: "Privellges");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Privellges",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Privellges",
                newName: "PrivellgeName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Privellges",
                newName: "Privellge_Id");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employees",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

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
                name: "IX_ApplicationUserRolePrivellge_RolesId",
                table: "ApplicationUserRolePrivellge",
                column: "RolesId");
        }
    }
}
