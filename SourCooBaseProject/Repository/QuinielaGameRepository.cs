using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;

namespace QuinielaGamesApi.IRepository
{
    public class QuinielaGameRepository : RepositoryBase<QuinielaGame>, IQuinielaGameRepository
    {
        public QuinielaGameRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<QuinielaGame>> GetAllAsync()
        {
            return await FindAll()
                .ToListAsync();
        }
        
        public async Task<List<QuinielaGame>> GetAllByQuinielaId(int quinielaId)
        {
            return await Find(qg => qg.QuinielaId == quinielaId )
                .ToListAsync();
        }

        public async Task<QuinielaGame?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }


        public async Task BulkInsert(List<QuinielaGame> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(QuinielaGame entity)
        {
            base.Create(entity);
        }
        public new void Update(QuinielaGame entity)
        {
            base.Update(entity);
        }
        public new void Delete(QuinielaGame entity)
        {
            base.Delete(entity);
        }
    }
}
