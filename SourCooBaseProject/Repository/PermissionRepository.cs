using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Models.Entities;
using QuinielasApi.Repository.Configuration;
using QuinielasApi.DBContext;

namespace QuinielasApi.Repository
{
    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Permission>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Permission?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(u => u.Id == id); 
        }


        public new void Create(Permission permission)
        {
            base.Create(permission);
        }
        public new void Update(Permission permission)
        {
           base.Update(permission);
        }
        public new void Delete(Permission permission)
        {
            base.Delete(permission);
        }
    }
}
