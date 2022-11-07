using System.ComponentModel.DataAnnotations;

namespace Yard_Scan_API.Models.SubZoneDtos
{
    public class UpdateSubZoneDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string subName { get; set; } = string.Empty;

        [Required]
        public int ZoneId { get; set; }

        [Required]
        public int Spaces { get; set; }
        public Boolean Status { get; set; }

    }
}
