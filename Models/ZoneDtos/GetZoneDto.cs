using System.ComponentModel.DataAnnotations;

namespace Yard_Scan_API.Dtos.Zone
{
    public class GetZoneDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public Boolean Status { get; set; }

    }
}
