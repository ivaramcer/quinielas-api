using GamepasssApi.IRepository;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.IRepository.Configuration;
using QuinielasApi.DBContext;
using QuinielaDurationsApi.IRepository;
using QuinielaPickDurationsApi.IRepository;
using QuinielaTypesApi.IRepository;
using StatusApi.IRepository;
using GamesApi.IRepository;
using TeamsApi.IRepository;
using LeaguesApi.IRepository;
using OperationTypesApi.IRepository;
using PreferencesApi.IRepository;
using QuinielaConfigurationsApi.IRepository;
using QuinielaGamesApi.IRepository;
using QuinielaTypeConfigurationsApi.IRepository;
using TransactionHistorysApi.IRepository;
using UserPickssApi.IRepository;
using WalletsApi.IRepository;

namespace QuinielasApi.Repository.Configuration
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _dbContext = default!;
        private IGameRepository _game = default!;
        private IGamepassRepository _gamepass = default!;
        private ILeagueRepository _league = default!;
        private IOperationTypeRepository _operationType = default!;
        private IPermissionRepository _permission = default!;
        private IPersonRepository _person = default!;
        private IPreferenceRepository _preference = default!;
        private IQuinielaRepository _quiniela = default!;
        private IQuinielaConfigurationRepository _quinielaConfiguration = default!;
        private IQuinielaDurationRepository _quinielaDuration = default!;
        private IQuinielaGameRepository _quinielaGame = default!;
        private IQuinielaPickDurationRepository _quinielaPickDuration = default!;
        private IQuinielaTypeRepository _quinielaType = default!;
        private IQuinielaTypeConfigurationRepository _quinielaTypeConfiguration = default!;
        private IRoleRepository _role = default!;
        private ISportRepository _sport = default!;
        private IStatusRepository _status = default!;
        private ITeamRepository _team = default!;
        private ITransactionHistoryRepository _transactionHistoryRepository = default!;
        private IUserRepository _user = default!;
        private IUserPicksRepository _userPicks = default!;
        private IWalletRepository _wallet = default!;

        public IWalletRepository Wallet
        {
            get
            {
                if (_wallet == null)
                {
                    _wallet = new WalletRepository(_dbContext);
                }

                return _wallet;
            }
        }
        public IUserPicksRepository UserPicks
        {
            get
            {
                if (_userPicks == null)
                {
                    _userPicks = new UserPicksRepository(_dbContext);
                }

                return _userPicks;
            }
        }
        public ITransactionHistoryRepository TransactionHistory
        {
            get
            {
                if (_transactionHistoryRepository == null)
                {
                    _transactionHistoryRepository = new TransactionHistoryRepository(_dbContext);
                }

                return _transactionHistoryRepository;
            }
        }
        
        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_dbContext);
                }

                return _role;
            }
        }
        
        public IQuinielaTypeConfigurationRepository QuinielaTypeConfiguration
        {
            get
            {
                if (_quinielaTypeConfiguration == null)
                {
                    _quinielaTypeConfiguration = new QuinielaTypeConfigurationRepository(_dbContext);
                }

                return _quinielaTypeConfiguration;
            }
        }
        public IOperationTypeRepository OperationType
        {
            get
            {
                if (_operationType == null)
                {
                    _operationType = new OperationTypeRepository(_dbContext);
                }

                return _operationType;
            }
        }
        
        public IGamepassRepository Gamepass
        {
            get
            {
                if (_gamepass == null)
                {
                    _gamepass = new GamepassRepository(_dbContext);
                }

                return _gamepass;
            }
        }
        
        public IQuinielaConfigurationRepository QuinielaConfiguration
        {
            get
            {
                if (_quinielaConfiguration == null)
                {
                    _quinielaConfiguration = new QuinielaConfigurationRepository(_dbContext);
                }

                return _quinielaConfiguration;
            }
        }
        public IQuinielaGameRepository QuinielaGame
        {
            get
            {
                if (_quinielaGame == null)
                {
                    _quinielaGame = new QuinielaGameRepository(_dbContext);
                }

                return _quinielaGame;
            }
        }
        
        public IPreferenceRepository Preference
        {
            get
            {
                if (_preference == null)
                {
                    _preference = new PreferenceRepository(_dbContext);
                }

                return _preference;
            }
        }


        public ITeamRepository Team
        {
            get
            {
                if (_team == null)
                {
                    _team = new TeamRepository(_dbContext);
                }

                return _team;
            }
        }

        public IGameRepository Game
        {
            get
            {
                if (_game == null)
                {
                    _game = new GameRepository(_dbContext);
                }

                return _game;
            }
        }

        public ILeagueRepository League
        {
            get
            {
                if (_league == null)
                {
                    _league = new LeagueRepository(_dbContext);
                }

                return _league;
            }
        }
        public IStatusRepository Status
        {
            get
            {
                if (_status == null)
                {
                    _status = new StatusRepository(_dbContext);
                }

                return _status;
            }
        }

        public IQuinielaDurationRepository QuinielaDuration
        {
            get
            {
                if (_quinielaDuration == null)
                {
                    _quinielaDuration = new QuinielaDurationRepository(_dbContext);
                }

                return _quinielaDuration;
            }
        }
        public IQuinielaPickDurationRepository QuinielaPickDuration
        {
            get
            {
                if (_quinielaPickDuration == null)
                {
                    _quinielaPickDuration = new QuinielaPickDurationRepository(_dbContext);
                }

                return _quinielaPickDuration;
            }
        }
        public IQuinielaTypeRepository QuinielaType
        {
            get
            {
                if (_quinielaType == null)
                {
                    _quinielaType = new QuinielaTypeRepository(_dbContext);
                }

                return _quinielaType;
            }
        }
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
