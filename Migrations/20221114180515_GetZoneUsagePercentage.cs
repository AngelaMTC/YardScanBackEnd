using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    public partial class GetZoneUsagePercentage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Alex Cornejo
-- Create date: 2022-11-10
-- Description:	Calculate zone usage percentage
-- Usage: Yard scan API
-- =============================================

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

    if (@result is null)
    begin
        set @result = 0
    end

    return @result
end
GO";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop function zone_usage_percentage");
        }
    }
}
