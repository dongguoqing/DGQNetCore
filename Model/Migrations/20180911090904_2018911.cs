using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class _2018911 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
          
            migrationBuilder.CreateTable(
                name: "UserLogOn",
                columns: table => new
                {
                    F_Id = table.Column<string>(nullable: false),
                    F_UserId = table.Column<string>(nullable: true),
                    F_UserPassword = table.Column<string>(nullable: true),
                    F_UserSecretkey = table.Column<string>(nullable: true),
                    F_AllowStartTime = table.Column<DateTime>(nullable: true),
                    F_AllowEndTime = table.Column<DateTime>(nullable: true),
                    F_LockStartDate = table.Column<DateTime>(nullable: true),
                    F_LockEndDate = table.Column<DateTime>(nullable: true),
                    F_FirstVisitTime = table.Column<DateTime>(nullable: true),
                    F_PreviousVisitTime = table.Column<DateTime>(nullable: true),
                    F_LastVisitTime = table.Column<DateTime>(nullable: true),
                    F_ChangePasswordDate = table.Column<DateTime>(nullable: true),
                    F_MultiUserLogin = table.Column<int>(nullable: true),
                    F_LogOnCount = table.Column<int>(nullable: true),
                    F_UserOnLine = table.Column<int>(nullable: true),
                    F_Question = table.Column<string>(nullable: true),
                    F_AnswerQuestion = table.Column<string>(nullable: true),
                    F_CheckIPAddress = table.Column<int>(nullable: true),
                    F_Language = table.Column<string>(nullable: true),
                    F_Theme = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogOn", x => x.F_Id);
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
                name: "UserLogOn");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
