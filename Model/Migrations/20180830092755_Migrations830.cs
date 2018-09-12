using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Migrations830 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "Organize",
                columns: table => new
                {
                    F_Id = table.Column<string>(nullable: false),
                    F_ParentId = table.Column<string>(nullable: true),
                    F_Layers = table.Column<int>(nullable: true),
                    F_EnCode = table.Column<string>(nullable: true),
                    F_FullName = table.Column<string>(nullable: true),
                    F_ShortName = table.Column<string>(nullable: true),
                    F_CategoryId = table.Column<string>(nullable: true),
                    F_ManagerId = table.Column<string>(nullable: true),
                    F_TelePhone = table.Column<string>(nullable: true),
                    F_MobilePhone = table.Column<string>(nullable: true),
                    F_WeChat = table.Column<string>(nullable: true),
                    F_Fax = table.Column<string>(nullable: true),
                    F_Email = table.Column<string>(nullable: true),
                    F_AreaId = table.Column<string>(nullable: true),
                    F_Address = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Organize", x => x.F_Id);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "ModuleButton");

            migrationBuilder.DropTable(
                name: "Organize");

            migrationBuilder.DropTable(
                name: "RoleAuthorize");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
