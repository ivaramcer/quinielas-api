using SourCooBaseProject.Models.Entities;

namespace SourCooBaseProject.IRepository
{
    public interface IUserPermissionRepository
    {
        Task<List<UserPermission>> GetAllUserPermissionsAsync();
        Task<UserPermission?> GetUserPermissionByIdAsync(int id);
        Task<UserPermission?> GetUserPermissionByEmailAsync(string email);
        void CreateUserPermission(UserPermission userPermission);
        void UpdateUserPermission(UserPermission userPermission);
        void DeleteUserPermission(UserPermission userPermission);
    }
}
