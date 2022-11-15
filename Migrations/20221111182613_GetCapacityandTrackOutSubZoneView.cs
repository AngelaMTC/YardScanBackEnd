using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    public partial class GetCapacityandTrackOutSubZoneView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
             create  function [dbo].[subzone_usage_percentage]
            (
                @subZoneId   int,
                @spaces      float
            )
                returns float
            as
            begin
                declare @result float, @subZoneUnits float

            -- Get the vehicles in the sub zone
                select @subZoneUnits = count(u.Id)
                from Units u
                where u.SubZoneId = @subZoneId

              set @result = round(@subZoneUnits/@spaces * 100, 2)

            return @result
                end
                GO";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view subzone_usage_percentage");
        }
    }
}
