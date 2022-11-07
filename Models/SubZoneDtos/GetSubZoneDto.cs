namespace Yard_Scan_API.Models.SubZoneDtos
{
    public class GetSubZoneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string subName { get; set; }
        public int ZoneId { get; set; }
        public int Spaces { get; set; }
        public Boolean Status { get; set; }

    }
}
