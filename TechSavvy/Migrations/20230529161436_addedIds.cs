using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSavvy.Migrations
{
    public partial class addedIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequest_Details_Products_ProductId",
                table: "PurchaseRequest_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequest_Details_Purchase_Requests_RequestId",
                table: "PurchaseRequest_Details");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequest_Details_RequestId",
                table: "PurchaseRequest_Details");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "PurchaseRequest_Details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "PurchaseRequest_Details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Purchase_RequestRequestId",
                table: "PurchaseRequest_Details",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PRStatus",
                table: "Purchase_Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequest_Details_Purchase_RequestRequestId",
                table: "PurchaseRequest_Details",
                column: "Purchase_RequestRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequest_Details_Products_ProductId",
                table: "PurchaseRequest_Details",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequest_Details_Purchase_Requests_Purchase_RequestRequestId",
                table: "PurchaseRequest_Details",
                column: "Purchase_RequestRequestId",
                principalTable: "Purchase_Requests",
                principalColumn: "RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequest_Details_Products_ProductId",
                table: "PurchaseRequest_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequest_Details_Purchase_Requests_Purchase_RequestRequestId",
                table: "PurchaseRequest_Details");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequest_Details_Purchase_RequestRequestId",
                table: "PurchaseRequest_Details");

            migrationBuilder.DropColumn(
                name: "Purchase_RequestRequestId",
                table: "PurchaseRequest_Details");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "PurchaseRequest_Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "PurchaseRequest_Details",
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

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequest_Details_RequestId",
                table: "PurchaseRequest_Details",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequest_Details_Products_ProductId",
                table: "PurchaseRequest_Details",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequest_Details_Purchase_Requests_RequestId",
                table: "PurchaseRequest_Details",
                column: "RequestId",
                principalTable: "Purchase_Requests",
                principalColumn: "RequestId");
        }
    }
}
