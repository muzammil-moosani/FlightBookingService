using Microsoft.EntityFrameworkCore.Migrations;

namespace AirlineService.Migrations
{
    public partial class AirlinesInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "AirlineDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "AirlineDetail",
                nullable: false,
                defaultValue: 0);
        }
    }
}
