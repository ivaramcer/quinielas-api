using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Models.Entities;
using QuinielasApi.Repository.Configuration;
using QuinielasApi.DBContext;

namespace QuinielasApi.Repository
{
    public class SportRepository : RepositoryBase<Sport>, ISportRepository
    {
        public SportRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Sport>> GetAllSportsAsync()
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Sport?> GetSportByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(u => u.Id == id); 
        }


        public void CreateSport(Sport sport)
        {
            Create(sport);
        }
        public void UpdateSport(Sport sport)
        {
            Update(sport);
        }
        public void DeleteSport(Sport sport)
        {
            Delete(sport);
        }
    }
}
