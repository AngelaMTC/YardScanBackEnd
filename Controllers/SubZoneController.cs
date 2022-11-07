using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Yard_Scan_API.Controllers
{
    [EnableCors("ionic")]
    [Route("api/[controller]")]
    [ApiController]
    public class SubZoneController : ControllerBase
    {
        private readonly ISubZoneService _subZoneService;

        public SubZoneController(ISubZoneService subZoneService)
        {
            _subZoneService = subZoneService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetSubZoneDto>>>> Get() => Ok(await _subZoneService.GetAllSubZones());

        [HttpGet("GetByZoneId")]
        public async Task<ActionResult<ServiceResponse<List<GetSubZoneDto>>>> GetSubZonesByZoneId(int id) => Ok(await _subZoneService.GetSubZonesByZoneId(id));

        [HttpPost]
        public async Task<ActionResult> AddSubZone(AddSubZoneDto newSubZone) => Ok(await _subZoneService.AddSubZone(newSubZone));

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSubZoneDto>>> UpdateSubZone(
              UpdateSubZoneDto updatedSubZone, int id)
        {
            var response = await _subZoneService.UpdateSubZone(id, updatedSubZone);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetSubZoneDto>>>> DeleteSubZone(int id)
        {
            var response = await _subZoneService.DeleteSubZone(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
