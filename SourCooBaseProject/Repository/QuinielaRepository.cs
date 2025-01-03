﻿using QuinielasApi.Models.Entities;
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
        public async Task<List<Quiniela>> GetAllAsync(int sportId)
        {
            return await FindAll()
                .Where(q=> q.SportId == sportId)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<List<Quiniela>> GetAllByUserIdAsync(int sportId, int userId)
        {
            return await FindAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Quiniela?> GetByIdAsync(int id)
        {
            return await FindAll()
                .Include(q => q.League)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
        
        public async Task<Quiniela?> GetByCodeAsync(string code)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Code.ToLower() == code.ToLower());
        }
        
        public async Task<Quiniela?> GetByCodeWithInformationAsync(string code)
        {
            return await FindAll()
                .Include(q => q.Sport)
                .Include(q => q.Gamepasses)
                .Include(q => q.QuinielaPickDuration)
                    .ThenInclude(qpd => qpd.QuinielaDuration)
                        .ThenInclude(qd => qd.QuinielaType)
                .FirstOrDefaultAsync(q => q.Code.ToLower() == code.ToLower());
        }

        public async Task BulkInsert(List<Quiniela> entities)
        {
            await BulkInsertAsync(entities);
        }

        public new void Create(Quiniela entity)
        {
            base.Create(entity);
        }
        public new void Update(Quiniela entity)
        {
            base.Update(entity);
        }
        public new void Delete(Quiniela entity)
        {
            base.Delete(entity);
        }
    }
}
