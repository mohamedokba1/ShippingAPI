using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTraderRelationWithAspNetUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Traders_AspNetUsers_ApplicationUserId",
                table: "Traders");

            migrationBuilder.DropIndex(
                name: "IX_Traders_ApplicationUserId",
                table: "Traders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Traders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Traders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Traders_ApplicationUserId",
                table: "Traders",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Traders_AspNetUsers_ApplicationUserId",
                table: "Traders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
