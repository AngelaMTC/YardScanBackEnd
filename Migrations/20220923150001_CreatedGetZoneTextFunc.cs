using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    public partial class CreatedGetZoneTextFunc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
create function [dbo].[get_zone_text]
(
	@zoneId     int
)
returns varchar(50)
as
begin
    declare @result nvarchar(50)

    select @result = z.name
    from Zones z
    where z.id = @zoneId

    return @result
end
GO";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop function get_zone_text");
        }
    }
}
