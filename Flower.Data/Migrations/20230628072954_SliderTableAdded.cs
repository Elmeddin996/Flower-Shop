using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flowers.Data.Migrations
{
    public partial class SliderTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowerImage_Flowers_FlowerId",
                table: "FlowerImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlowerImage",
                table: "FlowerImage");

            migrationBuilder.RenameTable(
                name: "FlowerImage",
                newName: "FlowerImages");

            migrationBuilder.RenameIndex(
                name: "IX_FlowerImage_FlowerId",
                table: "FlowerImages",
                newName: "IX_FlowerImages_FlowerId");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalePrice",
                table: "Flowers",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Flowers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "Flowers",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CostPrice",
                table: "Flowers",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlowerImages",
                table: "FlowerImages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerImages_Flowers_FlowerId",
                table: "FlowerImages",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowerImages_Flowers_FlowerId",
                table: "FlowerImages");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlowerImages",
                table: "FlowerImages");

            migrationBuilder.RenameTable(
                name: "FlowerImages",
                newName: "FlowerImage");

            migrationBuilder.RenameIndex(
                name: "IX_FlowerImages_FlowerId",
                table: "FlowerImage",
                newName: "IX_FlowerImage_FlowerId");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalePrice",
                table: "Flowers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "Flowers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "CostPrice",
                table: "Flowers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlowerImage",
                table: "FlowerImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerImage_Flowers_FlowerId",
                table: "FlowerImage",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
