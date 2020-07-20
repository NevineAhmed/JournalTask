using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class n2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "id",
                keyValue: 1,
                column: "publish_time",
                value: "7/18/2020 1:30:27 PM");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "id",
                keyValue: 2,
                column: "publish_time",
                value: "7/18/2020 1:30:27 PM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "id",
                keyValue: 1,
                column: "publish_time",
                value: "7/18/2020 10:16:25 AM");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "id",
                keyValue: 2,
                column: "publish_time",
                value: "7/18/2020 10:16:25 AM");
        }
    }
}
