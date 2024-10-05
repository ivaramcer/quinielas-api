using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using SoccerGamesApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class SoccerGameRepository : RepositoryBase<SoccerGame>, ISoccerGameRepository
    {
        public SoccerGameRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<SoccerGame>> GetAllAsync()
        {
            return await FindAll()
                .Include(g => g.WinnerTeam)
                .Include(g => g.HomeTeam)
                .Include(g => g.AwayTeam)
                .ToListAsync();
        }

        public async Task<SoccerGame?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<SoccerGame> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(SoccerGame entity)
        {
            base.Create(entity);
        }
        public new void Update(SoccerGame entity)
        {
            base.Update(entity);
        }
        public new void Delete(SoccerGame entity)
        {
            base.Delete(entity);
        }
    }
}
