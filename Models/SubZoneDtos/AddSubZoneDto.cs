using System.ComponentModel.DataAnnotations;

namespace Yard_Scan_API.Models.SubZoneDtos
{
    public class AddSubZoneDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string subName { get; set; } = string.Empty;

        [Required]
        public int ZoneId { get; set; }

        [Required]
        public int Spaces { get; set; }
        [Required]
        public Boolean Status { get; set; }
    }
}
