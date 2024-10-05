using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using NFLTeamsApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class NFLTeamRepository : RepositoryBase<NFLTeam>, INFLTeamRepository
    {
        public NFLTeamRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<NFLTeam>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<NFLTeam?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<NFLTeam> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(NFLTeam entity)
        {
            base.Create(entity);
        }
        public new void Update(NFLTeam entity)
        {
            base.Update(entity);
        }
        public new void Delete(NFLTeam entity)
        {
            base.Delete(entity);
        }
    }
}
