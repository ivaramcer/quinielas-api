using GamepasssApi.IRepository;
using GamesApi.IRepository;
using LeaguesApi.IRepository;
using OperationTypesApi.IRepository;
using TeamsApi.IRepository;
using PreferencesApi.IRepository;
using QuinielaConfigurationsApi.IRepository;
using QuinielaDurationsApi.IRepository;
using QuinielaGamesApi.IRepository;
using QuinielaPickDurationsApi.IRepository;
using QuinielaTypeConfigurationsApi.IRepository;
using QuinielaTypesApi.IRepository;

using StatusApi.IRepository;
using TransactionHistorysApi.IRepository;
using UserPickssApi.IRepository;
using WalletsApi.IRepository;

namespace QuinielasApi.IRepository.Configuration
{
    public interface IRepositoryWrapper
    {
        void Save();
        Task SaveAsync();
        void Clear();
        
        IGameRepository Game { get; }
        IGamepassRepository Gamepass { get; }
        ILeagueRepository League { get; }
        IOperationTypeRepository OperationType { get; }
        IPermissionRepository Permission { get; }
        IPersonRepository Person { get; }
        IPreferenceRepository Preference { get; }
        IQuinielaRepository Quiniela { get; }
        IQuinielaConfigurationRepository QuinielaConfiguration { get; }
        IQuinielaDurationRepository QuinielaDuration { get; }
        IQuinielaGameRepository QuinielaGame { get; }
        IQuinielaPickDurationRepository QuinielaPickDuration { get; }
        IQuinielaTypeRepository  QuinielaType { get; }
        IQuinielaTypeConfigurationRepository  QuinielaTypeConfiguration { get; }
        IRoleRepository  Role { get; }

        ISportRepository Sport { get; }
        IStatusRepository Status{ get; }
        ITeamRepository Team { get; }
        ITransactionHistoryRepository TransactionHistory { get; }
        IUserRepository User { get; }
        IUserPicksRepository UserPicks { get; }
        IWalletRepository Wallet { get; }



    }
}
