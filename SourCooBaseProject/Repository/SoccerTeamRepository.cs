using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using SoccerTeamsApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class SoccerTeamRepository : RepositoryBase<SoccerTeam>, ISoccerTeamRepository
    {
        public SoccerTeamRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<SoccerTeam>> GetAllAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<SoccerTeam?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<SoccerTeam> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(SoccerTeam entity)
        {
            base.Create(entity);
        }
        public new void Update(SoccerTeam entity)
        {
            base.Update(entity);
        }
        public new void Delete(SoccerTeam entity)
        {
            base.Delete(entity);
        }
    }
}
