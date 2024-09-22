using QuinielasApi.Models.Entities;

namespace QuinielasApi.IRepository
{
    public interface IQuinielaRepository
    {
        Task<List<Quiniela>> GetAllAsync();
        Task<Quiniela?> GetByIdAsync(int id);
        Task BulkInsert(List<Quiniela> entities);
        void Create(Quiniela entity);
        void Update(Quiniela entity);
        void Delete(Quiniela entity);
    }
}
