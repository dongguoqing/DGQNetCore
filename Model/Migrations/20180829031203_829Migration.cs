using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class _829Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    F_Id = table.Column<string>(nullable: false),
                    F_ParentId = table.Column<string>(nullable: true),
                    F_Layers = table.Column<int>(nullable: true),
                    F_EnCode = table.Column<string>(nullable: true),
                    F_FullName = table.Column<string>(nullable: true),
                    F_Icon = table.Column<string>(nullable: true),
                    F_UrlAddress = table.Column<string>(nullable: true),
                    F_Target = table.Column<string>(nullable: true),
                    F_IsMenu = table.Column<bool>(nullable: true),
                    F_IsExpand = table.Column<bool>(nullable: true),
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
                    table.PrimaryKey("PK_Module", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    F_Id = table.Column<string>(nullable: false),
                    F_Account = table.Column<string>(nullable: true),
                    F_RealName = table.Column<string>(nullable: true),
                    F_NickName = table.Column<string>(nullable: true),
                    F_HeadIcon = table.Column<string>(nullable: true),
                    F_Gender = table.Column<bool>(nullable: true),
                    F_Birthday = table.Column<DateTime>(nullable: true),
                    F_MobilePhone = table.Column<string>(nullable: true),
                    F_Email = table.Column<string>(nullable: true),
                    F_WeChat = table.Column<string>(nullable: true),
                    F_ManagerId = table.Column<string>(nullable: true),
                    F_SecurityLevel = table.Column<int>(nullable: true),
                    F_Signature = table.Column<string>(nullable: true),
                    F_OrganizeId = table.Column<string>(nullable: true),
                    F_DepartmentId = table.Column<string>(nullable: true),
                    F_RoleId = table.Column<string>(nullable: true),
                    F_DutyId = table.Column<string>(nullable: true),
                    F_IsAdministrator = table.Column<bool>(nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.F_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
