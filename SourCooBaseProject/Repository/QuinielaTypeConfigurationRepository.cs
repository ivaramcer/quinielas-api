using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using QuinielaTypeConfigurationsApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class QuinielaTypeConfigurationRepository : RepositoryBase<QuinielaTypeConfiguration>, IQuinielaTypeConfigurationRepository
    {
        public QuinielaTypeConfigurationRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<QuinielaTypeConfiguration>> GetAllAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<QuinielaTypeConfiguration?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<QuinielaTypeConfiguration> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(QuinielaTypeConfiguration entity)
        {
            base.Create(entity);
        }
        public new void Update(QuinielaTypeConfiguration entity)
        {
            base.Update(entity);
        }
        public new void Delete(QuinielaTypeConfiguration entity)
        {
            base.Delete(entity);
        }
    }
}
