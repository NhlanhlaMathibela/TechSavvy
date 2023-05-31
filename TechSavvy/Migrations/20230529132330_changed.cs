using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSavvy.Migrations
{
    public partial class changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Requests_Products_productId",
                table: "Purchase_Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_Details_Purchase_Orders_OrderId",
                table: "PurchaseOrder_Details");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PurchaseOrder_Details");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Purchase_Requests");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Purchase_Requests");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "PurchaseOrder_Details",
                newName: "RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrder_Details_OrderId",
                table: "PurchaseOrder_Details",
                newName: "IX_PurchaseOrder_Details_RequestId");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Purchase_Requests",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_Requests_productId",
                table: "Purchase_Requests",
                newName: "IX_Purchase_Requests_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Purchase_Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PRStatus",
                table: "Purchase_Requests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Requests_Products_ProductId",
                table: "Purchase_Requests",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Requests_Products_ProductId",
                table: "Purchase_Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_Details_Purchase_Requests_RequestId",
                table: "PurchaseOrder_Details");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "PurchaseOrder_Details",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrder_Details_RequestId",
                table: "PurchaseOrder_Details",
                newName: "IX_PurchaseOrder_Details_OrderId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Purchase_Requests",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_Requests_ProductId",
                table: "Purchase_Requests",
                newName: "IX_Purchase_Requests_productId");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "PurchaseOrder_Details",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "Purchase_Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PRStatus",
                table: "Purchase_Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Purchase_Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Purchase_Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Requests_Products_productId",
                table: "Purchase_Requests",
                column: "productId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_Details_Purchase_Orders_OrderId",
                table: "PurchaseOrder_Details",
                column: "OrderId",
                principalTable: "Purchase_Orders",
                principalColumn: "OrderID");
        }
    }
}
