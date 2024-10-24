using QuinielasApi.Models.Entities;

namespace QuinielasApi.IRepository
{
    public interface IQuinielaRepository
    {
        Task<List<Quiniela>> GetAllAsync();
        Task<Quiniela?> GetByIdAsync(int id);
        Task<Quiniela?> GetByCodeAsync(string code);
        Task<Quiniela?> GetByCodeWithInformationAsync(string code);
        Task BulkInsert(List<Quiniela> entities);
        void Create(Quiniela entity);
        void Update(Quiniela entity);
        void Delete(Quiniela entity);
    }
}
