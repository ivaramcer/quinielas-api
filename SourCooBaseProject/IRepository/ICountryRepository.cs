using QuinielasApi.Models.Entities;

namespace QuinielasApi.IRepository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync(int sportId);
        Task<Country?> GetByIdAsync(int id);
        Task BulkInsert(List<Country> entities);
        void Create(Country entity);
        void Update(Country entity);
        void Delete(Country entity);
    }
}
