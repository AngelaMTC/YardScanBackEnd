namespace Yard_Scan_API.Services.UnitService
{
    public interface IUnitService
    {
        Task<ServiceResponse<List<GetUnitDto>>> GetAllUnits();
        Task<ServiceResponse<GetUnitDto>> UnitTrackIn(TrackInUnitDto newTrackInUnit);
        Task<ServiceResponse<GetUnitDto>> UnitTrackOut(TrackOutUnitDto trackOutUnit);
        Task<ServiceResponse<GetUnitDto>> UpdateCommentUnit(int id, UpdateCommentUnitDto updatedUnit);
        Task<ServiceResponse<GetUnitDto>> UpdateStatusUnit(int id, UpdateStatusUnitDto updatedSUnit);
        Task<ServiceResponse<GetUnitDto>> GetUnitById(int id);
        Task<ServiceResponse<List<GetUnitDto>>> MultipleUnitTrackOut(int trackOutType, int id);
        Task<ServiceResponse<List<GetUnitDto>>> MultipleUnitTrackIn(TrackInUnitDto[] trackInUnits);
    }
}
