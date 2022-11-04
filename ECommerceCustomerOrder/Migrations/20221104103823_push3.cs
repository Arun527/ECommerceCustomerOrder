using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceCustomerOrder.Migrations
{
    public partial class push3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Customer_CustomerId",
                table: "orders",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Customer_CustomerId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_CustomerId",
                table: "orders");
        }
    }
}
