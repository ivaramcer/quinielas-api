using QuinielasApi.Models.Entities;

namespace GamesApi.IRepository
{
    public interface IGameRepository
    {
        Task<List<Game>> GetAllAsync(int sportId, int leagueId);
        Task<Game?> GetByIdAsync(int id);
        Task BulkInsert(List<Game> entities);
        Task BulkUpdate(List<Game> entities);
        void Create(Game entity);
        void Update(Game entity);
        void Delete(Game entity);
    }
}
