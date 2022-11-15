using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    public partial class GetCapacityandTrackOutZoneView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
            create function [dbo].[zone_usage_percentage]
            (
                @zoneId int
            )

                returns float
                as
                begin
                    declare @result float, @totalSpaces float, @totalUnits float

            -- Get total spaces
                select @totalSpaces = sum(sz.Spaces)
                from SubZones sz
                where sz.ZoneId = @zoneId

            -- Get all the vehicles in the zone
                select @totalUnits = count(u.Id)
                from Units u
                where u.ZoneId = @zoneId

                set @result = round(@totalUnits/@totalSpaces * 100, 2)

                return @result
                    end
                    GO";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view zone_usage_percentage");
        }
    }
}
