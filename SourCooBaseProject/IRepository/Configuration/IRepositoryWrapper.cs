using GamesApi.IRepository;
using LeaguesApi.IRepository;
using TeamsApi.IRepository;
using PreferencesApi.IRepository;
using QuinielaConfigurationsApi.IRepository;
using QuinielaDurationsApi.IRepository;
using QuinielaGamesApi.IRepository;
using QuinielaPickDurationsApi.IRepository;
using QuinielaTypesApi.IRepository;

using StatusApi.IRepository;

namespace QuinielasApi.IRepository.Configuration
{
    public interface IRepositoryWrapper
    {
        void Save();
        Task SaveAsync();
        void Clear();
        IUserRepository User { get; }
        IQuinielaGameRepository QuinielaGame { get; }
        IQuinielaConfigurationRepository QuinielaConfiguration { get; }
        ISportRepository Sport { get; }
        IPermissionRepository Permission { get; }
        IPersonRepository Person { get; }
        IQuinielaRepository Quiniela { get; }
        IQuinielaDurationRepository QuinielaDuration { get; }
        IQuinielaPickDurationRepository QuinielaPickDuration { get; }
        IQuinielaTypeRepository QuinielaType { get; }
        IGameRepository Game { get; }
        ITeamRepository Team { get; }
        ILeagueRepository League { get; }


        IStatusRepository Status{ get; }
        IPreferenceRepository Preference { get; }

    }
}
