using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    public partial class CreatedGetUnitsView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                create view units_on_yard as
                select
                    yu.UnitId as [UnitId],
                    u.serial as [Serial],
                    dbo.get_zone_text(yu.ZoneId) as [Zone],
                    dbo.get_sub_zone_text(yu.SubZoneId) as [SubZone],
                    yu.[Space] as [Space],
                    yu.TrackInDate as [TrackInDate],
                    yu.TrackOutDate as [TrackOutDate],
                    yu.Comment as [Comment]
                from OnYardCOMPAS.dbo.Units yu
                join InspectCOMPASTest.dbo.units u on u.unit_id = yu.UnitId";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view units_on_yard");
        }
    }
}
