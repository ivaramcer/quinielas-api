using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;


namespace QuinielasApi.IRepository
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Role>> GetAllAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<Role> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(Role entity)
        {
            base.Create(entity);
        }
        public new void Update(Role entity)
        {
            base.Update(entity);
        }
        public new void Delete(Role entity)
        {
            base.Delete(entity);
        }
    }
}
