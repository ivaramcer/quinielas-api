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

namespace QuinielasApi.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class NFLGameController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<NFLGameController> _logger;

        public NFLGameController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<NFLGameController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllNFLGame()
        {
            try
            {
                var NFLGames = await _repository.NFLGame.GetAllAsync();
                var NFLGameDTOs = _mapper.Map<IEnumerable<NFLGameDTO>>(NFLGames);
                return Ok(NFLGameDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllNFLGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetNextNFLGames")]
        public async Task<IActionResult> GetNextNFLGames()
        {
            try
            {
                var NFLGames = await _repository.NFLGame.GetAllAsync();
                DateTime time = DateTime.Now;

                // Filter the NFLGames for today's date and take the first 5
                var filteredNFLGames = NFLGames
                    .Where(g => g.Schedule.Day >= time.Day && g.Schedule.Month == time.Month && g.Schedule.Year == time.Year)
                    .Take(5)
                    .ToList();

                var NFLGameDTOs = _mapper.Map<IEnumerable<NFLGameDTO>>(filteredNFLGames);
                return Ok(NFLGameDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllNFLGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("GetFullNextNFLGames/{pagination}")]
        public async Task<IActionResult> GetFullNextNFLGames(int pagination)
        {
            try
            {
                int pageSize = 10;
                var NFLGames = await _repository.NFLGame.GetAllAsync();
                DateTime time = DateTime.Now;

                // Filter the NFLGames for today's date and take the first 5
                var filteredNFLGames = NFLGames
                    .Where(g => g.Schedule.Day >= time.Day && g.Schedule.Month == time.Month && g.Schedule.Year == time.Year)
                    .Skip(pageSize * (pagination - 1 ))
                    .Take(pageSize)
                    .ToList();

                var NFLGameDTOs = _mapper.Map<IEnumerable<NFLGameDTO>>(filteredNFLGames);
                return Ok(NFLGameDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllNFLGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetNFLGameById(int id)
        {
            try
            {
                var NFLGame = await _repository.NFLGame.GetByIdAsync(id);
                if (NFLGame == null)
                {
                    _logger.LogError($"NFLGame with id: {id} hasn't been found in db.");
                    return NotFound($"No NFLGame with the id: {id}");
                }

                var NFLGameDTO = _mapper.Map<NFLGameDTO>(NFLGame);
                return Ok(NFLGameDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetNFLGameById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateNFLGame([FromBody] NFLGameInsertDTO NFLGameDTO)
        {
            try
            {
                if (NFLGameDTO == null)
                {
                    _logger.LogError("NFLGame object sent from client is null.");
                    return BadRequest("NFLGame object is null");
                }

                var NFLGameEntity = _mapper.Map<NFLGame>(NFLGameDTO);
                _repository.NFLGame.Create(NFLGameEntity);
                await _repository.SaveAsync();

                var createdNFLGame = _mapper.Map<NFLGameDTO>(NFLGameEntity);

                return CreatedAtRoute("GetNFLGameById", new { id = NFLGameEntity.Id }, createdNFLGame);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateNFLGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulkNFLGame(List<NFLGameInsertDTO> NFLGames)
        {
            try
            {
                if (NFLGames == null || !NFLGames.Any())
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                List<NFLGame> bulkType = _mapper.Map<List<NFLGame>>(NFLGames);


                await _repository.NFLGame.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkNFLGame action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateNFLGame(int id, [FromBody] NFLGameDTO NFLGameDTO)
        {
            try
            {
                if (NFLGameDTO == null)
                {
                    _logger.LogError("NFLGame object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                var NFLGameEntity = await _repository.NFLGame.GetByIdAsync(id);
                if (NFLGameEntity == null)
                {
                    _logger.LogError($"NFLGame with id: {id} hasn't been found in db.");
                    return NotFound($"No NFLGame with the id: {id}");
                }

                _mapper.Map(NFLGameDTO, NFLGameEntity);
                _repository.NFLGame.Update(NFLGameEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateNFLGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteNFLGame(int id)
        {
            try
            {
                var NFLGame = await _repository.NFLGame.GetByIdAsync(id);
                if (NFLGame == null)
                {
                    _logger.LogError($"NFLGame with id: {id} hasn't been found in db.");
                    return NotFound($"No NFLGame with the id: {id}");
                }

                _repository.NFLGame.Delete(NFLGame);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteNFLGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost("GetBulkNFL")]
        public async Task<IActionResult> GetBulkNFL()
        {
            try
            {
                List<GetGamesDTO>? teamsFromAPI = await APIClientNFL.GetGames();

                List<NFLGame> bulkNFLGames = new List<NFLGame>();
                List<NFLGame> ourNFLGames = await _repository.NFLGame.GetAllAsync();
                foreach (var item in teamsFromAPI!)
                {
                    if (ourNFLGames.Any(t => t.Id == item.Game.Id))
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

                    string statusNFLGame = "Pending";
                    if (item.Game.Status != null)
                    {
                        if (item.Game.Status.Long != null)
                        {
                            statusNFLGame = item.Game.Status.Long;
                        }
                    }

                    string venueNFLGame = "Pending";
                    if (item.Game.Venue != null)
                    {
                        if (item.Game.Venue.Name != null)
                        {
                            venueNFLGame = item.Game.Venue.Name;
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
                    NFLGame newNFLGame = new NFLGame
                    {
                        Id = item.Game.Id,
                        Schedule = parsedDateTime,  
                        Venue = venueNFLGame,
                        Status = statusNFLGame,
                        WeekString = item.Game.Week,
                        Week = weekNumber,
                        HomeTeamId = homeId,  
                        AwayTeamId = awayId,
                        HomeScore = homeScore,
                        AwayScore = awayScore,
                        WinnerTeamId = WinnerId
                    };

                    _repository.NFLGame.Create(newNFLGame);
                    bulkNFLGames.Add(newNFLGame);
                }

                
                if (bulkNFLGames.Any())
                {
                    await _repository.SaveAsync();
                }

                List<NFLGameDTO> teamDTO = _mapper.Map<List<NFLGameDTO>>(bulkNFLGames);

                return Ok(teamDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkNFLGame action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }
    }
}
