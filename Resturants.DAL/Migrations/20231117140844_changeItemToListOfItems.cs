using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturants.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeItemToListOfItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Item_ItemId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ItemId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Order");

            migrationBuilder.CreateTable(
                name: "ItemOrder",
                columns: table => new
                {
                    ItemsItemId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrder", x => new { x.ItemsItemId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ItemOrder_Item_ItemsItemId",
                        column: x => x.ItemsItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOrder_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrder_OrderId",
                table: "ItemOrder",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemOrder");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ItemId",
                table: "Order",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Item_ItemId",
                table: "Order",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
