using BaseSourcoo.Models.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using SourCooBaseProject.IRepository;
using SourCooBaseProject.Models.Entities;
using SourCooBaseProject.Repository.Configuration;

namespace SourCooBaseProject.Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Person>> GetAllPersonsAsync()
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Person?> GetPersonByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(u => u.Id == id); 
        }


        public void CreatePerson(Person person)
        {
            Create(person);
        }
        public void UpdatePerson(Person person)
        {
            Update(person);
        }
        public void DeletePerson(Person person)
        {
            Delete(person);
        }
    }
}
