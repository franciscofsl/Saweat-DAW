using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saweat.Persistence.Migrations
{
    public partial class ChangeFoodPlates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FoodPlates",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(30)",
                oldFixedLength: true,
                oldMaxLength: 30);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FoodPlates",
                type: "nchar(30)",
                fixedLength: true,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100);
        }
    }
}
