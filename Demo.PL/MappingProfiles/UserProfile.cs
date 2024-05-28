using AutoMapper;
using Demo.DAL.Model;
using Demo.PL.ViewModels;

namespace Demo.PL.MappingProfiles
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<ApplicationUser , UserViewModel>().ReverseMap();
        }

    }
}
