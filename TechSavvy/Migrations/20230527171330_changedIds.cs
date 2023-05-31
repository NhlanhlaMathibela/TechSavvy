using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSavvy.Migrations
{
    public partial class changedIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "empId",
                table: "Purchase_Requests",
                newName: "customerId");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Purchase_Requests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Purchase_Requests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Requests_UserId",
                table: "Purchase_Requests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Requests_AspNetUsers_UserId",
                table: "Purchase_Requests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Requests_AspNetUsers_UserId",
                table: "Purchase_Requests");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_Requests_UserId",
                table: "Purchase_Requests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Purchase_Requests");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Purchase_Requests",
                newName: "empId");

            migrationBuilder.AlterColumn<int>(
                name: "description",
                table: "Purchase_Requests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
