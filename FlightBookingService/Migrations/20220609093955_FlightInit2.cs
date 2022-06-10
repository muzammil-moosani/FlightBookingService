using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightBookingService.Migrations
{
    public partial class FlightInit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_UserId",
                table: "BookingDetail",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetail_UserDetail_UserId",
                table: "BookingDetail",
                column: "UserId",
                principalTable: "UserDetail",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetail_UserDetail_UserId",
                table: "BookingDetail");

            migrationBuilder.DropIndex(
                name: "IX_BookingDetail_UserId",
                table: "BookingDetail");
        }
    }
}
