using QuinielasApi.Models.Entities;

namespace SoccerLeaguesApi.IRepository
{
    public interface ISoccerLeagueRepository
    {
        Task<List<SoccerLeague>> GetAllAsync();
        Task<SoccerLeague?> GetByIdAsync(int id);
        Task BulkInsert(List<SoccerLeague> entities);
        void Create(SoccerLeague entity);
        void Update(SoccerLeague entity);
        void Delete(SoccerLeague entity);
    }
}
