using AutoMapper;
using QuinielasApi.Models.DTOs;
using QuinielasApi.Models.Entities;

namespace QuinielasApi.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();

            CreateMap<PersonDTO, Person>();
            CreateMap<Person, PersonDTO>();

            CreateMap<PersonNameDTO, Person>();
            CreateMap<Person, PersonNameDTO>();

        }
    }
}
