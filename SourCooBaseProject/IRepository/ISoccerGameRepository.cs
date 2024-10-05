using QuinielasApi.Models.Entities;

namespace SoccerGamesApi.IRepository
{
    public interface ISoccerGameRepository
    {
        Task<List<SoccerGame>> GetAllAsync();
        Task<SoccerGame?> GetByIdAsync(int id);
        Task BulkInsert(List<SoccerGame> entities);
        void Create(SoccerGame entity);
        void Update(SoccerGame entity);
        void Delete(SoccerGame entity);
    }
}
