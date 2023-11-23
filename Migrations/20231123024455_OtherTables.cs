using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpest.Migrations
{
    /// <inheritdoc />
    public partial class OtherTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetailModel",
                table: "OrderDetailModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerModel",
                table: "CustomerModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardModel",
                table: "CardModel");

            migrationBuilder.RenameTable(
                name: "OrderModel",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "OrderDetailModel",
                newName: "orderDetails");

            migrationBuilder.RenameTable(
                name: "CustomerModel",
                newName: "customers");

            migrationBuilder.RenameTable(
                name: "CardModel",
                newName: "cards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderDetails",
                table: "orderDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cards",
                table: "cards",
                column: "Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderDetails",
                table: "orderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cards",
                table: "cards");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "OrderModel");

            migrationBuilder.RenameTable(
                name: "orderDetails",
                newName: "OrderDetailModel");

            migrationBuilder.RenameTable(
                name: "customers",
                newName: "CustomerModel");

            migrationBuilder.RenameTable(
                name: "cards",
                newName: "CardModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetailModel",
                table: "OrderDetailModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerModel",
                table: "CustomerModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardModel",
                table: "CardModel",
                column: "Number");
        }
    }
}
