using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    public partial class subzones_addSubName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "subName",
                table: "SubZones",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 1,
                column: "subName",
                value: "subName");

            migrationBuilder.UpdateData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 2,
                column: "subName",
                value: "asdfghjklñ");

            migrationBuilder.UpdateData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 3,
                column: "subName",
                value: "Example");

            migrationBuilder.UpdateData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 4,
                column: "subName",
                value: "");

            migrationBuilder.UpdateData(
                table: "SubZones",
                keyColumn: "Id",
                keyValue: 99,
                column: "subName",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "subName",
                table: "SubZones");
        }
    }
}
