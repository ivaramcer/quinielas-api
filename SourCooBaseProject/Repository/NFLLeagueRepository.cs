using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;

namespace NFLLeaguesApi.IRepository
{
    public class NFLLeagueRepository : RepositoryBase<NFLLeague>, INFLLeagueRepository
    {
        public NFLLeagueRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<NFLLeague>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<NFLLeague?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<NFLLeague> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(NFLLeague entity)
        {
            base.Create(entity);
        }
        public new void Update(NFLLeague entity)
        {
            base.Update(entity);
        }
        public new void Delete(NFLLeague entity)
        {
            base.Delete(entity);
        }
    }
}
