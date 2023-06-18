using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Entities.Migrations
{
    /// <inheritdoc />
    public partial class empprivilage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePrivellge");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Employees",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AddColumn<int>(
                name: "privillageid",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_privillageid",
                table: "Employees",
                column: "privillageid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Privellges_privillageid",
                table: "Employees",
                column: "privillageid",
                principalTable: "Privellges",
                principalColumn: "Privellge_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Privellges_privillageid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_privillageid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "privillageid",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

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
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "EmployeePrivellge",
                columns: table => new
                {
                    EmployeesEmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    PrivillagesPrivellge_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePrivellge", x => new { x.EmployeesEmployeeId, x.PrivillagesPrivellge_Id });
                    table.ForeignKey(
                        name: "FK_EmployeePrivellge_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePrivellge_Privellges_PrivillagesPrivellge_Id",
                        column: x => x.PrivillagesPrivellge_Id,
                        principalTable: "Privellges",
                        principalColumn: "Privellge_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePrivellge_PrivillagesPrivellge_Id",
                table: "EmployeePrivellge",
                column: "PrivillagesPrivellge_Id");
        }
    }
}
