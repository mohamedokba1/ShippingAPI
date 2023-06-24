using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class changeemployeemodelandmakeregister : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRolePrivellge");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Employees",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
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
