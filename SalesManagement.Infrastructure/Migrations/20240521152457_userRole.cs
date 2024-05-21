using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManagement.Infrastructure.Migrations
{
    public partial class userRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20d42428-d0e8-416a-b843-9f83e37bca97", "7861abdc-0658-4477-8c1c-7d40502ee2c2", "manager", "manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4932ec56-47b6-47fa-a2f6-8c0c8b190abc", "2adaf978-6637-4ab2-bfd3-3688c4764381", "rider", "rider" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be0a4254-9721-419f-843b-3783ef1fc870", "25082e0a-7706-4c79-a2c6-f9eb0261597f", "sr", "sr" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20d42428-d0e8-416a-b843-9f83e37bca97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4932ec56-47b6-47fa-a2f6-8c0c8b190abc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be0a4254-9721-419f-843b-3783ef1fc870");
        }
    }
}
