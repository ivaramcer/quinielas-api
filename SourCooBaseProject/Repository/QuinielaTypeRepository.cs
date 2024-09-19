using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using QuinielaTypesApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class QuinielaTypeRepository : RepositoryBase<QuinielaType>, IQuinielaTypeRepository
    {
        public QuinielaTypeRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<QuinielaType>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<QuinielaType?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<QuinielaType> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(QuinielaType entity)
        {
            base.Create(entity);
        }
        public new void Update(QuinielaType entity)
        {
            base.Update(entity);
        }
        public new void Delete(QuinielaType entity)
        {
            base.Delete(entity);
        }
    }
}
