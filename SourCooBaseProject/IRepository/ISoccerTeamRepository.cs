using QuinielasApi.Models.Entities;

namespace SoccerTeamsApi.IRepository
{
    public interface ISoccerTeamRepository
    {
        Task<List<SoccerTeam>> GetAllAsync();
        Task<SoccerTeam?> GetByIdAsync(int id);
        Task BulkInsert(List<SoccerTeam> entities);
        void Create(SoccerTeam entity);
        void Update(SoccerTeam entity);
        void Delete(SoccerTeam entity);
    }
}
