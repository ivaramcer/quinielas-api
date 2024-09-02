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
        public async Task<List<Permission>> GetAllPermissionsAsync()
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Permission?> GetPermissionByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(u => u.Id == id); 
        }


        public void CreatePermission(Permission permission)
        {
            Create(permission);
        }
        public void UpdatePermission(Permission permission)
        {
            Update(permission);
        }
        public void DeletePermission(Permission permission)
        {
            Delete(permission);
        }
    }
}
