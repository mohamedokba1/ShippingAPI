using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class sales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SalesRepresentatives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "SalesRepresentatives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SalesRepresentatives");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "SalesRepresentatives");
        }
    }
}
