using QuinielasApi.Models.Entities;

namespace LeaguesApi.IRepository
{
    public interface ILeagueRepository
    {
        Task<List<League>> GetAllAsync();
        Task<League?> GetByIdAsync(int id);
        Task BulkInsert(List<League> entities);
        void Create(League entity);
        void Update(League entity);
        void Delete(League entity);
    }
}
