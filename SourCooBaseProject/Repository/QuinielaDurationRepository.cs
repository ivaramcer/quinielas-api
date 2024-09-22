using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;

namespace QuinielaDurationsApi.IRepository
{
    public class QuinielaDurationRepository : RepositoryBase<QuinielaDuration>, IQuinielaDurationRepository
    {
        public QuinielaDurationRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<QuinielaDuration>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<QuinielaDuration?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }
        public async Task<List<QuinielaDuration>> GetListByQuinielaTypeIdAsync(int quinielaTypeId)
        {
            return await FindByCondition( qt => qt.QuinielaTypeId == quinielaTypeId)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task BulkInsert(List<QuinielaDuration> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(QuinielaDuration entity)
        {
            base.Create(entity);
        }
        public new void Update(QuinielaDuration entity)
        {
            base.Update(entity);
        }
        public new void Delete(QuinielaDuration entity)
        {
            base.Delete(entity);
        }
    }
}
