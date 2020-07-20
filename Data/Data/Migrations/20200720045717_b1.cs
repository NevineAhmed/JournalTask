using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class b1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Article",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "description", "publish_time" },
                values: new object[] { "fffoooooooooooooooooooooooooooooooooooooooooooooooooo", "7/19/2020 9:57:17 PM" });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "description", "publish_time" },
                values: new object[] { "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn", "7/19/2020 9:57:17 PM" });

            migrationBuilder.CreateIndex(
                name: "IX_Article_ApplicationUserId",
                table: "Article",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_AspNetUsers_ApplicationUserId",
                table: "Article",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_AspNetUsers_ApplicationUserId",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_ApplicationUserId",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Article");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "description", "publish_time" },
                values: new object[] { "fffooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo", "7/18/2020 1:30:27 PM" });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "description", "publish_time" },
                values: new object[] { "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn", "7/18/2020 1:30:27 PM" });
        }
    }
}
