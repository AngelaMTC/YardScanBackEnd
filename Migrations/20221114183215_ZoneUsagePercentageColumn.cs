using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    public partial class ZoneUsagePercentageColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "UsagePercentage",
                table: "Zones",
                type: "float",
                nullable: false,
                computedColumnSql: "dbo.zone_usage_percentage([Id])");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsagePercentage",
                table: "Zones");
        }
    }
}
