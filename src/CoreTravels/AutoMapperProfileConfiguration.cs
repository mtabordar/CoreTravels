namespace CoreTravels
{
    using AutoMapper;
    using Models;
    using ViewModels;

    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<Trip, TripViewModel>().ReverseMap();
            CreateMap<Stop, StopViewModel>().ReverseMap();
        }
    }
}
