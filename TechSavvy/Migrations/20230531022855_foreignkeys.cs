using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSavvy.Migrations
{
    public partial class foreignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_Details_Products_ProductId",
                table: "PurchaseOrder_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_Details_Purchase_Requests_RequestId",
                table: "PurchaseOrder_Details");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrder_Details_RequestId",
                table: "PurchaseOrder_Details");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "PurchaseOrder_Details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "PurchaseOrder_Details",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "PurchaseOrder_Details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Purchase_RequestRequestId",
                table: "PurchaseOrder_Details",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_Details_Purchase_RequestRequestId",
                table: "PurchaseOrder_Details",
                column: "Purchase_RequestRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_Details_Products_ProductId",
                table: "PurchaseOrder_Details",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_Details_Purchase_Requests_Purchase_RequestRequestId",
                table: "PurchaseOrder_Details",
                column: "Purchase_RequestRequestId",
                principalTable: "Purchase_Requests",
                principalColumn: "RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_Details_Products_ProductId",
                table: "PurchaseOrder_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_Details_Purchase_Requests_Purchase_RequestRequestId",
                table: "PurchaseOrder_Details");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrder_Details_Purchase_RequestRequestId",
                table: "PurchaseOrder_Details");

            migrationBuilder.DropColumn(
                name: "Purchase_RequestRequestId",
                table: "PurchaseOrder_Details");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "PurchaseOrder_Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "PurchaseOrder_Details",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "PurchaseOrder_Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_Details_RequestId",
                table: "PurchaseOrder_Details",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_Details_Products_ProductId",
                table: "PurchaseOrder_Details",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_Details_Purchase_Requests_RequestId",
                table: "PurchaseOrder_Details",
                column: "RequestId",
                principalTable: "Purchase_Requests",
                principalColumn: "RequestId");
        }
    }
}
