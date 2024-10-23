using QuinielasApi.Models.Entities;

namespace QuinielasApi.IRepository
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(int id);
        void Create(Role role);
        void Update(Role role);
        void Delete(Role role);
    }
}
