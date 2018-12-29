using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemsDetail",
                columns: table => new
                {
                    F_Id = table.Column<string>(nullable: false),
                    F_ItemId = table.Column<string>(nullable: true),
                    F_ParentId = table.Column<string>(nullable: true),
                    F_ItemName = table.Column<string>(nullable: true),
                    F_ItemCode = table.Column<string>(nullable: true),
                    F_SimpleSpelling = table.Column<string>(nullable: true),
                    F_IsDefault = table.Column<string>(nullable: true),
                    F_Layers = table.Column<string>(nullable: true),
                    F_SortCode = table.Column<string>(nullable: true),
                    F_DeleteMark = table.Column<string>(nullable: true),
                    F_EnabledMark = table.Column<string>(nullable: true),
                    F_Description = table.Column<string>(nullable: true),
                    F_CreatorTime = table.Column<string>(nullable: true),
                    F_CreatorUserId = table.Column<string>(nullable: true),
                    F_LastModifyTime = table.Column<string>(nullable: true),
                    F_LastModifyUserId = table.Column<string>(nullable: true),
                    F_DeleteTime = table.Column<string>(nullable: true),
                    F_DeleteUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsDetail", x => x.F_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsDetail");
        }
    }
}
