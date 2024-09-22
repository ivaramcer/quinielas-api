using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using StatusApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Status>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Status?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<Status> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(Status entity)
        {
            base.Create(entity);
        }
        public new void Update(Status entity)
        {
            base.Update(entity);
        }
        public new void Delete(Status entity)
        {
            base.Delete(entity);
        }
    }
}
