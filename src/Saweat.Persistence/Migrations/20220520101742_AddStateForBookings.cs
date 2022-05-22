using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saweat.Persistence.Migrations
{
    public partial class AddStateForBookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Bookings");
        }
    }
}
