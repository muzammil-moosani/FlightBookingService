using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightBookingService.Migrations
{
    public partial class FlightInits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetail_UserDetail_UserId",
                table: "BookingDetail");

            migrationBuilder.DropTable(
                name: "UserDetail");

            migrationBuilder.DropIndex(
                name: "IX_BookingDetail_UserId",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookingDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BookingDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserDetail",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    MobileNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.UserId);
                });

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
    }
}
