using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saweat.Persistence.Migrations
{
    public partial class ChangesInBookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpeningPeriod",
                table: "OpeningPeriod");

            migrationBuilder.RenameTable(
                name: "Restaurant",
                newName: "Restaurants");

            migrationBuilder.RenameTable(
                name: "OpeningPeriod",
                newName: "OpeningPeriods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpeningPeriods",
                table: "OpeningPeriods",
                column: "OpeningId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpeningPeriods",
                table: "OpeningPeriods");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "Restaurant");

            migrationBuilder.RenameTable(
                name: "OpeningPeriods",
                newName: "OpeningPeriod");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant",
                column: "RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpeningPeriod",
                table: "OpeningPeriod",
                column: "OpeningId");
        }
    }
}
