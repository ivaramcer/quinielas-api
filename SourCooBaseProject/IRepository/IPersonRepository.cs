using SourCooBaseProject.Models.Entities;

namespace SourCooBaseProject.IRepository
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllPersonsAsync();
        Task<Person?> GetPersonByIdAsync(int id);
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
    }
}
