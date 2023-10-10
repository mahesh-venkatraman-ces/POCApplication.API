using AutoMapper;
using POCApplication.DataAccessLayer.Entities;
using POCApplication.DTO.DTOs;

namespace POCApplication.BusinessLayer.Utilities.AutomapperProfiles
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<User, UserDTO>().ReverseMap();
                CreateMap<User, UserToAddDTO>().ReverseMap();
                CreateMap<User, UserToUpdateDTO>().ReverseMap();
                CreateMap<User, UserToRegisterDTO>().ReverseMap();
                CreateMap<User, UserToReturnDTO>().ReverseMap();
            }
        }
    }
}
