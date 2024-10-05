using QuinielasApi.Models.Entities;

namespace NFLTeamsApi.IRepository
{
    public interface INFLTeamRepository
    {
        Task<List<NFLTeam>> GetAllAsync();
        Task<NFLTeam?> GetByIdAsync(int id);
        Task BulkInsert(List<NFLTeam> entities);
        void Create(NFLTeam entity);
        void Update(NFLTeam entity);
        void Delete(NFLTeam entity);
    }
}
