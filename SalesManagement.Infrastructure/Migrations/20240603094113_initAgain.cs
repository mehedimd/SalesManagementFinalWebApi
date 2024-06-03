using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManagement.Infrastructure.Migrations
{
    public partial class initAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f964105-63d8-4e3e-bf10-ea4abaeeb06f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57c4a678-12e2-44a5-8d04-cf5817981f68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67dd35a1-65a4-43e2-8c7d-9b27f3ce33cb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f964105-63d8-4e3e-bf10-ea4abaeeb06f", "4d67151e-82c0-438e-a1d6-3c69eac9ca87", "manager", "manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57c4a678-12e2-44a5-8d04-cf5817981f68", "e91dad29-e525-4583-9bab-fb6815486e53", "rider", "rider" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "67dd35a1-65a4-43e2-8c7d-9b27f3ce33cb", "89b453ee-69ff-4cae-985f-46dcdda4f82e", "sr", "sr" });
        }
    }
}
