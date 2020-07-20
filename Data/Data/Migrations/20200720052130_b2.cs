using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class b2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "publishes_no",
                table: "Article");

            migrationBuilder.AddColumn<int>(
                name: "NoOfPublishes",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "id",
                keyValue: 1,
                column: "publish_time",
                value: "7/19/2020 10:21:30 PM");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "id",
                keyValue: 2,
                column: "publish_time",
                value: "7/19/2020 10:21:30 PM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfPublishes",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "publishes_no",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "publish_time", "publishes_no" },
                values: new object[] { "7/19/2020 9:57:17 PM", 5 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "publish_time", "publishes_no" },
                values: new object[] { "7/19/2020 9:57:17 PM", 3 });
        }
    }
}
