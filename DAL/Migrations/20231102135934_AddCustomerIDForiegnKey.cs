using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerIDForiegnKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomersCustomerID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomersCustomerID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomersCustomerID",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerID",
                table: "Order",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerID",
                table: "Order",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "CustomersCustomerID",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomersCustomerID",
                table: "Order",
                column: "CustomersCustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomersCustomerID",
                table: "Order",
                column: "CustomersCustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID");
        }
    }
}
