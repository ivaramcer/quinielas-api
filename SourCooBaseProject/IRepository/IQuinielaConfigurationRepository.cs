using QuinielasApi.Models.Entities;

namespace QuinielaConfigurationsApi.IRepository
{
    public interface IQuinielaConfigurationRepository
    {
        Task<List<QuinielaConfiguration>> GetAllAsync();
        Task<List<QuinielaConfiguration>> GetAllByQuinielaId(int quinielaId);
        Task<QuinielaConfiguration?> GetByIdAsync(int id);
        Task BulkInsert(List<QuinielaConfiguration> entities);
        void Create(QuinielaConfiguration entity);
        void Update(QuinielaConfiguration entity);
        void Delete(QuinielaConfiguration entity);
    }
}
