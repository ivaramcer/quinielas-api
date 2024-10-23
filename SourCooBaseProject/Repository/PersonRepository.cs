using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Models.Entities;
using QuinielasApi.Repository.Configuration;
using QuinielasApi.DBContext;

namespace QuinielasApi.Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Person>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(u => u.Id == id); 
        }


        public new void Create(Person entity)
        {
            base.Create(entity);
        }
        public new void Update(Person entity)
        {
            base.Update(entity);
        }
        public new void Delete(Person entity)
        {
            base.Delete(entity);
        }
    }
}
