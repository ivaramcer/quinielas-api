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

            CreateMap<SportDTO, Sport>();
            CreateMap<Sport, SportDTO>();


            CreateMap<QuinielaInsertDTO, Quiniela>();
            CreateMap<Quiniela, QuinielaInsertDTO>();


            CreateMap<QuinielaDTO, Quiniela>();
            CreateMap<Quiniela, QuinielaDTO>();

            CreateMap<QuinielaType, QuinielaTypeDTO>();
            CreateMap<QuinielaTypeDTO, QuinielaType>();

            CreateMap<QuinielaType, QuinielaTypeInsertDTO>();
            CreateMap<QuinielaTypeInsertDTO, QuinielaType>();

            CreateMap<QuinielaDuration, QuinielaDurationDTO>();
            CreateMap<QuinielaDurationDTO, QuinielaDuration>();

            CreateMap<QuinielaDuration, QuinielaDurationInsertDTO>();
            CreateMap<QuinielaDurationInsertDTO, QuinielaDuration>();

            CreateMap<QuinielaPickDurationInsertDTO, QuinielaPickDuration>();
            CreateMap<QuinielaPickDuration, QuinielaPickDurationInsertDTO>();

            CreateMap<QuinielaPickDurationDTO, QuinielaPickDuration>();
            CreateMap<QuinielaPickDuration, QuinielaPickDurationDTO>();

            CreateMap<StatusDTO, Status>();
            CreateMap<Status, StatusDTO>();

            CreateMap<StatusInsertDTO, Status>();
            CreateMap<Status, StatusInsertDTO>();




            CreateMap<LeagueDTO, League>();
            CreateMap<League, LeagueDTO>();

            CreateMap<LeagueInsertDTO, League>();
            CreateMap<League, LeagueInsertDTO>();

            CreateMap<LeagueUpdateDTO, League>();
            CreateMap<League, LeagueUpdateDTO>();

            CreateMap<Game, GameDTO>();
            CreateMap<GameDTO, Game>();

            CreateMap<Game, GameInsertDTO>();
            CreateMap<GameInsertDTO, Game>();

            CreateMap<Game, GameUpdateDTO>();
            CreateMap<GameUpdateDTO, Game>();

            CreateMap<Team, TeamDTO>();
            CreateMap<TeamDTO, Team>();

            CreateMap<Team, TeamInsertDTO>();
            CreateMap<TeamInsertDTO, Team>();

            CreateMap<Team, TeamUpdateDTO>();
            CreateMap<TeamUpdateDTO, Team>();



            CreateMap<Preference, PreferenceDTO>();
            CreateMap<PreferenceDTO, Preference>();

            CreateMap<Preference, PreferenceInsertDTO>();
            CreateMap<PreferenceInsertDTO, Preference>();




        }
    }
}
