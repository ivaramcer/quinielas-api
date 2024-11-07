using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuinielasApi.IRepository.Configuration;
using QuinielasApi.JWTConfiguration;
using QuinielasApi.Models.DTOs;
using QuinielasApi.Models.Entities;
using QuinielasApi.Utils.NFL.DTO;
using QuinielasApi.Utils.NFL;
using System.Globalization;
using QuinielasApi.Utils.Soccer;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.Utils;


namespace QuinielasApi.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GameController> _logger;

        public GameController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<GameController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }


        [HttpGet("GetAll/{sportId}")]
        public async Task<IActionResult> GetAllGame(int sportId)
        {
            try
            {
                var Games = await _repository.Game.GetAllAsync(sportId);
                var GameDTOs = _mapper.Map<IEnumerable<GameDTO>>(Games);
                return Ok(GameDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetNextGames/{sportId}")]
        public async Task<IActionResult> GetNextGames(int sportId)
        {
            try
            {
                var Games = await _repository.Game.GetAllAsync(sportId);
                DateTime time = DateTime.Now;

                // Filter the Games for today's date and take the first 5
                var filteredGames = Games
                    .Where(g => g.Schedule.Day >= time.Day && g.Schedule.Month == time.Month && g.Schedule.Year == time.Year)
                    .Take(5)
                    .ToList();

                List<GameDTO> GameDTOs = _mapper.Map<List<GameDTO>>(filteredGames);
                return Ok(GameDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("GetFullNextGames/{pagination}/{sportId}")]
        public async Task<IActionResult> GetFullNextGames(int pagination, int sportId)
        {
            try
            {
                int pageSize = 10;
                var Games = await _repository.Game.GetAllAsync(sportId);
                DateTime time = DateTime.Now;

                // Filter the Games for today's date and take the first 5
                var filteredGames = Games
                    .Where(g => g.Schedule.Day >= time.Day && g.Schedule.Month == time.Month && g.Schedule.Year == time.Year)
                    .Skip(pageSize * (pagination - 1 ))
                    .Take(pageSize)
                    .ToList();

                var GameDTOs = _mapper.Map<IEnumerable<GameDTO>>(filteredGames);
                return Ok(GameDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetGameById(int id)
        {
            try
            {
                var Game = await _repository.Game.GetByIdAsync(id);
                if (Game == null)
                {
                    _logger.LogError($"Game with id: {id} hasn't been found in db.");
                    return NotFound($"No Game with the id: {id}");
                }

                var GameDTO = _mapper.Map<GameDTO>(Game);
                return Ok(GameDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetGameById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateGame([FromBody] GameInsertDTO GameDTO)
        {
            try
            {
                if (GameDTO == null)
                {
                    _logger.LogError("Game object sent from client is null.");
                    return BadRequest("Game object is null");
                }

                var GameEntity = _mapper.Map<Game>(GameDTO);
                _repository.Game.Create(GameEntity);
                await _repository.SaveAsync();

                var createdGame = _mapper.Map<GameDTO>(GameEntity);

                return CreatedAtRoute("GetGameById", new { id = GameEntity.Id }, createdGame);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulkGame(List<GameInsertDTO> Games)
        {
            try
            {
                if (Games == null || !Games.Any())
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                List<Game> bulkType = _mapper.Map<List<Game>>(Games);


                await _repository.Game.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkGame action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateGame(int id, [FromBody] GameDTO GameDTO)
        {
            try
            {
                if (GameDTO == null)
                {
                    _logger.LogError("Game object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                var GameEntity = await _repository.Game.GetByIdAsync(id);
                if (GameEntity == null)
                {
                    _logger.LogError($"Game with id: {id} hasn't been found in db.");
                    return NotFound($"No Game with the id: {id}");
                }

                _mapper.Map(GameDTO, GameEntity);
                _repository.Game.Update(GameEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            try
            {
                var Game = await _repository.Game.GetByIdAsync(id);
                if (Game == null)
                {
                    _logger.LogError($"Game with id: {id} hasn't been found in db.");
                    return NotFound($"No Game with the id: {id}");
                }

                _repository.Game.Delete(Game);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost("GetBulkNFL")]
        public async Task<IActionResult> GetBulkNFL(int leagueId)
        {
            try
            {
                League? league = await _repository.League.GetByIdAsync(leagueId);
                if (league == null)
                {
                    _logger.LogError($"There is not a league with the id: {leagueId}");
                    return StatusCode(500, $"There is not a league with the id: {leagueId}");
                }

                List<GetGamesDTO>? teamsFromAPI = await APIClientNFL.GetGames(league.ExternalId);
                if (!teamsFromAPI.Any())
                {
                    _logger.LogError($"API it's not working");
                    return StatusCode(500, "API it's not working ");
                }
                List<Game> bulkGames = new List<Game>();
                List<Game> updateGames = new List<Game>();
                List<Game> ourGames = await _repository.Game.GetAllAsync(UtilsVariables.SportNFLId);
                List<Team> ourTeams = await _repository.Team.GetAllNoTrackingAsync(UtilsVariables.SportNFLId);


                foreach (var item in teamsFromAPI!)
                {


                    int awayId = 0;
                    int homeId = 0;

                    if (item.Teams.Home.Id != 0 )
                    {
                        homeId = item.Teams.Home.Id;
                    }
                    else
                    {
                        continue;
                    }

                    if (item.Teams.Away.Id != 0)
                    {
                        awayId = item.Teams.Away.Id;
                    }
                    else
                    {
                        continue;
                    }

                    Team? awayTeam = ourTeams.Find(t => t.ExternalId == awayId);
                    Team? homeTeam = ourTeams.Find(t => t.ExternalId == homeId);

                    if (awayTeam == null)
                    {
                        continue;
                    }


                    if (homeTeam == null)
                    {
                        continue;
                    }



                    var dateObj = item.Game.Date;
                    // Combine the date and time strings
                    string dateTimeString = $"{dateObj.Date} {dateObj.Time}";

                    // Parse into DateTime
                    DateTime parsedDateTime = DateTime.ParseExact(
                        dateTimeString,
                        "yyyy-MM-dd HH:mm",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.AssumeUniversal // Treats it as UTC
                    );

                    parsedDateTime = DateTime.SpecifyKind(parsedDateTime, DateTimeKind.Utc);

                    // If you need to adjust from UTC to another timezone, use DateTimeOffset
                    DateTimeOffset dateTimeOffset = DateTimeOffset.ParseExact(
                        dateTimeString,
                        "yyyy-MM-dd HH:mm",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.AssumeUniversal
                    ).ToOffset(TimeSpan.Zero);  // Adjust offset based on timezone if needed

                    int awayScore = 0;
                    int homeScore = 0;

                    if (item.Scores.Home.Total.HasValue)
                    {
                        homeScore = item.Scores.Home.Total.Value;
                    }

                    if (item.Scores.Away.Total.HasValue)
                    {
                        awayScore = item.Scores.Away.Total.Value;
                    }

                    int? weekNumber = null;

                    if (item.Game.Week.StartsWith("Week "))
                    {
                        if (int.TryParse(item.Game.Week.Substring(5), out int result) && result >= 1 && result <= 18)
                        {
                            weekNumber = result;
                        }
                    }

                    string statusGame = "Pending";
                    if (item.Game.Status != null)
                    {
                        if (item.Game.Status.Long != null)
                        {
                            statusGame = item.Game.Status.Long;
                        }
                    }

                    string venueGame = "Pending";
                    if (item.Game.Venue != null)
                    {
                        if (item.Game.Venue.Name != null)
                        {
                            venueGame = item.Game.Venue.Name;
                        }
                    }
                    //Console.WriteLine($"Parsed DateTime: {parsedDateTime}");
                    //Console.WriteLine($"Parsed DateTimeOffset (UTC): {dateTimeOffset}");
                    int? WinnerId = null;
                    if (item.Scores.Home.Total.HasValue && item.Scores.Away.Total.HasValue)
                    {
                        if (item.Scores.Home.Total.Value > item.Scores.Away.Total.Value)
                        {
                            WinnerId = homeTeam.Id;
                        }
                        else if (item.Scores.Home.Total.Value < item.Scores.Away.Total.Value)
                        {
                            WinnerId = awayTeam.Id;
                        }
                        // Si son iguales, WinnerId se mantiene como null
                    }



                    Game newGame = new Game
                    {
                        ExternalId = item.Game.Id,
                        Schedule = parsedDateTime,  
                        Venue = venueGame,
                        Status = statusGame,
                        Round = item.Game.Week,
                        Week = weekNumber,
                        IsDraw = null,
                        SportId = 2,
                        HomeTeamId = homeTeam.Id,  
                        AwayTeamId = awayTeam.Id,
                        HomeScore = homeScore,
                        AwayScore = awayScore,
                        WinnerTeamId = WinnerId
                    };

                    if (ourGames.Count != 0 && ourGames.Any(t => t.ExternalId == item.Game.Id))
                    {
                        Game? previousGame = ourGames.Where(t => t.ExternalId == item.Game.Id).FirstOrDefault();

                        if (previousGame != null)
                        {
                            previousGame.ExternalId = newGame.ExternalId;
                            previousGame.Schedule = newGame.Schedule;
                            previousGame.Venue = newGame.Venue;
                            previousGame.Status = newGame.Status;
                            previousGame.Round = newGame.Round;
                            previousGame.Week = newGame.Week;
                            previousGame.IsDraw = newGame.IsDraw;
                            previousGame.SportId = newGame.SportId;
                            previousGame.HomeTeamId = newGame.HomeTeamId;
                            previousGame.AwayTeamId = newGame.AwayTeamId;
                            previousGame.HomeScore = newGame.HomeScore;
                            previousGame.AwayScore = newGame.AwayScore;
                            previousGame.WinnerTeamId = newGame.WinnerTeamId;

                            updateGames.Add(previousGame);
                        }
                        continue;
                    }

                    bulkGames.Add(newGame);
                }

                
                if (bulkGames.Any())
                {
                    await _repository.Game.BulkInsert(bulkGames);
                    await _repository.SaveAsync();
                }

                if (updateGames.Any())
                {
                    await _repository.Game.BulkUpdate(updateGames);
                    await _repository.SaveAsync();
                    bulkGames.AddRange(updateGames);
                }


                List<GameDTO> teamDTO = _mapper.Map<List<GameDTO>>(bulkGames);

                return Ok(teamDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkGame action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }
        
        
        
        
        //SOCCER
        [HttpPost("GetBulkSoccer")]
        public async Task<IActionResult> GetBulkSoccer(int leagueId)
        {
            try
            {

                League? league = await _repository.League.GetByIdAsync(leagueId);
                if (league == null)
                {
                    _logger.LogError($"There is not a league with the id: {leagueId}");
                    return StatusCode(500, $"There is not a league with the id: {leagueId}");
                }
                List<GetGamesDTO>? teamsFromAPI = await APIClientSoccer.GetGames(league.ExternalId);

                List<Game> bulkGames = new List<Game>();
                List<Game> ourGames = await _repository.Game.GetAllAsync(UtilsVariables.SportSoccerId);
                foreach (var item in teamsFromAPI!)
                {
                    if (ourGames.Count == 0 && ourGames.Any(t => t.Id == item.Game.Id))
                    {
                        continue;
                    }

                    int awayId = 0;
                    int homeId = 0;

                    if (item.Teams.Home.Id != 0 )
                    {
                        homeId = item.Teams.Home.Id;
                    }
                    else
                    {
                        continue;
                    }

                    if (item.Teams.Away.Id != 0)
                    {
                        awayId = item.Teams.Away.Id;
                    }
                    else
                    {
                        continue;
                    }

                    var dateObj = item.Game.Date;
                    // Combine the date and time strings
                    string dateTimeString = $"{dateObj.Date} {dateObj.Time}";

                    // Parse into DateTime
                    DateTime parsedDateTime = DateTime.ParseExact(
                        dateTimeString,
                        "yyyy-MM-dd HH:mm",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.AssumeUniversal // Treats it as UTC
                    );

                    parsedDateTime = DateTime.SpecifyKind(parsedDateTime, DateTimeKind.Utc);

                    // If you need to adjust from UTC to another timezone, use DateTimeOffset
                    DateTimeOffset dateTimeOffset = DateTimeOffset.ParseExact(
                        dateTimeString,
                        "yyyy-MM-dd HH:mm",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.AssumeUniversal
                    ).ToOffset(TimeSpan.Zero);  // Adjust offset based on timezone if needed

                    int awayScore = 0;
                    int homeScore = 0;

                    if (item.Scores.Home.Total.HasValue)
                    {
                        homeScore = item.Scores.Home.Total.Value;
                    }

                    if (item.Scores.Away.Total.HasValue)
                    {
                        awayScore = item.Scores.Away.Total.Value;
                    }

                    int? weekNumber = null;

                    if (item.Game.Week.StartsWith("Week "))
                    {
                        if (int.TryParse(item.Game.Week.Substring(5), out int result) && result >= 1 && result <= 18)
                        {
                            weekNumber = result;
                        }
                    }

                    string statusGame = "Pending";
                    if (item.Game.Status != null)
                    {
                        if (item.Game.Status.Long != null)
                        {
                            statusGame = item.Game.Status.Long;
                        }
                    }

                    string venueGame = "Pending";
                    if (item.Game.Venue != null)
                    {
                        if (item.Game.Venue.Name != null)
                        {
                            venueGame = item.Game.Venue.Name;
                        }
                    }
                    //Console.WriteLine($"Parsed DateTime: {parsedDateTime}");
                    //Console.WriteLine($"Parsed DateTimeOffset (UTC): {dateTimeOffset}");
                    int? WinnerId = null;
                    if (item.Scores.Home.Total.HasValue && item.Scores.Away.Total.HasValue)
                    {
                        if (item.Scores.Home.Total.Value > item.Scores.Away.Total.Value)
                        {
                            WinnerId = item.Teams.Home.Id;
                        }
                        else if (item.Scores.Home.Total.Value < item.Scores.Away.Total.Value)
                        {
                            WinnerId = item.Teams.Away.Id;
                        }
                        // Si son iguales, WinnerId se mantiene como null
                    }
                    Game newGame = new Game
                    {
                        ExternalId = item.Game.Id,
                        Schedule = parsedDateTime,  
                        Venue = venueGame,
                        Status = statusGame,
                        Round = item.Game.Week,
                        Week = weekNumber,
                        IsDraw = null,
                        SportId = 1,
                        HomeTeamId = homeId,  
                        AwayTeamId = awayId,
                        HomeScore = homeScore,
                        AwayScore = awayScore,
                        WinnerTeamId = WinnerId
                    };

                    _repository.Game.Create(newGame);
                    bulkGames.Add(newGame);
                }

                
                if (bulkGames.Any())
                {
                    await _repository.SaveAsync();
                }

                List<GameDTO> teamDTO = _mapper.Map<List<GameDTO>>(bulkGames);

                return Ok(teamDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkGame action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }
    }
}
