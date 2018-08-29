using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class _8291113Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleAuthorize",
                columns: table => new
                {
                    F_Id = table.Column<string>(nullable: false),
                    F_ItemType = table.Column<int>(nullable: true),
                    F_ItemId = table.Column<string>(nullable: true),
                    F_ObjectType = table.Column<int>(nullable: true),
                    F_ObjectId = table.Column<string>(nullable: true),
                    F_SortCode = table.Column<int>(nullable: true),
                    F_CreatorTime = table.Column<DateTime>(nullable: true),
                    F_CreatorUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAuthorize", x => x.F_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleAuthorize");
        }
    }
}
