using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class AddModuleMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ModuleCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModuleName = table.Column<string>(nullable: true),
                    ModuleBrief = table.Column<string>(nullable: true),
                    ModuleLevel = table.Column<int>(nullable: false),
                    ModulePosition = table.Column<int>(nullable: false),
                    ModuleIndex = table.Column<string>(nullable: true),
                    ModuleStatus = table.Column<int>(nullable: false),
                    ModuleUrl = table.Column<string>(nullable: true),
                    UseActions = table.Column<string>(nullable: true),
                    IsBigTable = table.Column<bool>(nullable: false),
                    LimitCount = table.Column<int>(nullable: false),
                    Guid = table.Column<Guid>(nullable: false),
                    ModuleType = table.Column<int>(nullable: false),
                    UpperGuid = table.Column<Guid>(nullable: false),
                    ModuleIcon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ModuleCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Module");
        }
    }
}
