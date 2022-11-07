using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    public partial class CreatedGetSubZoneTextFunc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
create function [dbo].[get_sub_zone_text]
(
	@subZoneId     int
)
returns varchar(50)
as
begin
    declare @result nvarchar(50)

    select @result = z.name
    from SubZones z
    where z.id = @subZoneId

    return @result
end
go";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop function get_sub_zone_text");
        }
    }
}
