using QuinielasApi.Models.Entities;

namespace QuinielaDurationsApi.IRepository
{
    public interface IQuinielaDurationRepository
    {
        Task<List<QuinielaDuration>> GetAllAsync();
        Task<QuinielaDuration?> GetByIdAsync(int id);
        Task BulkInsert(List<QuinielaDuration> entities);
        void Create(QuinielaDuration entity);
        void Update(QuinielaDuration entity);
        void Delete(QuinielaDuration entity);
    }
}
