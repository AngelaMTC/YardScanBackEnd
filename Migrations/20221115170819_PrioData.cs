using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    public partial class PrioData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
USE [OnYardCOMPAS]
GO

/****** Object:  View [dbo].[units_on_yard]    Script Date: 11/14/2022 3:45:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
	create view [dbo].[units_on_yard] as
	select
	    yu.UnitId as [UnitId],
	    u.serial as [Serial],
	    dbo.get_zone_text(yu.ZoneId) as [Zone],
	    dbo.get_sub_zone_text(yu.SubZoneId) as [SubZone],
	    yu.[Space] as [Space],
	    yu.TrackInDate as [TrackInDate],
	    yu.TrackOutDate as [TrackOutDate],
		il.R_OFF as [OfflineDate],
		il.DEST as [Destination],
		il.EXT_COL as [Color],
		u.OpenDefects as [OpenDefects],
		rw.Descripcion as [Part],
		rw.ETA as [ETA],
	    yu.Comment as [Comment],
		yu.Prio as [Prio]
	from dbo.Units yu
	join dbo.unit_on_inspect u on u.UnitId = yu.UnitId
	join [10.91.116.139].[INACSLOG].[dbo].[LOG] il on u.Serial collate SQL_Latin1_General_CP1_CI_AS = il.[VIN] collate SQL_Latin1_General_CP1_CI_AS
	left join [10.91.42.20].[ReWork].[dbo].[ReworkActiveVINs] rw on u.Serial collate SQL_Latin1_General_CP1_CI_AS = rw.[VIN] collate SQL_Latin1_General_CP1_CI_AS

GO";
            migrationBuilder.Sql(sql);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view units_on_yard");
        }
    }
}
