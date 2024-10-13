using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository;
using QuinielasApi.IRepository.Configuration;
using QuinielasApi.DBContext;
using QuinielaDurationsApi.IRepository;
using QuinielaPickDurationsApi.IRepository;
using QuinielaTypesApi.IRepository;
using StatusApi.IRepository;
using SoccerLeaguesApi.IRepository;
using NFLGamesApi.IRepository;
using NFLTeamsApi.IRepository;
using NFLLeaguesApi.IRepository;
using SoccerTeamsApi.IRepository;
using SoccerGamesApi.IRepository;
using PreferencesApi.IRepository;
using QuinielaConfigurationsApi.IRepository;
using QuinielaGamesApi.IRepository;

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
        private IQuinielaDurationRepository _quinielaDuration = default!;
        private IQuinielaPickDurationRepository _quinielaPickDuration = default!;
        private IQuinielaTypeRepository _quinielaType = default!;
        private IStatusRepository _status = default!;
        private INFLGameRepository _NFLGame = default!;
        private INFLTeamRepository _NFLTeam = default!;
        private INFLLeagueRepository _NFLLeague = default!;

        private ISoccerGameRepository _soccerGame = default!;
        private ISoccerTeamRepository _soccerTeam = default!;
        private ISoccerLeagueRepository _soccerLeague = default!;
        private IPreferenceRepository _preference = default!;
        private IQuinielaGameRepository _quinielaGame = default!;
        private IQuinielaConfigurationRepository _quinielaConfiguration = default!;

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

        public ISoccerTeamRepository SoccerTeam
        {
            get
            {
                if (_soccerTeam == null)
                {
                    _soccerTeam = new SoccerTeamRepository(_dbContext);
                }

                return _soccerTeam;
            }
        }

        public ISoccerGameRepository SoccerGame
        {
            get
            {
                if (_soccerGame == null)
                {
                    _soccerGame = new SoccerGameRepository(_dbContext);
                }

                return _soccerGame;
            }
        }

        public ISoccerLeagueRepository SoccerLeague
        {
            get
            {
                if (_soccerLeague == null)
                {
                    _soccerLeague = new SoccerLeagueRepository(_dbContext);
                }

                return _soccerLeague;
            }
        }


        public INFLTeamRepository NFLTeam
        {
            get
            {
                if (_NFLTeam == null)
                {
                    _NFLTeam = new NFLTeamRepository(_dbContext);
                }

                return _NFLTeam;
            }
        }

        public INFLGameRepository NFLGame
        {
            get
            {
                if (_NFLGame == null)
                {
                    _NFLGame = new NFLGameRepository(_dbContext);
                }

                return _NFLGame;
            }
        }

        public INFLLeagueRepository NFLLeague
        {
            get
            {
                if (_NFLLeague == null)
                {
                    _NFLLeague = new NFLLeagueRepository(_dbContext);
                }

                return _NFLLeague;
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
