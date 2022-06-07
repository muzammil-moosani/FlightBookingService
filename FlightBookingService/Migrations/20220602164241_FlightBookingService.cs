using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightBookingService.Migrations
{
    public partial class FlightBookingService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryId = table.Column<int>(nullable: false),
                    AirlineId = table.Column<int>(nullable: false),
                    FlightNumber = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FromPlace = table.Column<string>(nullable: true),
                    ToPlace = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    NoOfPassenger = table.Column<int>(nullable: false),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    TravelClass = table.Column<string>(nullable: true),
                    Meal = table.Column<string>(nullable: true),
                    TicketCharges = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "PassengerDetail",
                columns: table => new
                {
                    Pid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookingId = table.Column<int>(nullable: false),
                    Name = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    SeatNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerDetail", x => x.Pid);
                    table.ForeignKey(
                        name: "FK_PassengerDetail_BookingDetails_BookingId",
                        column: x => x.BookingId,
                        principalTable: "BookingDetails",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassengerDetail_BookingId",
                table: "PassengerDetail",
                column: "BookingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassengerDetail");

            migrationBuilder.DropTable(
                name: "BookingDetails");
        }
    }
}
