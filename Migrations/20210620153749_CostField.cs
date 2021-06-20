using Microsoft.EntityFrameworkCore.Migrations;

namespace ELab_NetCore_API.Migrations
{
    public partial class CostField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestCost",
                table: "TestTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestCost",
                table: "TestTypes");
        }
    }
}
