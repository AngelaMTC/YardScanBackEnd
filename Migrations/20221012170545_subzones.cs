using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    public partial class subzones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubZones",
                columns: new[] { "Id", "Name", "Spaces", "ZoneId", "subName" },
                values: new object[,]
                {
                    { 5, "E", 14, 1, "subName" },
                    { 6, "F", 14, 1, "subName" },
                    { 7, "G", 14, 1, "subName" },
                    { 8, "H", 14, 1, "subName" },
                    { 9, "I", 14, 1, "subName" },
                    { 10, "J", 14, 1, "subName" },
                    { 11, "K", 14, 1, "subName" },
                    { 12, "L", 14, 1, "subName" },
                    { 13, "M", 14, 1, "subName" },
                    { 14, "N", 14, 1, "subName" },
                    { 15, "O", 14, 1, "subName" },
                    { 16, "P", 14, 1, "subName" },
                    { 17, "Q", 14, 1, "subName" },
                    { 18, "R", 14, 1, "subName" },
                    { 19, "S", 14, 1, "subName" },
                    { 20, "T", 14, 1, "subName" },
                    { 21, "U", 14, 1, "subName" },
                    { 22, "V", 14, 1, "subName" },
                    { 23, "Y", 14, 1, "subName" },
                    { 24, "Z", 14, 1, "subName" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
