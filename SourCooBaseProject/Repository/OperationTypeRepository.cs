using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using OperationTypesApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class OperationTypeRepository : RepositoryBase<OperationType>, IOperationTypeRepository
    {
        public OperationTypeRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<OperationType>> GetAllAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<OperationType?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<OperationType> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(OperationType entity)
        {
            base.Create(entity);
        }
        public new void Update(OperationType entity)
        {
            base.Update(entity);
        }
        public new void Delete(OperationType entity)
        {
            base.Delete(entity);
        }
    }
}
