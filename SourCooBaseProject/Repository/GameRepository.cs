using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using GamesApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Game>> GetAllAsync(int sportId)
        {
            return await FindAll()
                .Where(g => g.SportId == sportId)
                .Include(g => g.WinnerTeam)
                .Include(g => g.HomeTeam)
                .Include(g => g.AwayTeam)
                .ToListAsync();
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<Game> entities)
        {
            await BulkInsertAsync(entities);
        }

        public async Task BulkUpdate(List<Game> entities)
        {
            await BulkUpdateAsync(entities);
        }

        public new void Create(Game entity)
        {
            base.Create(entity);
        }
        public new void Update(Game entity)
        {
            base.Update(entity);
        }
        public new void Delete(Game entity)
        {
            base.Delete(entity);
        }
    }
}
