using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceCustomerOrder.Migrations
{
    public partial class password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Roll",
                table: "Roll");

            migrationBuilder.RenameTable(
                name: "Roll",
                newName: "Role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "RollId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roll");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roll",
                table: "Roll",
                column: "RollId");
        }
    }
}
