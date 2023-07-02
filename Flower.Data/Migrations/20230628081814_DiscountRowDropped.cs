using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flowers.Data.Migrations
{
    public partial class DiscountRowDropped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Flowers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercent",
                table: "Flowers",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
