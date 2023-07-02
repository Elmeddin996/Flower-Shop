using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flowers.Data.Migrations
{
    public partial class FlowerImageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Flowers");

            migrationBuilder.CreateTable(
                name: "FlowerImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowerId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosterStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowerImage_Flowers_FlowerId",
                        column: x => x.FlowerId,
                        principalTable: "Flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlowerImage_FlowerId",
                table: "FlowerImage",
                column: "FlowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowerImage");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
