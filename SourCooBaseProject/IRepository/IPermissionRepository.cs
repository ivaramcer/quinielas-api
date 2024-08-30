using QuinielasApi.Models.Entities;

namespace QuinielasApi.IRepository
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetAllPermissionsAsync();
        Task<Permission?> GetPermissionByIdAsync(int id);
        void CreatePermission(Permission permission);
        void UpdatePermission(Permission permission);
        void DeletePermission(Permission permission);
    }
}
