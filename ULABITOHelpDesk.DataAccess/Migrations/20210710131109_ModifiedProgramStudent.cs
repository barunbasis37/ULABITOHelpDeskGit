using Microsoft.EntityFrameworkCore.Migrations;

namespace ULABITOHelpDesk.DataAccess.Migrations
{
    public partial class ModifiedProgramStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Student_Id",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "ProgramName",
                table: "Programs",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "Student_Id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Programs",
                newName: "ProgramName");
        }
    }
}
