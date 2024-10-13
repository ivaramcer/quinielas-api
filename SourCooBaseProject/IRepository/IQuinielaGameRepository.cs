using QuinielasApi.Models.Entities;

namespace QuinielaGamesApi.IRepository
{
    public interface IQuinielaGameRepository
    {
        Task<List<QuinielaGame>> GetAllAsync();
        Task<List<QuinielaGame>> GetAllByQuinielaId(int quinielaId);
        Task<QuinielaGame?> GetByIdAsync(int id);
        Task BulkInsert(List<QuinielaGame> entities);
        void Create(QuinielaGame entity);
        void Update(QuinielaGame entity);
        void Delete(QuinielaGame entity);
    }
}
