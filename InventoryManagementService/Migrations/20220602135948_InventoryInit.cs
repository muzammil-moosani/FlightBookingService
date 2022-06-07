using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementService.Migrations
{
    public partial class InventoryInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryDetail",
                columns: table => new
                {
                    InventoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirlineId = table.Column<int>(nullable: false),
                    FlightNumber = table.Column<int>(nullable: false),
                    FromPlace = table.Column<string>(nullable: true),
                    ToPlace = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    ScheduledDays = table.Column<string>(nullable: true),
                    Instrument = table.Column<string>(nullable: true),
                    NoOfBusinessSeats = table.Column<int>(nullable: false),
                    NoOfNonBusinessSeats = table.Column<int>(nullable: false),
                    TicketCharges = table.Column<double>(nullable: false),
                    NoOfRows = table.Column<int>(nullable: false),
                    Meal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDetail", x => x.InventoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryDetail");
        }
    }
}
