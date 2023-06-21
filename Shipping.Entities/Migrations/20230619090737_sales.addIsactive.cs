using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class salesaddIsactive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SalesRepresentatives",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SalesRepresentatives");
        }
    }
}
