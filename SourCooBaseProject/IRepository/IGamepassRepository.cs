using QuinielasApi.Models.Entities;

namespace GamepasssApi.IRepository
{
    public interface IGamepassRepository
    {
        Task<List<Gamepass>> GetAllAsync();
        Task<Gamepass?> GetByIdAsync(int id);
        Task BulkInsert(List<Gamepass> entities);
        void Create(Gamepass entity);
        void Update(Gamepass entity);
        void Delete(Gamepass entity);
    }
}
