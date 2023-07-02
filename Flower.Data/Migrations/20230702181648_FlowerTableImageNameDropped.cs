using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flowers.Data.Migrations
{
    public partial class FlowerTableImageNameDropped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Flowers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
