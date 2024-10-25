using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using TeamsApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        public TeamRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Team>> GetAllAsync(int sportId)
        {
            return await FindAll()
                .Where(t => t.SportId == sportId)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<List<Team>> GetAllNoTrackingAsync(int sportId)
        {
            return await FindAll()
                .Where(t => t.SportId == sportId)
                .OrderBy(p => p.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        

        public async Task<Team?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<Team> entities)
        {
            await BulkInsertAsync(entities);
        }
        public new void Create(Team entity)
        {
            base.Create(entity);
        }
        public new void Update(Team entity)
        {
            base.Update(entity);
        }
        public new void Delete(Team entity)
        {
            base.Delete(entity);
        }
    }
}
