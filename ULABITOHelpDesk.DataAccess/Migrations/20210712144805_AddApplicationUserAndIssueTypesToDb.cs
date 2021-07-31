using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ULABITOHelpDesk.DataAccess.Migrations
{
    public partial class AddApplicationUserAndIssueTypesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "IssueTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "IssueTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "IssueTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "IssueTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "QueryId",
                table: "IssueTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "IssueTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "IssueTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedIp",
                table: "IssueTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "IssueTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueTypes_UserTypeId",
                table: "IssueTypes",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueTypes_UserTypes_UserTypeId",
                table: "IssueTypes",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueTypes_UserTypes_UserTypeId",
                table: "IssueTypes");

            migrationBuilder.DropIndex(
                name: "IX_IssueTypes_UserTypeId",
                table: "IssueTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "IssueTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "IssueTypes");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "IssueTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "IssueTypes");

            migrationBuilder.DropColumn(
                name: "QueryId",
                table: "IssueTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "IssueTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "IssueTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedIp",
                table: "IssueTypes");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "IssueTypes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");
        }
    }
}
