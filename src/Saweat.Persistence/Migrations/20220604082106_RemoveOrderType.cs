using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saweat.Persistence.Migrations
{
    public partial class RemoveOrderType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodPlates_FoodPlateOrders_Order",
                table: "FoodPlates");

            migrationBuilder.DropTable(
                name: "FoodPlateOrders");

            migrationBuilder.DropIndex(
                name: "IX_FoodPlates_Order",
                table: "FoodPlates");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "FoodPlates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "FoodPlates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FoodPlateOrders",
                columns: table => new
                {
                    Order = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nchar(200)", fixedLength: true, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPlateOrders", x => x.Order);
                });

            migrationBuilder.InsertData(
                table: "FoodPlateOrders",
                columns: new[] { "Order", "Description" },
                values: new object[,]
                {
                    { 0, "Indefinido" },
                    { 1, "Primero" },
                    { 2, "Segundo" },
                    { 3, "Tercero / Postre" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodPlates_Order",
                table: "FoodPlates",
                column: "Order");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPlates_FoodPlateOrders_Order",
                table: "FoodPlates",
                column: "Order",
                principalTable: "FoodPlateOrders",
                principalColumn: "Order");
        }
    }
}
