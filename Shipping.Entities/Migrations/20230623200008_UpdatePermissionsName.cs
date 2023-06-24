using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePermissionsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Privellges_AspNetRoles_ApplicationUserRoleId",
                table: "Privellges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Privellges",
                table: "Privellges");

            migrationBuilder.RenameTable(
                name: "Privellges",
                newName: "Permissions");

            migrationBuilder.RenameIndex(
                name: "IX_Privellges_ApplicationUserRoleId",
                table: "Permissions",
                newName: "IX_Permissions_ApplicationUserRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_AspNetRoles_ApplicationUserRoleId",
                table: "Permissions",
                column: "ApplicationUserRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_AspNetRoles_ApplicationUserRoleId",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Privellges");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_ApplicationUserRoleId",
                table: "Privellges",
                newName: "IX_Privellges_ApplicationUserRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Privellges",
                table: "Privellges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Privellges_AspNetRoles_ApplicationUserRoleId",
                table: "Privellges",
                column: "ApplicationUserRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }
    }
}
