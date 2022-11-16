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
        public bool Status { get; set; }
        public DateTime TrackInDate { get; set; }
        public DateTime? TrackOutDate { get; set; }
        public string? Comment { get; set; }
        public string? OfflineDate { get; set; }
        public string? Destination { get; set; }
        public string? Color { get; set; }
        public string? OpenDefects { get; set; }
        public string? Part { get; set; }
        public string? ETA { get; set; }
    }
}
