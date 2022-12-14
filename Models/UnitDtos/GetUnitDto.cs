namespace Yard_Scan_API.Models.UnitDtos
{
    public class GetUnitDto
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public string Serial { get; set; }
        public string Zone { get; set; }
        public string SubZone { get; set; }
        public int Space { get; set; }
        public string TrackInDate { get; set; }
        public string TrackOutDate { get; set; }
        public string Comment { get; set; }
        public string? OfflineDate { get; set; }
        public string? Destination { get; set; }
        public string? Color { get; set; }
        public string? OpenDefects { get; set; }
        public string? Part { get; set; }
        public string? ETA { get; set; }
        public bool Status { get; set; }
    }
}
