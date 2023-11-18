using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturants.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Resturant_ResturantId",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "ResturantId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Resturant_ResturantId",
                table: "Order",
                column: "ResturantId",
                principalTable: "Resturant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Resturant_ResturantId",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "ResturantId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Resturant_ResturantId",
                table: "Order",
                column: "ResturantId",
                principalTable: "Resturant",
                principalColumn: "Id");
        }
    }
}
