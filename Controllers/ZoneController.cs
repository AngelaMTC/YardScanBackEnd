using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Yard_Scan_API.Controllers
{
    [EnableCors("ionic")]
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneService _zoneService;
        private readonly IMapper _mapper;
        public ZoneController(IZoneService zoneService, IMapper mapper)
        {
            _zoneService = zoneService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetZoneDto>>>> Get() => Ok(await _zoneService.GetAllZones());

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetZoneDto>>> GetSingle(int id) => Ok(await _zoneService.GetZoneById(id));

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Zone>>>> AddZone(AddZoneDto newZone) => Ok(await _zoneService.AddZone(newZone));

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetZoneDto>>> UpdateZone(
              UpdateZoneDto updatedZone, int id)
        {
            var response = await _zoneService.UpdateZone(id, updatedZone);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetZoneDto>>>> Delete(int id)
        {
            var response = await _zoneService.DeleteZone(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
