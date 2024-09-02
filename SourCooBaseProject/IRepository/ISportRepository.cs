using QuinielasApi.Models.Entities;

namespace QuinielasApi.IRepository
{
    public interface ISportRepository
    {
        Task<List<Sport>> GetAllSportsAsync();
        Task<Sport?> GetSportByIdAsync(int id);
        void CreateSport(Sport Sport);
        void UpdateSport(Sport Sport);
        void DeleteSport(Sport Sport);
    }
}
