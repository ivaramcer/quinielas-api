using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;

namespace QuinielaConfigurationsApi.IRepository
{
    public class QuinielaConfigurationRepository : RepositoryBase<QuinielaConfiguration>, IQuinielaConfigurationRepository
    {
        public QuinielaConfigurationRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<QuinielaConfiguration>> GetAllAsync()
        {
            return await FindAll()
                .ToListAsync();
        }
        
        public async Task<List<QuinielaConfiguration>> GetAllByQuinielaId(int quinielaId)
        {
            return await FindByCondition(qg => qg.QuinielaId == quinielaId )
                .ToListAsync();
        }

        public async Task<QuinielaConfiguration?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }


        public async Task BulkInsert(List<QuinielaConfiguration> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(QuinielaConfiguration entity)
        {
            base.Create(entity);
        }
        public new void Update(QuinielaConfiguration entity)
        {
            base.Update(entity);
        }
        public new void Delete(QuinielaConfiguration entity)
        {
            base.Delete(entity);
        }
    }
}
