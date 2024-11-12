using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using UserPickssApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class UserPicksRepository : RepositoryBase<UserPicks>, IUserPicksRepository
    {
        public UserPicksRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<UserPicks>> GetAllAsync()
        {
            return await FindAll()
                 .Include(up => up.QuinielaGame)
                    .ThenInclude(qg => qg.Game)
                .ToListAsync();
        }

        public async Task<List<UserPicks>> GetAllByUserIdAsync(int userId, int sportId)
        {
            return await FindAll()
                .Include(up => up.QuinielaGame)
                    .ThenInclude(qg => qg.Game)
                        .ThenInclude(g => g.HomeTeam)
                .Include(up => up.QuinielaGame)
                    .ThenInclude(qg => qg.Game)
                        .ThenInclude(g => g.AwayTeam)
                .Where(up => up.UserId == userId)
                .Where(up => up.SportId == sportId)

                .ToListAsync();
        }

        public async Task<List<UserPicks>> GetAllByQuinielaUserIdAsync(int userId, int quinielaId)
        {
            return await FindAll()
                .Include(up => up.QuinielaGame)
                    .ThenInclude(qg => qg.Game)
                        .ThenInclude(g => g.HomeTeam)
                .Include(up => up.QuinielaGame)
                    .ThenInclude(qg => qg.Game)
                        .ThenInclude(g => g.AwayTeam)
                .Where(up => up.UserId == userId)
                .Where(up => up.QuinielaId == quinielaId)

                .ToListAsync();
        }

        public async Task<List<UserPicks>> MakePicks(int userId, int quinielaId)
        {
            return await FindAll()
                                .Where(up => up.UserId == userId)
                .Where(up => up.QuinielaId == quinielaId)
                .ToListAsync();
        }


        public async Task<UserPicks?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<UserPicks> entities)
        {
            await BulkInsertAsync(entities);
        }

        public async Task BulkUpdate(List<UserPicks> entities)
        {
            await BulkUpdateAsync(entities);
        }

        public new void Create(UserPicks entity)
        {
            base.Create(entity);
        }
        public new void Update(UserPicks entity)
        {
            base.Update(entity);
        }
        public new void Delete(UserPicks entity)
        {
            base.Delete(entity);
        }
    }
}
