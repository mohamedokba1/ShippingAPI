using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class EditGovenmentIdInCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Goverments_Goverment_Id",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "Goverment_Id",
                table: "Cities",
                newName: "GovermentId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_Goverment_Id",
                table: "Cities",
                newName: "IX_Cities_GovermentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Goverments_GovermentId",
                table: "Cities",
                column: "GovermentId",
                principalTable: "Goverments",
                principalColumn: "Goverment_Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Goverments_GovermentId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "GovermentId",
                table: "Cities",
                newName: "Goverment_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_GovermentId",
                table: "Cities",
                newName: "IX_Cities_Goverment_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Goverments_Goverment_Id",
                table: "Cities",
                column: "Goverment_Id",
                principalTable: "Goverments",
                principalColumn: "Goverment_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
