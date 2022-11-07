namespace Yard_Scan_API.Services.SubZoneService
{
    public interface ISubZoneService
    {
        Task<ServiceResponse<List<GetSubZoneDto>>> GetAllSubZones();
        Task<ServiceResponse<List<GetSubZoneDto>>> GetSubZonesByZoneId(int id);
        Task<ServiceResponse<GetSubZoneDto>> AddSubZone(AddSubZoneDto newSubZone);
        Task<ServiceResponse<GetSubZoneDto>> UpdateSubZone(int id, UpdateSubZoneDto updatedSubZone);
        Task<ServiceResponse<List<GetSubZoneDto>>> DeleteSubZone(int id);

    }
}
