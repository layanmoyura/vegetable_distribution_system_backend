using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_platform_for_vegetables.Migrations
{
    public partial class farmerproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VegetableStocks_Farmers_FarmerId",
                table: "VegetableStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_VegetableStocks_Vegetables_VegetablesId",
                table: "VegetableStocks");

            migrationBuilder.DropIndex(
                name: "IX_VegetableStocks_FarmerId",
                table: "VegetableStocks");

            migrationBuilder.DropIndex(
                name: "IX_VegetableStocks_VegetablesId",
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
                name: "Updated_Time",
                table: "VegetableStocks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "VegetableStocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "VegetableStocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discription",
                table: "VegetableStocks");

            migrationBuilder.AlterColumn<int>(
                name: "VegetablesId",
                table: "VegetableStocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_Time",
                table: "VegetableStocks",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "VegetableStocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_VegetableStocks_FarmerId",
                table: "VegetableStocks",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_VegetableStocks_VegetablesId",
                table: "VegetableStocks",
                column: "VegetablesId");

            migrationBuilder.AddForeignKey(
                name: "FK_VegetableStocks_Farmers_FarmerId",
                table: "VegetableStocks",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VegetableStocks_Vegetables_VegetablesId",
                table: "VegetableStocks",
                column: "VegetablesId",
                principalTable: "Vegetables",
                principalColumn: "VegetablesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
