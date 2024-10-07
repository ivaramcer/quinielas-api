using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;
using PreferencesApi.IRepository;


namespace QuinielasApi.IRepository
{
    public class PreferenceRepository : RepositoryBase<Preference>, IPreferenceRepository
    {
        public PreferenceRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Preference>> GetAllAsync(int sportId, int userId)
        {
            return await FindAll()
                .Where(p => p.SportId == sportId
                && p.UserId == userId)
                .ToListAsync();
        }

        public async Task<Preference?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task BulkInsert(List<Preference> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(Preference entity)
        {
            base.Create(entity);
        }
        public new void Update(Preference entity)
        {
            base.Update(entity);
        }
        public new void Delete(Preference entity)
        {
            base.Delete(entity);
        }
    }
}
