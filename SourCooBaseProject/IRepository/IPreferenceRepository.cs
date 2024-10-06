using QuinielasApi.Models.Entities;

namespace PreferencesApi.IRepository
{
    public interface IPreferenceRepository
    {
        Task<List<Preference>> GetAllAsync();
        Task<Preference?> GetByIdAsync(int id);
        Task BulkInsert(List<Preference> entities);
        void Create(Preference entity);
        void Update(Preference entity);
        void Delete(Preference entity);
    }
}
