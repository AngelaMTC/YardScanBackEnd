namespace Yard_Scan_API.Profiles
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<UnitOnYardView, GetUnitDto>();
            CreateMap<Unit, GetUnitDto>();
            CreateMap<TrackInUnitDto, Unit>();
            CreateMap<TrackOutUnitDto, Unit>();
            CreateMap<UpdateCommentUnitDto, Unit>();

        }
    }
}
