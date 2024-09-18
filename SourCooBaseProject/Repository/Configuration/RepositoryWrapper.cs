using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.IRepository.Configuration;
using QuinielasApi.DBContext;

namespace QuinielasApi.Repository.Configuration
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _dbContext = default!;
        private IUserRepository _user = default!;
        private IPersonRepository _person = default!;
        private IPermissionRepository _permission = default!;
        private ISportRepository _sport = default!;
        private IQuinielaRepository _quiniela = default!;

        public IQuinielaRepository Quiniela
        {
            get
            {
                if (_quiniela == null)
                {
                    _quiniela = new QuinielaRepository(_dbContext);
                }

                return _quiniela;
            }
        }
        public ISportRepository Sport
        {
            get
            {
                if (_sport == null)
                {
                    _sport = new SportRepository(_dbContext);
                }

                return _sport;
            }
        }

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
