using System.ComponentModel.DataAnnotations;

namespace Yard_Scan_API.Data.Entities
{
    public class Zone
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public bool Status { get; set; }


        public double UsagePercentage { get; private set; }


        public ICollection<SubZone> SubZones { get; set; }
        public ICollection<Unit> Units { get; set; }
    }
}
