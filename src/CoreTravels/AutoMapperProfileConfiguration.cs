using AutoMapper;
using CoreTravels.Models;
using CoreTravels.ViewModels;

namespace CoreTravels
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<Trip, TripViewModel>().ReverseMap();
            CreateMap<Stop, StopViewModel>().ReverseMap();
        }
    }
}
