namespace Yard_Scan_API.Data.Views
{
    [Keyless]
    public class UnitOnYardView
    {
        public int UnitId { get; set; }
        public string Serial { get; set; }
        public string Zone { get; set; }
        public string SubZone { get; set; }
        public int? Space { get; set; }
        public DateTime TrackInDate { get; set; }
        public DateTime? TrackOutDate { get; set; }
        public string? Comment { get; set; }
    }
}
