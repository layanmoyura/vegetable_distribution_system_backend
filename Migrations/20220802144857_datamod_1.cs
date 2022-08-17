using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_platform_for_vegetables.Migrations
{
    public partial class datamod_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Stock_image",
                table: "VegetableStocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock_image",
                table: "VegetableStocks");
        }
    }
}
