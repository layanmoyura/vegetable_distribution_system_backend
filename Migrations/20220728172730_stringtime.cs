using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_platform_for_vegetables.Migrations
{
    public partial class stringtime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vegetables_Admins_AdminId",
                table: "Vegetables");

            migrationBuilder.DropIndex(
                name: "IX_Vegetables_AdminId",
                table: "Vegetables");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Vegetables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Last_Updated_Time",
                table: "Vegetables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Last_Updated_Time",
                table: "Vegetables");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Vegetables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Vegetables_AdminId",
                table: "Vegetables",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vegetables_Admins_AdminId",
                table: "Vegetables",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
