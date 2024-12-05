using QuinielasApi.Models.Entities;

namespace TeamsApi.IRepository
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAllAsync(int sportId, int leagueId);
        Task<List<Team>> GetAllNoTrackingAsync(int sportId, int leagueId);
        Task<Team?> GetByIdAsync(int id);
        Task BulkInsert(List<Team> entities);
        void Create(Team entity);
        void Update(Team entity);
        void Delete(Team entity);
    }
}
