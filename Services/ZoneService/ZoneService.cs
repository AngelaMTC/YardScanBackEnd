namespace Yard_Scan_API.Services.ZoneService
{
    public class ZoneService : IZoneService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ZoneService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetZoneDto>>> AddZone(AddZoneDto newZone)
        {
            var response = new ServiceResponse<List<GetZoneDto>>();
            var zone = _mapper.Map<Zone>(newZone);
            _context.Zones.Add(zone);
            await _context.SaveChangesAsync();

            response.Data = await _context.Zones
                .Select(z => _mapper.Map<GetZoneDto>(z))
                .ToListAsync();

            return response;
        }

        public async Task<ServiceResponse<List<GetZoneDto>>> GetAllZones()
        {
            var response = new ServiceResponse<List<GetZoneDto>>();
            var zones = await _context.Zones.ToListAsync();

            response.Data = zones.Select(z => _mapper.Map<GetZoneDto>(z)).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetZoneDto>> GetZoneById(int id)
        {
            var response = new ServiceResponse<GetZoneDto>();
            var zone = await _context.Zones.FirstOrDefaultAsync(z => z.Id == id);

            response.Data = _mapper.Map<GetZoneDto>(zone);

            return response;
        }

        public async Task<ServiceResponse<GetZoneDto>> UpdateZone(int id, UpdateZoneDto updatedZone)
        {
            var response = new ServiceResponse<GetZoneDto>();

            try
            {
                var zoneEntity = await _context.Zones
                    .FirstOrDefaultAsync(z => z.Id == id);

                var Zone = _mapper.Map(updatedZone, zoneEntity);

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetZoneDto>(zoneEntity);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetZoneDto>>> DeleteZone(int id)
        {
            var response = new ServiceResponse<List<GetZoneDto>>();

            try
            {
                var zone = await _context.Zones.FirstAsync(z => z.Id == id);
                _context.Zones.Remove(zone);
                await _context.SaveChangesAsync();

                response.Data = _context.Zones.Select(z => _mapper.Map<GetZoneDto>(z)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
