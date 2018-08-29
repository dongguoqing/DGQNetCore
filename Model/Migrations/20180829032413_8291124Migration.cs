using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class _8291124Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModuleButtong",
                columns: table => new
                {
                    F_Id = table.Column<string>(nullable: false),
                    F_ModuleId = table.Column<string>(nullable: true),
                    F_ParentId = table.Column<string>(nullable: true),
                    F_Layers = table.Column<int>(nullable: true),
                    F_EnCode = table.Column<string>(nullable: true),
                    F_FullName = table.Column<string>(nullable: true),
                    F_Icon = table.Column<string>(nullable: true),
                    F_Location = table.Column<int>(nullable: true),
                    F_JsEvent = table.Column<string>(nullable: true),
                    F_UrlAddress = table.Column<string>(nullable: true),
                    F_Split = table.Column<bool>(nullable: true),
                    F_IsPublic = table.Column<bool>(nullable: true),
                    F_AllowEdit = table.Column<bool>(nullable: true),
                    F_AllowDelete = table.Column<bool>(nullable: true),
                    F_SortCode = table.Column<int>(nullable: true),
                    F_DeleteMark = table.Column<bool>(nullable: true),
                    F_EnabledMark = table.Column<bool>(nullable: true),
                    F_Description = table.Column<string>(nullable: true),
                    F_CreatorTime = table.Column<DateTime>(nullable: true),
                    F_CreatorUserId = table.Column<string>(nullable: true),
                    F_LastModifyTime = table.Column<DateTime>(nullable: true),
                    F_LastModifyUserId = table.Column<string>(nullable: true),
                    F_DeleteTime = table.Column<DateTime>(nullable: true),
                    F_DeleteUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleButtong", x => x.F_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleButtong");
        }
    }
}
