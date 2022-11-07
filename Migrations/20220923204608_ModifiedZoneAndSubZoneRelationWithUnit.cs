using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    public partial class ModifiedZoneAndSubZoneRelationWithUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Units_SubZoneId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_ZoneId",
                table: "Units");

            migrationBuilder.CreateIndex(
                name: "IX_Units_SubZoneId",
                table: "Units",
                column: "SubZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ZoneId",
                table: "Units",
                column: "ZoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Units_SubZoneId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_ZoneId",
                table: "Units");

            migrationBuilder.CreateIndex(
                name: "IX_Units_SubZoneId",
                table: "Units",
                column: "SubZoneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_ZoneId",
                table: "Units",
                column: "ZoneId",
                unique: true);
        }
    }
}
