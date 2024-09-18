using QuinielasApi.Models.Entities;

namespace QuinielasApi.IRepository
{
    public interface IQuinielaRepository
    {
        Task<List<Quiniela>> GetAllQuinielasAsync();
        Task<Quiniela?> GetQuinielaByIdAsync(int id);
        Task BulkInsert(List<Quiniela> entities);
        void CreateQuiniela(Quiniela Quiniela);
        void UpdateQuiniela(Quiniela Quiniela);
        void DeleteQuiniela(Quiniela Quiniela);
    }
}
