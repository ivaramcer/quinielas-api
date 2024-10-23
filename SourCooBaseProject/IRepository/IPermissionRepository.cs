using QuinielasApi.Models.Entities;

namespace QuinielasApi.IRepository
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetAllAsync();
        Task<Permission?> GetByIdAsync(int id);
        void Create(Permission entity);
        void Update(Permission entity);
        void Delete(Permission entity);
    }
}
