using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_platform_for_vegetables.Migrations
{
    public partial class m55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vegetables_Admins_AdminId",
                table: "Vegetables");

            migrationBuilder.DropForeignKey(
                name: "FK_VegetableStocks_Farmers_FarmerId",
                table: "VegetableStocks");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "VegetableStocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Vegetables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vegetables_Admins_AdminId",
                table: "Vegetables",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VegetableStocks_Farmers_FarmerId",
                table: "VegetableStocks",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vegetables_Admins_AdminId",
                table: "Vegetables");

            migrationBuilder.DropForeignKey(
                name: "FK_VegetableStocks_Farmers_FarmerId",
                table: "VegetableStocks");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "VegetableStocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Vegetables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vegetables_Admins_AdminId",
                table: "Vegetables",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VegetableStocks_Farmers_FarmerId",
                table: "VegetableStocks",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
