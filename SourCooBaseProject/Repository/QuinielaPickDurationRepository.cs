using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using QuinielaPickDurationsApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class QuinielaPickDurationRepository : RepositoryBase<QuinielaPickDuration>, IQuinielaPickDurationRepository
    {
        public QuinielaPickDurationRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<QuinielaPickDuration>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<QuinielaPickDuration?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<QuinielaPickDuration> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(QuinielaPickDuration entity)
        {
            base.Create(entity);
        }
        public new void Update(QuinielaPickDuration entity)
        {
            base.Update(entity);
        }
        public new void Delete(QuinielaPickDuration entity)
        {
            base.Delete(entity);
        }
    }
}
