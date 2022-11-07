namespace Yard_Scan_API.Profiles
{
    public class SubZoneProfile : Profile
    {
        public SubZoneProfile()
        {
            CreateMap<SubZone, GetSubZoneDto>();
            CreateMap<UpdateSubZoneDto, SubZone>();
        }
    }
}
