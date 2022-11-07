namespace Yard_Scan_API.Data.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public int UnitId { get; set; }

        public int ZoneId { get; set; }
        public Zone Zone { get; set; }

        public int SubZoneId { get; set; }
        public SubZone SubZone { get; set; }

        public int? Space { get; set; }

        public DateTime TrackInDate { get; set; }
        public DateTime? TrackOutDate { get; set; }
        public string? Comment { get; set; }
    }
}
