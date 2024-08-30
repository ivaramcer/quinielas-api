using AutoMapper;
using SourCooBaseProject.Models.DTOs;
using SourCooBaseProject.Models.Entities;

namespace SourCooBaseProject.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();
        }
    }
}
