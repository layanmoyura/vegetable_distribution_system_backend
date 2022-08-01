using AutoMapper;
using Online_platform_for_vegetables.Model;

namespace Online_platform_for_vegetables
{
    internal class Mappingprofile : Profile
    {
        public Mappingprofile()
        {
            CreateMap<AdminRegister, Admin>().ForMember(u => u.UserName, opt => opt.MapFrom(m=>m.Email));
            CreateMap<FarmerRegister, Farmer>().ForMember(u => u.UserName, opt => opt.MapFrom(m => m.Email));
            CreateMap<CustomerRegister, Customer>().ForMember(u => u.UserName, opt => opt.MapFrom(m => m.Email));
            CreateMap<CourierRegister, Courier>().ForMember(u => u.UserName, opt => opt.MapFrom(m => m.PhoneNumber));
        }
    }
}