using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class _8291115Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserRole");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "UserRole",
                newName: "F_Type");

            migrationBuilder.AddColumn<string>(
                name: "F_Id",
                table: "UserRole",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "F_AllowDelete",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "F_AllowEdit",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "F_Category",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "F_CreatorTime",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_CreatorUserId",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "F_DeleteMark",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "F_DeleteTime",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_DeleteUserId",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_Description",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_EnCode",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "F_EnabledMark",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_FullName",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "F_LastModifyTime",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_LastModifyUserId",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_OrganizeId",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "F_SortCode",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                column: "F_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_Id",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_AllowDelete",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_AllowEdit",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_Category",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_CreatorTime",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_CreatorUserId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_DeleteMark",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_DeleteTime",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_DeleteUserId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_Description",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_EnCode",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_EnabledMark",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_FullName",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_LastModifyTime",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_LastModifyUserId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_OrganizeId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "F_SortCode",
                table: "UserRole");

            migrationBuilder.RenameColumn(
                name: "F_Type",
                table: "UserRole",
                newName: "RoleName");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserRole",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                column: "Id");
        }
    }
}
