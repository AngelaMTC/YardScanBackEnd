namespace Yard_Scan_API.Services.SubZoneService
{
    public class SubZoneService : ISubZoneService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public SubZoneService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetSubZoneDto>> AddSubZone(AddSubZoneDto newSubZone)
        {
            var response = new ServiceResponse<GetSubZoneDto>();

            try
            {
                var zone = await _context.Zones
                .FirstOrDefaultAsync(s => s.Id == newSubZone.ZoneId);

                if (zone == null)
                {
                    response.Success = false;
                    response.Message = "SubZone not found!";

                    return response;
                }

                var subZone = new SubZone
                {
                    Name = newSubZone.Name,
                    subName = newSubZone.subName,
                    Zone = zone,
                    Spaces = newSubZone.Spaces,
                    Status = newSubZone.Status
                };

                await _context.SubZones.AddAsync(subZone);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetSubZoneDto>(subZone);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetSubZoneDto>>> GetAllSubZones()
        {
            var response = new ServiceResponse<List<GetSubZoneDto>>();
            var subZones = await _context.SubZones
                .Include(s => s.Zone)
                .ToListAsync();

            response.Data = subZones.Select(s => _mapper.Map<GetSubZoneDto>(s)).ToList();

            return response;
        }
        
        public async Task<ServiceResponse<List<GetSubZoneDto>>> GetSubZonesByZoneId(int id)
        {
            var response = new ServiceResponse<List<GetSubZoneDto>>();

            var subZones = await _context.SubZones
                .Include(s => s.Zone)
                .Where(s => s.Zone.Id == id)
                .ToListAsync();

            response.Data = subZones.Select(s => _mapper.Map<GetSubZoneDto>(s)).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetSubZoneDto>> UpdateSubZone(int id, UpdateSubZoneDto updatedSubZone)
        {
            var response = new ServiceResponse<GetSubZoneDto>();

            try
            {
                var subZoneEntity = await _context.SubZones
                    .FirstOrDefaultAsync(z => z.Id == id);

                var SubZone = _mapper.Map(updatedSubZone, subZoneEntity);

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetSubZoneDto>(subZoneEntity);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<List<GetSubZoneDto>>> DeleteSubZone(int id)
        {
            var response = new ServiceResponse<List<GetSubZoneDto>>();

            try
            {
                var subzone = await _context.SubZones.FirstAsync(z => z.Id == id);
                _context.SubZones.Remove(subzone);
                await _context.SaveChangesAsync();

                response.Data = _context.SubZones.Select(z => _mapper.Map<GetSubZoneDto>(z)).ToList();
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
