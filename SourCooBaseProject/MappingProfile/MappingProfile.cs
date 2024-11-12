using AutoMapper;
using QuinielasApi.Models.DTOs;
using QuinielasApi.Models.Entities;
using QuinielasApi.Utils.NFL.DTO;

namespace QuinielasApi.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Games
            //Read
            CreateMap<Game, GameDTO>();
            CreateMap<GameDTO, Game>();
            //Create
            CreateMap<Game, GameInsertDTO>();
            CreateMap<GameInsertDTO, Game>();
            //Update
            CreateMap<Game, GameUpdateDTO>();
            CreateMap<GameUpdateDTO, Game>();
            #endregion
            
            #region Gamepass
            //Read
            CreateMap<Gamepass, GamepassDTO>();
            CreateMap<GamepassDTO, Gamepass>();
            //Create
            CreateMap<Gamepass, GamepassInsertDTO>();
            CreateMap<GamepassInsertDTO, Gamepass>();
            //Update
            CreateMap<Gamepass, GamepassUpdateDTO>();
            CreateMap<GamepassUpdateDTO, Gamepass>();
            #endregion

            #region League
            //Read
            CreateMap<League, LeagueDTO>();
            CreateMap<LeagueDTO, League>();
            //Create
            CreateMap<League, LeagueInsertDTO>();
            CreateMap<LeagueInsertDTO, League>();
            //Update
            CreateMap<League, LeagueUpdateDTO>();
            CreateMap<LeagueUpdateDTO, League>();

            CreateMap<LeagueQuinielasDTO, League>();
            CreateMap<League, LeagueQuinielasDTO>();


            
            #endregion

            #region OperationType
            //Read
            CreateMap<OperationType, OperationTypeDTO>();
            CreateMap<OperationTypeDTO, OperationType>();
            //Create
            CreateMap<OperationType, OperationTypeInsertDTO>();
            CreateMap<OperationTypeInsertDTO, OperationType>();
            //Update
            CreateMap<OperationType, OperationTypeUpdateDTO>();
            CreateMap<OperationTypeUpdateDTO, OperationType>();
            #endregion

            #region Permission
            //Read
            CreateMap<Permission, PermissionDTO>();
            CreateMap<PermissionDTO, Permission>();
            //Create
            CreateMap<Permission, PermissionInsertDTO>();
            CreateMap<PermissionInsertDTO, Permission>();
            //Update
            CreateMap<Permission, PermissionUpdateDTO>();
            CreateMap<PermissionUpdateDTO, Permission>();
            #endregion

            #region Person
            //Read
            CreateMap<Person, PersonDTO>();
            CreateMap<PersonDTO, Person>();
            //Create
            CreateMap<Person, PersonInsertDTO>();
            CreateMap<PersonInsertDTO, Person>();
            //Update
            CreateMap<Person, PersonUpdateDTO>();
            CreateMap<PersonUpdateDTO, Person>();
            
            CreateMap<Person, PersonNameDTO>();
            CreateMap<PersonNameDTO, Person>();

            #endregion

            #region Preference
            //Read
            CreateMap<Preference, PreferenceDTO>();
            CreateMap<PreferenceDTO, Preference>();
            //Create
            CreateMap<Preference, PreferenceInsertDTO>();
            CreateMap<PreferenceInsertDTO, Preference>();
            //Update
            CreateMap<Preference, PreferenceUpdateDTO>();
            CreateMap<PreferenceUpdateDTO, Preference>();
            #endregion

            #region Quiniela
            //Read
            CreateMap<Quiniela, QuinielaDTO>();
            CreateMap<QuinielaDTO, Quiniela>();
            //Create
            CreateMap<Quiniela, QuinielaInsertDTO>();
            CreateMap<QuinielaInsertDTO, Quiniela>();
            //Update
            CreateMap<Quiniela, QuinielaUpdateDTO>();
            CreateMap<QuinielaUpdateDTO, Quiniela>();
            
            CreateMap<Quiniela, QuinielaDetailsDTO>()
                .ForMember(dest => dest.Sport, 
                    opt => opt.MapFrom(src => src.Sport != null ? src.Sport.Name : "Unknown")) // Handles null Sport
                .ForMember(dest => dest.QuinielaType, 
                    opt => opt.MapFrom(src => src.QuinielaPickDuration != null 
                                              && src.QuinielaPickDuration.QuinielaDuration != null 
                                              && src.QuinielaPickDuration.QuinielaDuration.QuinielaType != null 
                        ? src.QuinielaPickDuration.QuinielaDuration.QuinielaType.Name 
                        : "N/A")) // Handles null QuinielaType
                .ForMember(dest => dest.Duration, 
                    opt => opt.MapFrom(src => src.QuinielaPickDuration != null 
                                              && src.QuinielaPickDuration.QuinielaDuration != null 
                        ? src.QuinielaPickDuration.QuinielaDuration.Name 
                        : "Unknown")) // Handles null Duration
                .ForMember(dest => dest.Code, 
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Code) ? src.Code : "No Code")) // Handles empty or null Code
                .ForMember(dest => dest.Members, 
                    opt => opt.MapFrom(src => src.Gamepasses.Count)) // Assuming QuotaPeople is always provided
                .ForMember(dest => dest.League, 
                    opt => opt.MapFrom(src => src.Sport != null ? src.Sport.Name : "No name")) // Handles null League
                .ForMember(dest => dest.Spots, 
                    opt => opt.MapFrom(src => src.QuotaPeople > 0 ? src.Gamepasses.Count+"/"+ src.QuotaPeople.ToString() : "No Spots")) // Handles Spots
                .ForMember(dest => dest.Name, 
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Name) ? src.Name : "No name"))
                .ForMember(dest => dest.Id, 
                    opt => opt.MapFrom(src => src.Id));
            #endregion

            #region QuinielaConfiguration
            //Read
            CreateMap<QuinielaConfiguration, QuinielaConfigurationDTO>();
            CreateMap<QuinielaConfigurationDTO, QuinielaConfiguration>();
            //Create
            CreateMap<QuinielaConfiguration, QuinielaConfigurationInsertDTO>();
            CreateMap<QuinielaConfigurationInsertDTO, QuinielaConfiguration>();
            //Update
            CreateMap<QuinielaConfiguration, QuinielaConfigurationUpdateDTO>();
            CreateMap<QuinielaConfigurationUpdateDTO, QuinielaConfiguration>();
            #endregion

            #region QuinielaDuration
            //Read
            CreateMap<QuinielaDuration, QuinielaDurationDTO>();
            CreateMap<QuinielaDurationDTO, QuinielaDuration>();
            //Create
            CreateMap<QuinielaDuration, QuinielaDurationInsertDTO>();
            CreateMap<QuinielaDurationInsertDTO, QuinielaDuration>();
            //Update
            CreateMap<QuinielaDuration, QuinielaDurationUpdateDTO>();
            CreateMap<QuinielaDurationUpdateDTO, QuinielaDuration>();
            #endregion

            #region QuinielaGame
            //Read
            CreateMap<QuinielaGame, QuinielaGameDTO>();
            CreateMap<QuinielaGameDTO, QuinielaGame>();
            //Create
            CreateMap<QuinielaGame, QuinielaGameInsertDTO>();
            CreateMap<QuinielaGameInsertDTO, QuinielaGame>();
            //Update
            CreateMap<QuinielaGame, QuinielaGameUpdateDTO>();
            CreateMap<QuinielaGameUpdateDTO, QuinielaGame>();
            #endregion

            #region QuinielaPickDuration
            //Read
            CreateMap<QuinielaPickDuration, QuinielaPickDurationDTO>();
            CreateMap<QuinielaPickDurationDTO, QuinielaPickDuration>();
            //Create
            CreateMap<QuinielaPickDuration, QuinielaPickDurationInsertDTO>();
            CreateMap<QuinielaPickDurationInsertDTO, QuinielaPickDuration>();
            //Update
            CreateMap<QuinielaPickDuration, QuinielaPickDurationUpdateDTO>();
            CreateMap<QuinielaPickDurationUpdateDTO, QuinielaPickDuration>();
            #endregion

            #region QuinielaType
            //Read
            CreateMap<QuinielaType, QuinielaTypeDTO>();
            CreateMap<QuinielaTypeDTO, QuinielaType>();
            //Create
            CreateMap<QuinielaType, QuinielaTypeInsertDTO>();
            CreateMap<QuinielaTypeInsertDTO, QuinielaType>();
            //Update
            CreateMap<QuinielaType, QuinielaTypeUpdateDTO>();
            CreateMap<QuinielaTypeUpdateDTO, QuinielaType>();
            #endregion

            #region QuinielaTypeConfiguration
            //Read
            CreateMap<QuinielaTypeConfiguration, QuinielaTypeConfigurationDTO>();
            CreateMap<QuinielaTypeConfigurationDTO, QuinielaTypeConfiguration>();
            //Create
            CreateMap<QuinielaTypeConfiguration, QuinielaTypeConfigurationInsertDTO>();
            CreateMap<QuinielaTypeConfigurationInsertDTO, QuinielaTypeConfiguration>();
            //Update
            CreateMap<QuinielaTypeConfiguration, QuinielaTypeConfigurationUpdateDTO>();
            CreateMap<QuinielaTypeConfigurationUpdateDTO, QuinielaTypeConfiguration>();
            #endregion

            #region Role
            //Read
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();
            //Create
            CreateMap<Role, RoleInsertDTO>();
            CreateMap<RoleInsertDTO, Role>();
            //Update
            CreateMap<Role, RoleUpdateDTO>();
            CreateMap<RoleUpdateDTO, Role>();
            #endregion

            #region Sport
            //Read
            CreateMap<Sport, SportDTO>();
            CreateMap<SportDTO, Sport>();
            //Create
            CreateMap<Sport, SportInsertDTO>();
            CreateMap<SportInsertDTO, Sport>();
            //Update
            CreateMap<Sport, SportUpdateDTO>();
            CreateMap<SportUpdateDTO, Sport>();
            #endregion

            #region Status
            //Read
            CreateMap<Status, StatusDTO>();
            CreateMap<StatusDTO, Status>();
            //Create
            CreateMap<Status, StatusInsertDTO>();
            CreateMap<StatusInsertDTO, Status>();
            //Update
            CreateMap<Status, StatusUpdateDTO>();
            CreateMap<StatusUpdateDTO, Status>();
            #endregion

            #region Team
            //Read
            CreateMap<Team, TeamDTO>();
            CreateMap<TeamDTO, Team>();
            //Create
            CreateMap<Team, TeamInsertDTO>();
            CreateMap<TeamInsertDTO, Team>();
            //Update
            CreateMap<Team, TeamUpdateDTO>();
            CreateMap<TeamUpdateDTO, Team>();
            #endregion

            #region TransactionHistory
            //Read
            CreateMap<TransactionHistory, TransactionHistoryDTO>();
            CreateMap<TransactionHistoryDTO, TransactionHistory>();
            //Create
            CreateMap<TransactionHistory, TransactionHistoryInsertDTO>();
            CreateMap<TransactionHistoryInsertDTO, TransactionHistory>();
            //Update
            CreateMap<TransactionHistory, TransactionHistoryUpdateDTO>();
            CreateMap<TransactionHistoryUpdateDTO, TransactionHistory>();
            #endregion

            #region User
            //Read
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            //Create
            CreateMap<User, UserInsertDTO>();
            CreateMap<UserInsertDTO, User>();
            //Update
            CreateMap<User, UserUpdateDTO>();
            CreateMap<UserUpdateDTO, User>();
            #endregion

            #region UserPicks
            //Read
            CreateMap<UserPicks, UserPicksDTO>();
            CreateMap<UserPicksDTO, UserPicks>();
            //Create
            CreateMap<UserPicks, UserPicksInsertDTO>();
            CreateMap<UserPicksInsertDTO, UserPicks>();
            //Update
            CreateMap<UserPicks, UserPicksUpdateDTO>();
            CreateMap<UserPicksUpdateDTO, UserPicks>();

            CreateMap<UserPicksInsertBulkDTO, UserPicks>();
            CreateMap<UserPicks, UserPicksInsertBulkDTO>();

            
            #endregion

            #region Wallet
            //Read
            CreateMap<Wallet, WalletDTO>();
            CreateMap<WalletDTO, Wallet>();
            //Create
            CreateMap<Wallet, WalletInsertDTO>();
            CreateMap<WalletInsertDTO, Wallet>();
            //Update
            CreateMap<Wallet, WalletUpdateDTO>();
            CreateMap<WalletUpdateDTO, Wallet>();
            #endregion







        }
    }
}
