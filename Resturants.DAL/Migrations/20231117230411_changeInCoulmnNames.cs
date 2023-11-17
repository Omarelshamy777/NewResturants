using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturants.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeInCoulmnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_Item_ItemsItemId",
                table: "ItemOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Resturant_ResturantID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemPrice",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "ResturantName",
                table: "Resturant",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ResturantID",
                table: "Resturant",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ResturantID",
                table: "Order",
                newName: "ResturantId");

            migrationBuilder.RenameColumn(
                name: "OrderNumber",
                table: "Order",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Order",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ResturantID",
                table: "Order",
                newName: "IX_Order_ResturantId");

            migrationBuilder.RenameColumn(
                name: "MenuName",
                table: "Menu",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Menu",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ItemsItemId",
                table: "ItemOrder",
                newName: "ItemsId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Item",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Customer",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Customer",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Item",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Item",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Item",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Customer",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Customer",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customer",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_Item_ItemsId",
                table: "ItemOrder",
                column: "ItemsId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Resturant_ResturantId",
                table: "Order",
                column: "ResturantId",
                principalTable: "Resturant",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_Item_ItemsId",
                table: "ItemOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Resturant_ResturantId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Resturant",
                newName: "ResturantName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Resturant",
                newName: "ResturantID");

            migrationBuilder.RenameColumn(
                name: "ResturantId",
                table: "Order",
                newName: "ResturantID");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Order",
                newName: "OrderNumber");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Order",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ResturantId",
                table: "Order",
                newName: "IX_Order_ResturantID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Menu",
                newName: "MenuName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Menu",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "ItemsId",
                table: "ItemOrder",
                newName: "ItemsItemId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Item",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Customer",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customer",
                newName: "CustomerID");

            migrationBuilder.AddColumn<string>(
                name: "Categories",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ItemPrice",
                table: "Item",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_Item_ItemsItemId",
                table: "ItemOrder",
                column: "ItemsItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Resturant_ResturantID",
                table: "Order",
                column: "ResturantID",
                principalTable: "Resturant",
                principalColumn: "ResturantID");
        }
    }
}
