using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using GamepasssApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class GamepassRepository : RepositoryBase<Gamepass>, IGamepassRepository
    {
        public GamepassRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Gamepass>> GetAllAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<List<Gamepass>> GetAllByUserIdAsync(int userId)
        {
            return await FindAll()
                .Where(g => g.UserId == userId)
                .Include(g => g.Quiniela)
                .ToListAsync();
        }

        public async Task<Gamepass?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<Gamepass> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(Gamepass entity)
        {
            base.Create(entity);
        }
        public new void Update(Gamepass entity)
        {
            base.Update(entity);
        }
        public new void Delete(Gamepass entity)
        {
            base.Delete(entity);
        }
    }
}
