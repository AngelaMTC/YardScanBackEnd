using System.ComponentModel.DataAnnotations;

namespace Yard_Scan_API.Dtos.Zone
{
    public class AddZoneDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public Boolean Status { get; set; }

    }
}
