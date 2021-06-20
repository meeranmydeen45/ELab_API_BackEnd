using Microsoft.EntityFrameworkCore.Migrations;

namespace ELab_NetCore_API.Migrations
{
    public partial class TestParam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestParams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParamName = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Range = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestParams", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestParams");
        }
    }
}
