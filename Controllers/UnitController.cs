using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Yard_Scan_API.Controllers
{
    [EnableCors("ionic")]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetUnitDto>>>> Get() => Ok(await _unitService.GetAllUnits());

        [HttpPost("TrackIn")]
        public async Task<ActionResult> UnitTrackIn(TrackInUnitDto trackInUnit) => Ok(await _unitService.UnitTrackIn(trackInUnit));

        [HttpPut("TrackOut")]
        public async Task<ActionResult> UnitTrackOut(TrackOutUnitDto trackOutUnit) => Ok(await _unitService.UnitTrackOut(trackOutUnit));

        [HttpPut("{Id}")]
        public async Task<ActionResult<ServiceResponse<GetZoneDto>>> UpdateCommentUnitDto(
              UpdateCommentUnitDto updatedUnit, int id)
        {
            var response = await _unitService.UpdateCommentUnit(id, updatedUnit);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUnitDto>>> GetSingle(int id) => Ok(await _unitService.GetUnitById(id));

    }
}
