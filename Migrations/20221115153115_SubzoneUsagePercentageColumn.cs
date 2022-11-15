using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    public partial class SubzoneUsagePercentageColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "UsagePercentage",
                table: "SubZones",
                type: "float",
                nullable: false,
                computedColumnSql: "dbo.subzone_usage_percentage([Id], [Spaces])");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsagePercentage",
                table: "SubZones");
        }
    }
}
