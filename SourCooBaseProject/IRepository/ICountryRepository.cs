using QuinielasApi.Models.Entities;

namespace QuinielasApi.IRepository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync();
        Task<Country?> GetByIdAsync(int id);
        Task<Country?> GetByNameAsync(string name);
        Task<Country?> GetByCodeAsync(string code);
        Task BulkInsert(List<Country> entities);
        Task BulkUpdate(List<Country> entities);
        void Create(Country entity);
        void Update(Country entity);
        void Delete(Country entity);
    }
}
