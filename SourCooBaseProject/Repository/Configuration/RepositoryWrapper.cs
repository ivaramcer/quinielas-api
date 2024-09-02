using QuinielasApi.Models.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.IRepository.Configuration;

namespace QuinielasApi.Repository.Configuration
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _dbContext = default!;
        private IUserRepository _user = default!;
        private IPersonRepository _person = default!;
        private IPermissionRepository _permission = default!;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_dbContext);
                }

                return _user;
            }
        }

        public IPersonRepository Person
        {
            get
            {
                if (_person == null)
                {
                    _person = new PersonRepository(_dbContext);
                }

                return _person;
            }
        }

        public IPermissionRepository Permission
        {
            get
            {
                if (_permission == null)
                {
                    _permission = new PermissionRepository(_dbContext);
                }

                return _permission;
            }
        }
        public RepositoryWrapper(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public async Task SaveAsync()
        {
          await _dbContext.SaveChangesAsync();
        }
        public void Clear()
        {
            _dbContext.ChangeTracker.Clear();
        }

    }
}
