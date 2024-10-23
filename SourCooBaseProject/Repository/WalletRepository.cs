using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using WalletsApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class WalletRepository : RepositoryBase<Wallet>, IWalletRepository
    {
        public WalletRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Wallet>> GetAllAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<Wallet?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<Wallet> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(Wallet entity)
        {
            base.Create(entity);
        }
        public new void Update(Wallet entity)
        {
            base.Update(entity);
        }
        public new void Delete(Wallet entity)
        {
            base.Delete(entity);
        }
    }
}
