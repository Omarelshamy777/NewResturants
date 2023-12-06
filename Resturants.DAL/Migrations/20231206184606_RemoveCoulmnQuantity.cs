using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturants.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCoulmnQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Items",
                type: "int",
                nullable: true);
        }
    }
}
