using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saweat.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergens",
                columns: table => new
                {
                    AllergenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergenCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.AllergenId);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeopleAmount = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "OpeningPeriods",
                columns: table => new
                {
                    OpeningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    StartHour = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndHour = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningPeriods", x => x.OpeningId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    City = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Provincy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastnames = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.InsertData(
                table: "OpeningPeriods",
                columns: new[] { "OpeningId", "Day", "EndHour", "StartHour" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 2, 1, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 20, 0, 0, 0) },
                    { 3, 2, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 4, 2, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 20, 0, 0, 0) },
                    { 5, 3, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 6, 3, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 20, 0, 0, 0) },
                    { 7, 4, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 8, 4, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 20, 0, 0, 0) },
                    { 9, 5, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 10, 5, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 20, 0, 0, 0) },
                    { 11, 6, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Address", "City", "Description", "Enabled", "LongDescription", "Phone", "Photo", "PostalCode", "Provincy" },
                values: new object[] { "sutakito", "Francisco de Quevedo 12, Bajo", "Santander", "Sutakito Mexicano", true, "La mejor comida mexicana artesanal en Santander", "642 63 99 73", "https://sutakitomexicano.com/wp-content/uploads/2021/04/cropped-logo-sutakito.png", "30001", "Cantabria" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "Lastnames", "Name" },
                values: new object[] { "adminsaweat@saweat.com", "", "Administrador" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "OpeningPeriods");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
