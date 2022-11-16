using System.ComponentModel.DataAnnotations;

namespace Yard_Scan_API.Models.UnitDtos
{
    public class UpdateStatusUnitDto
    {
        [Required]
        public bool Status { get; set; }
    }
}
