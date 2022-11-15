using System.ComponentModel.DataAnnotations;

namespace Yard_Scan_API.Data.Entities
{
    public class SubZone
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string subName { get; set; } = string.Empty;

        public Zone Zone { get; set; }

        [Required]
        public int Spaces { get; set; }

        public Boolean Status { get; set; }
        public double UsagePercentage { get; private set; }

        public ICollection<Unit> Units { get; set; }
    }
}
