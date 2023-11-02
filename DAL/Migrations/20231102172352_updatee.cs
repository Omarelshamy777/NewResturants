using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resturant_Menu_MenuId",
                table: "Resturant");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Resturant",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Resturant_Menu_MenuId",
                table: "Resturant",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resturant_Menu_MenuId",
                table: "Resturant");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Resturant",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Resturant_Menu_MenuId",
                table: "Resturant",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "MenuId");
        }
    }
}
