using System.ComponentModel.DataAnnotations;

namespace Yard_Scan_API.Models.UnitDtos
{
    public class UpdateCommentUnitDto
    {
        [Required]
        public string Comment { get; set; } = string.Empty;

    }
}
