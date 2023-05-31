using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSavvy.Migrations
{
    public partial class addedPRequestColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Purchase_Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "description",
                table: "Purchase_Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "empId",
                table: "Purchase_Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Purchase_Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Requests_productId",
                table: "Purchase_Requests",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Requests_Products_productId",
                table: "Purchase_Requests",
                column: "productId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Requests_Products_productId",
                table: "Purchase_Requests");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_Requests_productId",
                table: "Purchase_Requests");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Purchase_Requests");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Purchase_Requests");

            migrationBuilder.DropColumn(
                name: "empId",
                table: "Purchase_Requests");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Purchase_Requests");
        }
    }
}
