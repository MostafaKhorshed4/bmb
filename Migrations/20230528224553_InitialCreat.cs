using Microsoft.EntityFrameworkCore.Migrations;

namespace bmb.Migrations
{
    public partial class InitialCreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_customerId",
                table: "orders");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_customerId",
                table: "orders",
                column: "customerId",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_customerId",
                table: "orders");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_customerId",
                table: "orders",
                column: "customerId",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
