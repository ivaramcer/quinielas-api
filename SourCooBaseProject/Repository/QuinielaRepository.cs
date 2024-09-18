using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;


namespace QuinielasApi.IRepository
{
    public class QuinielaRepository : RepositoryBase<Quiniela>, IQuinielaRepository
    {
        public QuinielaRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Quiniela>> GetAllQuinielasAsync()
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Quiniela?> GetQuinielaByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<Quiniela> entities)
        {
            await BulkInsertAsync(entities);
        }

        public void CreateQuiniela(Quiniela Quiniela)
        {
            Create(Quiniela);
        }
        public void UpdateQuiniela(Quiniela Quiniela)
        {
            Update(Quiniela);
        }
        public void DeleteQuiniela(Quiniela Quiniela)
        {
            Delete(Quiniela);
        }
    }
}
