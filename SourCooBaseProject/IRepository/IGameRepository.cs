using QuinielasApi.Models.Entities;

namespace NFLGamesApi.IRepository
{
    public interface INFLGameRepository
    {
        Task<List<NFLGame>> GetAllAsync();
        Task<NFLGame?> GetByIdAsync(int id);
        Task BulkInsert(List<NFLGame> entities);
        void Create(NFLGame entity);
        void Update(NFLGame entity);
        void Delete(NFLGame entity);
    }
}
