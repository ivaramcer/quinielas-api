using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuinielasApi.IRepository.Configuration;
using QuinielasApi.JWTConfiguration;
using QuinielasApi.Models.DTOs;
using QuinielasApi.Models.Entities;

namespace QuinielasApi.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class QuinielasController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<QuinielasController> _logger;

        public QuinielasController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<QuinielasController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllQuiniela()
        {
            try
            {
                var Quiniela = await _repository.Quiniela.GetAllAsync();
                var QuinielaDTOs = _mapper.Map<IEnumerable<QuinielaDTO>>(Quiniela);
                return Ok(QuinielaDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllQuiniela action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetQuinielaById(int id)
        {
            try
            {
                var Quiniela = await _repository.Quiniela.GetByIdAsync(id);
                if (Quiniela == null)
                {
                    _logger.LogError($"Quiniela with id: {id} hasn't been found in db.");
                    return NotFound($"No Quiniela with the id: {id}");
                }

                var QuinielaDTO = _mapper.Map<QuinielaDTO>(Quiniela);
                return Ok(QuinielaDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetQuinielaById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpGet("GetByCode/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            try
            {
                var Quiniela = await _repository.Quiniela.GetByCodeWithInformationAsync(code);
                if (Quiniela == null)
                {
                    _logger.LogError($"Quiniela with code: {code} hasn't been found in db.");
                    return NotFound($"No Quiniela with the code: {code}");
                }

                var QuinielaDTO = _mapper.Map<QuinielaDetailsDTO>(Quiniela);
                
                
                return Ok(QuinielaDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetQuinielaById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateQuiniela([FromBody] QuinielaInsertDTO QuinielaDTO)
        {
            try
            {
                if (QuinielaDTO == null)
                {
                    _logger.LogError("Quiniela object sent from client is null.");
                    return BadRequest("Quiniela object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                var quinielaEntity = _mapper.Map<Quiniela>(QuinielaDTO);
                _repository.Quiniela.Create(quinielaEntity);
                await _repository.SaveAsync();

                await CreateWinnerRules(quinielaEntity);
                await CreateQuinielaGames(quinielaEntity);
                
                
                var createdQuiniela = _mapper.Map<QuinielaDTO>(quinielaEntity);

                return Ok(createdQuiniela);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateQuiniela action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        private async Task CreateWinnerRules(Quiniela quinielaEntity)
        {
            if (quinielaEntity == null)
            {
                throw new ArgumentNullException(nameof(quinielaEntity), "quinielaEntity can´t be null");
            }

            try
            {
                QuinielaConfiguration firstPlace = new QuinielaConfiguration
                {
                    QuinielaId = quinielaEntity.Id,
                    Name = "First",
                    Value = 0.65
                };
                _repository.QuinielaConfiguration.Create(firstPlace);

                QuinielaConfiguration secondPlace = new QuinielaConfiguration
                {
                    QuinielaId = quinielaEntity.Id,
                    Name = "Second",
                    Value = 0.25
                };
                _repository.QuinielaConfiguration.Create(secondPlace);

                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurs while we are saving the rules.", ex);
            }
        }

        private async Task CreateQuinielaGames(Quiniela quinielaEntity)
        {
            if (quinielaEntity == null)
            {
                throw new ArgumentNullException(nameof(quinielaEntity), "quinielaEntity can´t be null");
            }

            try
            {
                QuinielaPickDuration? pickDuration = await _repository.QuinielaPickDuration.GetByIdAsync(quinielaEntity.QuinielaPickDurationId);
                QuinielaDuration? duration = await _repository.QuinielaDuration.GetByIdAsync(pickDuration!.QuinielaDurationId);
                
                
                switch (quinielaEntity.SportId)
                {
                    case TeamController.NFLId:
                        var gamesNFL = await _repository.Game.GetAllAsync(TeamController.NFLId);
                        await GamesForNFL(quinielaEntity,duration!.Name,gamesNFL);
                        break;
                    case TeamController.SoccerId:
                        var gamesSoccer = await _repository.Game.GetAllAsync(TeamController.SoccerId);
                        await GamesForNFL(quinielaEntity,duration!.Name, gamesSoccer);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurs while we are saving the rules.", ex);
            }
        }

        private async Task GamesForNFL(Quiniela quiniela, string duration, List<Game> games)
        {
            try
            {
                if (duration == "Round")
                {
                    games = games.Where(g => g.Week == quiniela.Week).ToList();
                }
                else
                {
                    DateTime now = DateTime.Now;
                    Game? firstGame = games.FirstOrDefault(g => g.Schedule >= now && g.Week != null);

                    if (firstGame == null)
                    {
                        throw new Exception("An error occurs with the games that were scheduled.");
                    }

                    games = games
                        .Where(g => g.Week >= firstGame.Week)
                        .OrderBy(g => g.Schedule)
                        .ToList();

                    if (games.Any() && games.First().Schedule != firstGame.Schedule)
                    {
                        games = games.Where(g => g.Week > firstGame.Week).ToList();
                    }


                }
                
                var quinielaGames = games.Select(game => new QuinielaGame
                {
                    QuinielaId = quiniela.Id,
                    GameId = game.Id,
                    GroupNumber = game.Week,
                    Group = $"Week {game.Week}"
                }).ToList();

                await _repository.QuinielaGame.BulkInsert(quinielaGames);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurs while we are saving the rules.", ex);
            }
        }




        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulkQuiniela(List<QuinielaInsertDTO> Quiniela)
        {
            try
            {
                if (Quiniela == null || !Quiniela.Any())
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                List<Quiniela> bulkType = _mapper.Map<List<Quiniela>>(Quiniela);


                await _repository.Quiniela.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkQuiniela action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }
        
        [HttpPost("Join/{userId}/{quinielaId}")]
        public async Task<IActionResult> Join(int userId, int quinielaId)
        {
            try
            {
                Quiniela? quiniela = await _repository.Quiniela.GetByIdAsync(quinielaId);
                
                if (quiniela == null)
                {
                    _logger.LogError($"The server doesn't have any quiniela with the id: {quinielaId}");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                User? user = await _repository.User.GetUserByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogError($"The server doesn't have any user with the id: {quinielaId}");
                    return StatusCode(500, "The server doesn't receive any user from the client");
                }

                Wallet? wallet = await _repository.Wallet.GetByIdAsync(userId);

                if (wallet.Balance < quiniela.Price)
                {
                    _logger.LogError($"Your wallet doesn't have enough balance");
                    return StatusCode(500, "Your wallet doesn't have enough balance");
                }
                
                wallet.Balance -= quiniela.Price;
                _repository.Wallet.Update(wallet);
                await _repository.SaveAsync();

                Gamepass gamepass = new Gamepass();
                gamepass.QuinielaId = quinielaId;
                gamepass.UserId = userId;
                _repository.Gamepass.Create(gamepass);
                await _repository.SaveAsync();

                TransactionHistory transaction = new TransactionHistory();
                transaction.Date = DateTime.Now.ToUniversalTime();
                transaction.Balance = quiniela.Price;
                transaction.Description = "Buy for quiniela with name: " + quiniela.Name;
                transaction.WalletId = wallet.Id;
                transaction.GamepassId = gamepass.Id;
                
                _repository.TransactionHistory.Create(transaction);
                await _repository.SaveAsync();
                

                
                List<QuinielaGame> quinielaGames = await _repository.QuinielaGame.GetAllByQuinielaId(quiniela.Id);
                List<UserPicks> picks = new List<UserPicks>();

                foreach (var game in quinielaGames)
                {
                    UserPicks userPicks = new UserPicks();
                    userPicks.QuinielaGameId = game.Id;
                    userPicks.QuinielaId = quinielaId;
                    userPicks.UserId = userId;
                    userPicks.Week = game.GroupNumber;
                    userPicks.Round = game.Group;
                    picks.Add(userPicks);
                }
                
                await _repository.UserPicks.BulkInsert(picks);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkQuiniela action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateQuiniela(int id, [FromBody] QuinielaDTO QuinielaDTO)
        {
            try
            {
                if (QuinielaDTO == null)
                {
                    _logger.LogError("Quiniela object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                var quinielaEntity = await _repository.Quiniela.GetByIdAsync(id);
                if (quinielaEntity == null)
                {
                    _logger.LogError($"Quiniela with id: {id} hasn't been found in db.");
                    return NotFound($"No Quiniela with the id: {id}");
                }

                _mapper.Map(QuinielaDTO, quinielaEntity);
                _repository.Quiniela.Update(quinielaEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateQuiniela action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteQuiniela(int id)
        {
            try
            {
                var quiniela = await _repository.Quiniela.GetByIdAsync(id);
                if (quiniela == null)
                {
                    _logger.LogError($"Quiniela with id: {id} hasn't been found in db.");
                    return NotFound($"No Quiniela with the id: {id}");
                }

                _repository.Quiniela.Delete(quiniela);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteQuiniela action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
