using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    public partial class CreatedGetInspectUnitView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                create view unit_on_inspect as
                select
                    u.unit_id as [UnitId],
                    u.serial as [Serial]
                from InspectCOMPAS.dbo.units u";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view unit_on_inspect");
        }
    }
}
