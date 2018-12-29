using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Migrations1229 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "F_LastModifyTime",
                table: "ItemsDetail",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    F_Id = table.Column<string>(nullable: false),
                    F_ParentId = table.Column<string>(nullable: true),
                    F_EnCode = table.Column<string>(nullable: true),
                    F_FullName = table.Column<string>(nullable: true),
                    F_IsTree = table.Column<string>(nullable: true),
                    F_Layers = table.Column<string>(nullable: true),
                    F_SortCode = table.Column<string>(nullable: true),
                    F_DeleteMark = table.Column<string>(nullable: true),
                    F_EnabledMark = table.Column<string>(nullable: true),
                    F_Description = table.Column<string>(nullable: true),
                    F_CreatorTime = table.Column<string>(nullable: true),
                    F_CreatorUserId = table.Column<string>(nullable: true),
                    F_LastModifyTime = table.Column<DateTime>(nullable: true),
                    F_LastModifyUserId = table.Column<string>(nullable: true),
                    F_DeleteTime = table.Column<string>(nullable: true),
                    F_DeleteUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.F_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "F_LastModifyTime",
                table: "ItemsDetail",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
