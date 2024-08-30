using BaseSourcoo.Models.DatabaseContext;
using SourCooBaseProject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using SourCooBaseProject.IRepository;
using SourCooBaseProject.Repository.Configuration;
using System;

namespace SourCooBaseProject.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await FindAll()
                .OrderBy(u => u.Email)
                .ToListAsync();
        }
        public async Task<User?> LogInUser(string email, string password)
        {
            return await FindByCondition(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
        }


        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await FindAll()
                .FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await FindAll()
                .FirstOrDefaultAsync(u => u.Id == id); 
        }


        public void CreateUser(User user)
        {
            Create(user);
        }
        public void UpdateUser(User user)
        {
            Update(user);
        }
        public void DeleteUser(User user)
        {
            Delete(user);
        }
    }
}
