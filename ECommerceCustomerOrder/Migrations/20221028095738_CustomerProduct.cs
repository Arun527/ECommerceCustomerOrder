using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceCustomerOrder.Migrations
{
    public partial class CustomerProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Customer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customer");
        }
    }
}
