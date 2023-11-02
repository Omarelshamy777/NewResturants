using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrder");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                columns: table => new
                {
                    CustomersCustomerID = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrder", x => new { x.CustomersCustomerID, x.OrderId });
                    table.ForeignKey(
                        name: "FK_CustomerOrder_Customer_CustomersCustomerID",
                        column: x => x.CustomersCustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOrder_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_OrderId",
                table: "CustomerOrder",
                column: "OrderId");
        }
    }
}
