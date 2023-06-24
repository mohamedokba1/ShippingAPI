using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "branchName",
                table: "Branches",
                newName: "BranchName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SalesRepresentatives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SalesRepresentatives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "SalesRepresentatives");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SalesRepresentatives");

            migrationBuilder.RenameColumn(
                name: "BranchName",
                table: "Branches",
                newName: "branchName");
        }
    }
}
