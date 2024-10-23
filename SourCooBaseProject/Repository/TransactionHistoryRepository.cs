using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using TransactionHistorysApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class TransactionHistoryRepository : RepositoryBase<TransactionHistory>, ITransactionHistoryRepository
    {
        public TransactionHistoryRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<TransactionHistory>> GetAllAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<TransactionHistory?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<TransactionHistory> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(TransactionHistory entity)
        {
            base.Create(entity);
        }
        public new void Update(TransactionHistory entity)
        {
            base.Update(entity);
        }
        public new void Delete(TransactionHistory entity)
        {
            base.Delete(entity);
        }
    }
}
