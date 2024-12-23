﻿using QuinielasApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.Repository.Configuration;
using System;
using QuinielasApi.DBContext;

namespace CountrysApi.IRepository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Country>> GetAllAsync()
        {
            return await FindAll()
                .ToListAsync();
        }
        

        public async Task<Country?> GetByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Id == id);
        }
        
        public async Task<Country?> GetByCodeAsync(string code)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Code.Contains(code));
        }
        
        public async Task<Country?> GetByNameAsync(string name)
        {
            return await FindAll()
                .FirstOrDefaultAsync(q => q.Name.Contains(name));
        }


        public async Task BulkInsert(List<Country> entities)
        {
            await BulkInsertAsync(entities);
        }

        public async Task BulkUpdate(List<Country> entities)
        {
            await BulkUpdateAsync(entities);
        }

        public new void Create(Country entity)
        {
            base.Create(entity);
        }
        public new void Update(Country entity)
        {
            base.Update(entity);
        }
        public new void Delete(Country entity)
        {
            base.Delete(entity);
        }
    }
}
