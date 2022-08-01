using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_platform_for_vegetables.Migrations
{
    public partial class m18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VegetableStocks_Vegetables_VegetablesId",
                table: "VegetableStocks");

            migrationBuilder.AlterColumn<int>(
                name: "VegetablesId",
                table: "VegetableStocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Deadline",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VegetableStocks_Vegetables_VegetablesId",
                table: "VegetableStocks",
                column: "VegetablesId",
                principalTable: "Vegetables",
                principalColumn: "VegetablesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VegetableStocks_Vegetables_VegetablesId",
                table: "VegetableStocks");

            migrationBuilder.AlterColumn<int>(
                name: "VegetablesId",
                table: "VegetableStocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Deadline",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_VegetableStocks_Vegetables_VegetablesId",
                table: "VegetableStocks",
                column: "VegetablesId",
                principalTable: "Vegetables",
                principalColumn: "VegetablesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
