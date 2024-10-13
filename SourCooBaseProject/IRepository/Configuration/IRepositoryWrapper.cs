using NFLGamesApi.IRepository;
using NFLLeaguesApi.IRepository;
using NFLTeamsApi.IRepository;
using PreferencesApi.IRepository;
using QuinielaDurationsApi.IRepository;
using QuinielaGamesApi.IRepository;
using QuinielaPickDurationsApi.IRepository;
using QuinielaTypesApi.IRepository;
using SoccerGamesApi.IRepository;
using SoccerLeaguesApi.IRepository;
using SoccerTeamsApi.IRepository;
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
        ISportRepository Sport { get; }
        IPermissionRepository Permission { get; }
        IPersonRepository Person { get; }
        IQuinielaRepository Quiniela { get; }
        IQuinielaDurationRepository QuinielaDuration { get; }
        IQuinielaPickDurationRepository QuinielaPickDuration { get; }
        IQuinielaTypeRepository QuinielaType { get; }
        INFLGameRepository NFLGame { get; }
        INFLTeamRepository NFLTeam { get; }
        INFLLeagueRepository NFLLeague { get; }

        ISoccerGameRepository SoccerGame { get; }
        ISoccerTeamRepository SoccerTeam { get; }
        ISoccerLeagueRepository SoccerLeague { get; }
        IStatusRepository Status{ get; }
        IPreferenceRepository Preference { get; }

    }
}
