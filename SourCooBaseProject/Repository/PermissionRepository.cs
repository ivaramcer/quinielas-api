using BaseSourcoo.Models.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using SourCooBaseProject.IRepository;
using SourCooBaseProject.Models.Entities;
using SourCooBaseProject.Repository.Configuration;

namespace SourCooBaseProject.Repository
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
