namespace Yard_Scan_API.Profiles
{
    public class ZoneProfile : Profile
    {
        public ZoneProfile()
        {
            CreateMap<Zone, GetZoneDto>();
            CreateMap<AddZoneDto, Zone>();
            CreateMap<UpdateZoneDto, Zone>();
        }
    }
}
