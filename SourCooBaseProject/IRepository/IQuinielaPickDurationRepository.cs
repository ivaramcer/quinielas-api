using QuinielasApi.Models.Entities;

namespace QuinielaPickDurationsApi.IRepository
{
    public interface IQuinielaPickDurationRepository
    {
        Task<List<QuinielaPickDuration>> GetAllAsync();
        Task<QuinielaPickDuration?> GetByIdAsync(int id);
        Task BulkInsert(List<QuinielaPickDuration> entities);
        void Create(QuinielaPickDuration entity);
        void Update(QuinielaPickDuration entity);
        void Delete(QuinielaPickDuration entity);
    }
}
