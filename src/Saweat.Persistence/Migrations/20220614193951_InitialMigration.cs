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
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "FoodPlateTypes",
                columns: table => new
                {
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nchar(200)", fixedLength: true, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPlateTypes", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewId);
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
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "FoodPlates",
                columns: table => new
                {
                    PlateFoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nchar(200)", fixedLength: true, maxLength: 200, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPlates", x => x.PlateFoodId);
                    table.ForeignKey(
                        name: "FK_FoodPlates_FoodPlateTypes_Type",
                        column: x => x.Type,
                        principalTable: "FoodPlateTypes",
                        principalColumn: "Type");
                });

            migrationBuilder.InsertData(
                table: "FoodPlateTypes",
                columns: new[] { "Type", "Description" },
                values: new object[,]
                {
                    { 0, "Indefinido" },
                    { 1, "Especiales" },
                    { 2, "Carnes" },
                    { 3, "Vegetales" },
                    { 4, "Mixtos" },
                    { 5, "Bebidas" },
                    { 6, "Bebidas Alcoholicas" },
                    { 7, "Postres" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "Lastnames", "Name" },
                values: new object[] { "adminsaweat@saweat.com", "", "Administrador" });

            migrationBuilder.CreateIndex(
                name: "IX_FoodPlates_Type",
                table: "FoodPlates",
                column: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "FoodPlates");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FoodPlateTypes");
        }
    }
}
