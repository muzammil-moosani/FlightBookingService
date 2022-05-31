using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirlineService.Migrations
{
    public partial class AirlineInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirlineDetail",
                columns: table => new
                {
                    AirlineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirlineName = table.Column<string>(nullable: true),
                    AirlineLogo = table.Column<string>(nullable: true),
                    ContactAddress = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<int>(nullable: false),
                    IsBlocked = table.Column<bool>(nullable: false),
                    AddedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineDetail", x => x.AirlineId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirlineDetail");
        }
    }
}
