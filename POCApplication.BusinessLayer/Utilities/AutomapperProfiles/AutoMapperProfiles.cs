using AutoMapper;
using POCApplication.DataAccessLayer.Entities;
using POCApplication.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
