using QuinielasApi.Models.Entities;

namespace QuinielaTypeConfigurationsApi.IRepository
{
    public interface IQuinielaTypeConfigurationRepository
    {
        Task<List<QuinielaTypeConfiguration>> GetAllAsync();
        Task<QuinielaTypeConfiguration?> GetByIdAsync(int id);
        Task BulkInsert(List<QuinielaTypeConfiguration> entities);
        void Create(QuinielaTypeConfiguration entity);
        void Update(QuinielaTypeConfiguration entity);
        void Delete(QuinielaTypeConfiguration entity);
    }
}
