using System.Collections.Generic;
using System.Data;
using Yard_Scan_API.Data.Entities;

namespace Yard_Scan_API.Services.UnitService
{
    public class UnitService : IUnitService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UnitService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetUnitDto>>> GetAllUnits()
        {
            var response = new ServiceResponse<List<GetUnitDto>>();
            var units = await _context.units_on_yard.ToListAsync();

            response.Data = units.Select(u => _mapper.Map<GetUnitDto>(u)).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetUnitDto>> UnitTrackIn(TrackInUnitDto newTrackInUnit)
        {
            var response = new ServiceResponse<GetUnitDto>();

            try
            {
                var inspectUnit = await _context.unit_on_inspect
                    .Where(iu => iu.Serial == newTrackInUnit.Serial)
                    .OrderByDescending(iu => iu.UnitId)
                    .FirstOrDefaultAsync();

                var unit = await _context.Units
                    .FirstOrDefaultAsync(u => u.UnitId == inspectUnit.UnitId);

                var zone = await _context.Zones
                    .FirstOrDefaultAsync(z => z.Id == newTrackInUnit.ZoneId);

                var subZone = await _context.SubZones
                    .FirstOrDefaultAsync(s => s.Id == newTrackInUnit.SubZoneId);

                if (inspectUnit == null)
                {
                    response.Success = false;
                    response.Message = "Unit not found in Inspect!";

                    return response;
                }

                if (zone == null)
                {
                    response.Success = false;
                    response.Message = "Zone not found!";

                    return response;
                }

                if (subZone == null)
                {
                    response.Success = false;
                    response.Message = "Sub zone not found!";

                    return response;
                }

                if (unit == null)
                {
                    var newUnit = new Unit
                    {
                        UnitId = inspectUnit.UnitId,
                        ZoneId = newTrackInUnit.ZoneId,
                        SubZoneId = newTrackInUnit.SubZoneId,
                        Space = newTrackInUnit.Space,
                        TrackInDate = DateTime.Now,
                        Comment = newTrackInUnit.Comment
                    };

                    await _context.Units.AddAsync(newUnit);
                    await _context.SaveChangesAsync();

                    response.Data = _mapper.Map<GetUnitDto>(newUnit);
                    response.Message = "Unit tracked in successfully!";
                }
                else if (unit != null)
                {
                    unit.ZoneId = newTrackInUnit.ZoneId;
                    unit.SubZoneId = newTrackInUnit.SubZoneId;
                    unit.Space = newTrackInUnit.Space;
                    unit.TrackInDate = DateTime.Now;
                    unit.Comment = newTrackInUnit.Comment;

                    await _context.SaveChangesAsync();

                    response.Data = _mapper.Map<GetUnitDto>(unit);
                    response.Message = "Unit tracked in successfully!";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetUnitDto>> UnitTrackOut(TrackOutUnitDto trackOutUnit)
        {
            var response = new ServiceResponse<GetUnitDto>();

            try
            {
                var unit = await _context.Units
                    .FirstOrDefaultAsync(u => u.UnitId == trackOutUnit.UnitId);

                if (unit == null)
                {
                    response.Success = false;
                    response.Message = "Unit does not have a track in date!";

                    return response;
                }
                else
                {
                    unit.ZoneId = 1;
                    unit.SubZoneId = 1;
                    unit.Space = null;
                    unit.TrackOutDate = DateTime.Now;

                    await _context.SaveChangesAsync();

                    response.Data = _mapper.Map<GetUnitDto>(unit);
                    response.Message = "Unit tracked out successfully!";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<GetUnitDto>> UpdateCommentUnit(int UnitId, UpdateCommentUnitDto updatedUnit)
        {
            var response = new ServiceResponse<GetUnitDto>();

            try
            {
                var unitEntity = await _context.Units
                    .FirstOrDefaultAsync(z => z.UnitId == UnitId);

                var Unit = _mapper.Map(updatedUnit, unitEntity);

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetUnitDto>(unitEntity);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetUnitDto>> UpdateStatusUnit(int UnitId, UpdateStatusUnitDto updatedSUnit)
        {
            var response = new ServiceResponse<GetUnitDto>();

            try
            {
                var unitEntity = await _context.Units
                    .FirstOrDefaultAsync(z => z.UnitId == UnitId);

                var Unit = _mapper.Map(updatedSUnit, unitEntity);

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetUnitDto>(unitEntity);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetUnitDto>> GetUnitById(int id)
        {
            var response = new ServiceResponse<GetUnitDto>();
            var unit = await _context.Units.FirstOrDefaultAsync(z => z.Id == id);

            response.Data = _mapper.Map<GetUnitDto>(unit);

            return response;
        }

        // public Task<ServiceResponse<List<GetUnitDto>>> MultipleUnitTrackIn(TrackInUnitDto newTrackInUnit)
        //{
        //  throw new NotImplementedException();
        //}

        public async Task<ServiceResponse<List<GetUnitDto>>> MultipleUnitTrackIn(TrackInUnitDto[] trackInUnits)
        {
            var response = new ServiceResponse<List<GetUnitDto>>();

            foreach (var unit in trackInUnits)
            {
                await UnitTrackIn(unit);
            }

            await _context.SaveChangesAsync();
            response.Message = "Units tracked in successfully!";
            return response;
        }

        public async Task<ServiceResponse<List<GetUnitDto>>> MultipleUnitTrackOut(int trackOutType, int id)
        {
            var response = new ServiceResponse<List<GetUnitDto>>();

            if (trackOutType == 1)
            {
                var units = _context.Units
                    .Where(u => u.ZoneId == id)
                    .ToList();

                foreach (var unit in units)
                {
                    unit.ZoneId = 1;
                    unit.SubZoneId = 1;
                    unit.Space = null;
                    unit.TrackOutDate = DateTime.Now;
                }

                response.Data = _mapper.Map<List<GetUnitDto>>(units);
                response.Message = "Units tracked out successfully!";
            }
            else if (trackOutType == 2)
            {
                var units = _context.Units
                    .Where(u => u.SubZoneId == id)
                    .ToList();

                foreach (var unit in units)
                {
                    unit.ZoneId = 1;
                    unit.SubZoneId = 1;
                    unit.Space = null;
                    unit.TrackOutDate = DateTime.Now;
                }

                response.Data = _mapper.Map<List<GetUnitDto>>(units);
                response.Message = "Units tracked out successfully!";
            }

            await _context.SaveChangesAsync();

            return response;
        }
    }
}