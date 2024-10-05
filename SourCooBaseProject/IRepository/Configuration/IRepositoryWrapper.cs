using NFLGamesApi.IRepository;
using NFLTeamsApi.IRepository;
using QuinielaDurationsApi.IRepository;
using QuinielaPickDurationsApi.IRepository;
using QuinielaTypesApi.IRepository;
using SoccerLeaguesApi.IRepository;
using StatusApi.IRepository;

namespace QuinielasApi.IRepository.Configuration
{
    public interface IRepositoryWrapper
    {
        void Save();
        Task SaveAsync();
        void Clear();
        IUserRepository User { get; }
        ISportRepository Sport { get; }
        IPermissionRepository Permission { get; }
        IPersonRepository Person { get; }
        IQuinielaRepository Quiniela { get; }
        IQuinielaDurationRepository QuinielaDuration { get; }
        IQuinielaPickDurationRepository QuinielaPickDuration { get; }
        IQuinielaTypeRepository QuinielaType { get; }
        INFLGameRepository NFLGame { get; }
        INFLTeamRepository NFLTeam { get; }
        IStatusRepository Status{ get; }
        ISoccerLeagueRepository SoccerLeague { get; }

    }
}
