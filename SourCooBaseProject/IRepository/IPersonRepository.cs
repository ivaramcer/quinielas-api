using QuinielasApi.Models.Entities;

namespace QuinielasApi.IRepository
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllAsync();
        Task<Person?> GetByIdAsync(int id);
        void Create(Person entity);
        void Update(Person entity);
        void Delete(Person entity);
    }
}
