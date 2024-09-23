using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;

namespace SoccerLeaguesApi.IRepository
{
    public class SoccerLeagueRepository : RepositoryBase<SoccerLeague>, ISoccerLeagueRepository
    {
        public SoccerLeagueRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<SoccerLeague>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<SoccerLeague?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<SoccerLeague> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(SoccerLeague entity)
        {
            base.Create(entity);
        }
        public new void Update(SoccerLeague entity)
        {
            base.Update(entity);
        }
        public new void Delete(SoccerLeague entity)
        {
            base.Delete(entity);
        }
    }
}
