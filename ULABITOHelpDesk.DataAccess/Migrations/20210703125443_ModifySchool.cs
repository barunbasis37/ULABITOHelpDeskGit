using Microsoft.EntityFrameworkCore.Migrations;

namespace ULABITOHelpDesk.DataAccess.Migrations
{
    public partial class ModifySchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Schools_SchoolId",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schools",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Schools");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "SchoolCode",
                table: "Schools",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schools",
                table: "Schools",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Schools_SchoolId",
                table: "Departments",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Schools_SchoolId",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schools",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "SchoolCode",
                table: "Schools");

            migrationBuilder.AddColumn<string>(
                name: "SchoolId",
                table: "Schools",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SchoolId",
                table: "Departments",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schools",
                table: "Schools",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Schools_SchoolId",
                table: "Departments",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "SchoolId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
