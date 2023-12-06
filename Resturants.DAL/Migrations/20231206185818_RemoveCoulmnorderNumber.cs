using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturants.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCoulmnorderNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Oreders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Oreders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
