namespace Yard_Scan_API.Models.UnitDtos
{
    public class TrackInUnitDto
    {
        public string Serial { get; set; }
        public int ZoneId { get; set; }
        public int SubZoneId { get; set; }
        public int Space { get; set; }
        public DateTime TrackInDate { get; set; }
        public string? Comment { get; set; }
    }
}
