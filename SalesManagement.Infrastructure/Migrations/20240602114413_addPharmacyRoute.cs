using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManagement.Infrastructure.Migrations
{
    public partial class addPharmacyRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19f3d7f9-31ae-469f-a014-d93d9bd3e015");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f2bb286-5b25-45e0-9781-aec707ec1342");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d87ca71-52a6-4fe9-9894-182ee73d0638");

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Pharmacies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PharmacyRoute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyRoute", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_RouteId",
                table: "Pharmacies",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_PharmacyRoute_RouteId",
                table: "Pharmacies",
                column: "RouteId",
                principalTable: "PharmacyRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade,onUpdate: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_PharmacyRoute_RouteId",
                table: "Pharmacies");

            migrationBuilder.DropTable(
                name: "PharmacyRoute");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacies_RouteId",
                table: "Pharmacies");

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

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Pharmacies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19f3d7f9-31ae-469f-a014-d93d9bd3e015", "ed59f835-515b-494c-8147-b1374a9869a9", "rider", "rider" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f2bb286-5b25-45e0-9781-aec707ec1342", "9affb145-eb9f-49f6-a99d-bcbc337278c8", "sr", "sr" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d87ca71-52a6-4fe9-9894-182ee73d0638", "b95f262c-3f83-4668-9864-c07a81f03b25", "manager", "manager" });
        }
    }
}
