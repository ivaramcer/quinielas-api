using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;

namespace LeaguesApi.IRepository
{
    public class LeagueRepository : RepositoryBase<League>, ILeagueRepository
    {
        public LeagueRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<League>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<List<League>> GetAllBySportAsync(int sportId)
        {
            return await FindAll()
                .Where(l => l.SportId == sportId)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<List<League>> GetAllQuinielasAsync(int sportId)
        {
            return await FindAll()
                .Include(l => l.Quinielas)
                    .ThenInclude(q => q.QuinielaPickDuration)
                        .ThenInclude(qpd => qpd.QuinielaDuration)
                            .ThenInclude(qd => qd.QuinielaType)
                .Where(l => l.SportId == sportId)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<League?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<League> entities)
        {
            await BulkInsertAsync(entities);
        }
        public async Task BulkUpdate(List<League> entities)
        {
            await BulkUpdateAsync(entities);
        }

        public new void Create(League entity)
        {
            base.Create(entity);
        }
        public new void Update(League entity)
        {
            base.Update(entity);
        }
        public new void Delete(League entity)
        {
            base.Delete(entity);
        }
    }
}
