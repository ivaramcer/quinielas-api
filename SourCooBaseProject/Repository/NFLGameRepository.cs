using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using NFLGamesApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class NFLGameRepository : RepositoryBase<NFLGame>, INFLGameRepository
    {
        public NFLGameRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<NFLGame>> GetAllAsync()
        {
            return await FindAll()
                .Include(g => g.WinnerTeam)
                .Include(g => g.HomeTeam)
                .Include(g => g.AwayTeam)
                .ToListAsync();
        }

        public async Task<NFLGame?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<NFLGame> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(NFLGame entity)
        {
            base.Create(entity);
        }
        public new void Update(NFLGame entity)
        {
            base.Update(entity);
        }
        public new void Delete(NFLGame entity)
        {
            base.Delete(entity);
        }
    }
}
