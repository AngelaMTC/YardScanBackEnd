using Microsoft.EntityFrameworkCore;

namespace Yard_Scan_API.Services.ZoneService
{
    public interface IZoneService
    {
        Task<ServiceResponse<List<GetZoneDto>>> GetAllZones();
        Task<ServiceResponse<GetZoneDto>> GetZoneById(int id);
        Task<ServiceResponse<List<GetZoneDto>>> AddZone(AddZoneDto newZone);
        Task<ServiceResponse<GetZoneDto>> UpdateZone(int id, UpdateZoneDto updatedZone);
        Task<ServiceResponse<List<GetZoneDto>>> DeleteZone(int id);
    }
}
