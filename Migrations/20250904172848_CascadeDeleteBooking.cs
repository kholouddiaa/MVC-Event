using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Event.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Events",
                table: "Bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Events",
                table: "Bookings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Events",
                table: "Bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Events",
                table: "Bookings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict); // أو ClientSetNull حسب ما كان
        }

    }
}
