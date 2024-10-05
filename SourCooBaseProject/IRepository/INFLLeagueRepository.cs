using QuinielasApi.Models.Entities;

namespace NFLLeaguesApi.IRepository
{
    public interface INFLLeagueRepository
    {
        Task<List<NFLLeague>> GetAllAsync();
        Task<NFLLeague?> GetByIdAsync(int id);
        Task BulkInsert(List<NFLLeague> entities);
        void Create(NFLLeague entity);
        void Update(NFLLeague entity);
        void Delete(NFLLeague entity);
    }
}
