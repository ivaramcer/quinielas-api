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

            CreateMap<SoccerLeagueDTO, SoccerLeague>();
            CreateMap<SoccerLeague, SoccerLeagueDTO>();

            CreateMap<SoccerLeagueInsertDTO, SoccerLeague>();
            CreateMap<SoccerLeague, SoccerLeagueInsertDTO>();

            CreateMap<SoccerLeagueUpdateDTO, SoccerLeague>();
            CreateMap<SoccerLeague, SoccerLeagueUpdateDTO>();

            CreateMap<SoccerGame, SoccerGameDTO>();
            CreateMap<SoccerGameDTO, SoccerGame>();

            CreateMap<SoccerGame, SoccerGameInsertDTO>();
            CreateMap<SoccerGameInsertDTO, SoccerGame>();

            CreateMap<SoccerGame, SoccerGameUpdateDTO>();
            CreateMap<SoccerGameUpdateDTO, SoccerGame>();

            CreateMap<SoccerTeam, SoccerTeamDTO>();
            CreateMap<SoccerTeamDTO, SoccerTeam>();

            CreateMap<SoccerTeam, SoccerTeamInsertDTO>();
            CreateMap<SoccerTeamInsertDTO, SoccerTeam>();

            CreateMap<SoccerTeam, SoccerTeamUpdateDTO>();
            CreateMap<SoccerTeamUpdateDTO, SoccerTeam>();


            CreateMap<NFLLeagueDTO, NFLLeague>();
            CreateMap<NFLLeague, NFLLeagueDTO>();

            CreateMap<NFLLeagueInsertDTO, NFLLeague>();
            CreateMap<NFLLeague, NFLLeagueInsertDTO>();

            CreateMap<NFLLeagueUpdateDTO, NFLLeague>();
            CreateMap<NFLLeague, NFLLeagueUpdateDTO>();

            CreateMap<NFLGame, NFLGameDTO>();
            CreateMap<NFLGameDTO, NFLGame>();

            CreateMap<NFLGame, NFLGameInsertDTO>();
            CreateMap<NFLGameInsertDTO, NFLGame>();

            CreateMap<NFLGame, NFLGameUpdateDTO>();
            CreateMap<NFLGameUpdateDTO, NFLGame>();

            CreateMap<NFLTeam, NFLTeamDTO>();
            CreateMap<NFLTeamDTO, NFLTeam>();

            CreateMap<NFLTeam, NFLTeamInsertDTO>();
            CreateMap<NFLTeamInsertDTO, NFLTeam>();

            CreateMap<NFLTeam, NFLTeamUpdateDTO>();
            CreateMap<NFLTeamUpdateDTO, NFLTeam>();



            CreateMap<Preference, PreferenceDTO>();
            CreateMap<PreferenceDTO, Preference>();

            CreateMap<Preference, PreferenceInsertDTO>();
            CreateMap<PreferenceInsertDTO, Preference>();




        }
    }
}
