using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    public partial class CreatedSubZonesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    Spaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubZones_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SubZones",
                columns: new[] { "Id", "Name", "Spaces", "ZoneId" },
                values: new object[,]
                {
                    { 1, "A", 14, 1 },
                    { 2, "B", 14, 1 },
                    { 3, "C", 14, 1 },
                    { 4, "D", 19, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubZones_ZoneId",
                table: "SubZones",
                column: "ZoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubZones");
        }
    }
}
