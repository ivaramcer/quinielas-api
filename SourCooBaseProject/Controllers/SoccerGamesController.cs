// using AutoMapper;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using QuinielasApi.IRepository.Configuration;
// using QuinielasApi.JWTConfiguration;
// using QuinielasApi.Models.DTOs;
// using QuinielasApi.Models.Entities;
// using QuinielasApi.Utils.Soccer;
// using System.Globalization;
//
// namespace QuinielasApi.Controllers
// {
//     [Route("api/[controller]")]
//     [AllowAnonymous]
//     [ApiController]
//     public class SoccerGameController : ControllerBase
//     {
//         private readonly JWTUtils _jwtUtils;
//         private readonly IRepositoryWrapper _repository;
//         private readonly IMapper _mapper;
//         private readonly ILogger<SoccerGameController> _logger;
//
//         public SoccerGameController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<SoccerGameController> logger)
//         {
//             _jwtUtils = jwtUtils;
//             _repository = repository;
//             _mapper = mapper;
//             _logger = logger;
//
//         }
//
//
//         [HttpGet("GetAll")]
//         public async Task<IActionResult> GetAllSoccerGame()
//         {
//             try
//             {
//                 var SoccerGames = await _repository.SoccerGame.GetAllAsync();
//                 var SoccerGameDTOs = _mapper.Map<IEnumerable<SoccerGameDTO>>(SoccerGames);
//                 return Ok(SoccerGameDTOs);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside GetAllSoccerGame action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//         [HttpGet("GetNextSoccerGames")]
//         public async Task<IActionResult> GetNextSoccerGames()
//         {
//             try
//             {
//                 var SoccerGames = await _repository.SoccerGame.GetAllAsync();
//                 DateTime time = DateTime.Now;
//
//                 // Filter the SoccerGames for today's date and take the first 5
//                 var filteredSoccerGames = SoccerGames
//                     .Where(g => g.Schedule.Day >= time.Day && g.Schedule.Month == time.Month && g.Schedule.Year == time.Year)
//                     .Take(5)
//                     .ToList();
//
//                 var SoccerGameDTOs = _mapper.Map<IEnumerable<SoccerGameDTO>>(filteredSoccerGames);
//                 return Ok(SoccerGameDTOs);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside GetAllSoccerGame action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//
//         [HttpGet("GetFullNextSoccerGames/{pagination}")]
//         public async Task<IActionResult> GetFullNextSoccerGames(int pagination)
//         {
//             try
//             {
//                 int pageSize = 10;
//                 var SoccerGames = await _repository.SoccerGame.GetAllAsync();
//                 DateTime time = DateTime.Now;
//
//                 // Filter the SoccerGames for today's date and take the first 5
//                 var filteredSoccerGames = SoccerGames
//                     .Where(g => g.Schedule.Day >= time.Day && g.Schedule.Month == time.Month && g.Schedule.Year == time.Year)
//                     .Skip(pageSize * (pagination - 1 ))
//                     .Take(pageSize)
//                     .ToList();
//
//                 var SoccerGameDTOs = _mapper.Map<IEnumerable<SoccerGameDTO>>(filteredSoccerGames);
//                 return Ok(SoccerGameDTOs);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside GetAllSoccerGame action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//         [HttpGet("GetById/{id}")]
//         public async Task<IActionResult> GetSoccerGameById(int id)
//         {
//             try
//             {
//                 var SoccerGame = await _repository.SoccerGame.GetByIdAsync(id);
//                 if (SoccerGame == null)
//                 {
//                     _logger.LogError($"SoccerGame with id: {id} hasn't been found in db.");
//                     return NotFound($"No SoccerGame with the id: {id}");
//                 }
//
//                 var SoccerGameDTO = _mapper.Map<SoccerGameDTO>(SoccerGame);
//                 return Ok(SoccerGameDTO);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside GetSoccerGameById action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//         [HttpPost("Create")]
//         public async Task<IActionResult> CreateSoccerGame([FromBody] SoccerGameInsertDTO SoccerGameDTO)
//         {
//             try
//             {
//                 if (SoccerGameDTO == null)
//                 {
//                     _logger.LogError("SoccerGame object sent from client is null.");
//                     return BadRequest("SoccerGame object is null");
//                 }
//
//                 var SoccerGameEntity = _mapper.Map<SoccerGame>(SoccerGameDTO);
//                 _repository.SoccerGame.Create(SoccerGameEntity);
//                 await _repository.SaveAsync();
//
//                 var createdSoccerGame = _mapper.Map<SoccerGameDTO>(SoccerGameEntity);
//
//                 return CreatedAtRoute("GetSoccerGameById", new { id = SoccerGameEntity.Id }, createdSoccerGame);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside CreateSoccerGame action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//         [HttpPost("CreateBulk")]
//         public async Task<IActionResult> CreateBulkSoccerGame(List<SoccerGameInsertDTO> SoccerGames)
//         {
//             try
//             {
//                 if (SoccerGames == null || !SoccerGames.Any())
//                 {
//                     _logger.LogError($"The server doesn't receive any object from the client");
//                     return StatusCode(500, "The server doesn't receive any object from the client");
//                 }
//
//                 List<SoccerGame> bulkType = _mapper.Map<List<SoccerGame>>(SoccerGames);
//
//
//                 await _repository.SoccerGame.BulkInsert(bulkType);
//                 await _repository.SaveAsync();
//
//                 return Ok();
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside CreateBulkSoccerGame action: {ex.Message}");
//                 return StatusCode(500, "Internal server error ");
//             }
//         }
//
//         [HttpPut("Update/{id}")]
//         public async Task<IActionResult> UpdateSoccerGame(int id, [FromBody] SoccerGameDTO SoccerGameDTO)
//         {
//             try
//             {
//                 if (SoccerGameDTO == null)
//                 {
//                     _logger.LogError("SoccerGame object is null or mismatching ids.");
//                     return BadRequest("Invalid model object or mismatching ids");
//                 }
//
//                 var SoccerGameEntity = await _repository.SoccerGame.GetByIdAsync(id);
//                 if (SoccerGameEntity == null)
//                 {
//                     _logger.LogError($"SoccerGame with id: {id} hasn't been found in db.");
//                     return NotFound($"No SoccerGame with the id: {id}");
//                 }
//
//                 _mapper.Map(SoccerGameDTO, SoccerGameEntity);
//                 _repository.SoccerGame.Update(SoccerGameEntity);
//                 await _repository.SaveAsync();
//
//                 return NoContent();
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside UpdateSoccerGame action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//         [HttpDelete("Delete/{id}")]
//         public async Task<IActionResult> DeleteSoccerGame(int id)
//         {
//             try
//             {
//                 var SoccerGame = await _repository.SoccerGame.GetByIdAsync(id);
//                 if (SoccerGame == null)
//                 {
//                     _logger.LogError($"SoccerGame with id: {id} hasn't been found in db.");
//                     return NotFound($"No SoccerGame with the id: {id}");
//                 }
//
//                 _repository.SoccerGame.Delete(SoccerGame);
//                 await _repository.SaveAsync();
//
//                 return NoContent();
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside DeleteSoccerGame action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//
//         [HttpPost("GetBulkSoccer")]
//         public async Task<IActionResult> GetBulkSoccer(int leagueId)
//         {
//             try
//             {
//                 List<GetGamesDTO>? teamsFromAPI = await APIClientSoccer.GetGames(leagueId);
//
//                 List<SoccerGame> bulkSoccerGames = new List<SoccerGame>();
//                 List<SoccerGame> ourSoccerGames = await _repository.SoccerGame.GetAllAsync();
//                 foreach (var item in teamsFromAPI!)
//                 {
//                     if (ourSoccerGames.Any(t => t.Id == item.Game.Id))
//                     {
//                         continue;
//                     }
//
//                     int awayId = 0;
//                     int homeId = 0;
//
//                     if (item.Teams.Home.Id != 0 )
//                     {
//                         homeId = item.Teams.Home.Id;
//                     }
//                     else
//                     {
//                         continue;
//                     }
//
//                     if (item.Teams.Away.Id != 0)
//                     {
//                         awayId = item.Teams.Away.Id;
//                     }
//                     else
//                     {
//                         continue;
//                     }
//
//                     var dateObj = item.Game.Date;
//                     // Combine the date and time strings
//                     string dateTimeString = $"{dateObj.Date} {dateObj.Time}";
//
//                     // Parse into DateTime
//                     DateTime parsedDateTime = DateTime.ParseExact(
//                         dateTimeString,
//                         "yyyy-MM-dd HH:mm",
//                         CultureInfo.InvariantCulture,
//                         DateTimeStyles.AssumeUniversal // Treats it as UTC
//                     );
//
//                     parsedDateTime = DateTime.SpecifyKind(parsedDateTime, DateTimeKind.Utc);
//
//                     // If you need to adjust from UTC to another timezone, use DateTimeOffset
//                     DateTimeOffset dateTimeOffset = DateTimeOffset.ParseExact(
//                         dateTimeString,
//                         "yyyy-MM-dd HH:mm",
//                         CultureInfo.InvariantCulture,
//                         DateTimeStyles.AssumeUniversal
//                     ).ToOffset(TimeSpan.Zero);  // Adjust offset based on timezone if needed
//
//                     int awayScore = 0;
//                     int homeScore = 0;
//
//                     if (item.Scores.Home.Total.HasValue)
//                     {
//                         homeScore = item.Scores.Home.Total.Value;
//                     }
//
//                     if (item.Scores.Away.Total.HasValue)
//                     {
//                         awayScore = item.Scores.Away.Total.Value;
//                     }
//
//                     int? weekNumber = null;
//
//                     if (item.Game.Week.StartsWith("Week "))
//                     {
//                         if (int.TryParse(item.Game.Week.Substring(5), out int result) && result >= 1 && result <= 18)
//                         {
//                             weekNumber = result;
//                         }
//                     }
//
//                     string statusSoccerGame = "Pending";
//                     if (item.Game.Status != null)
//                     {
//                         if (item.Game.Status.Long != null)
//                         {
//                             statusSoccerGame = item.Game.Status.Long;
//                         }
//                     }
//
//                     string venueSoccerGame = "Pending";
//                     if (item.Game.Venue != null)
//                     {
//                         if (item.Game.Venue.Name != null)
//                         {
//                             venueSoccerGame = item.Game.Venue.Name;
//                         }
//                     }
//                     //Console.WriteLine($"Parsed DateTime: {parsedDateTime}");
//                     //Console.WriteLine($"Parsed DateTimeOffset (UTC): {dateTimeOffset}");
//                     int? WinnerId = null;
//                     if (item.Scores.Home.Total.HasValue && item.Scores.Away.Total.HasValue)
//                     {
//                         if (item.Scores.Home.Total.Value > item.Scores.Away.Total.Value)
//                         {
//                             WinnerId = item.Teams.Home.Id;
//                         }
//                         else if (item.Scores.Home.Total.Value < item.Scores.Away.Total.Value)
//                         {
//                             WinnerId = item.Teams.Away.Id;
//                         }
//                         // Si son iguales, WinnerId se mantiene como null
//                     }
//                     SoccerGame newSoccerGame = new SoccerGame
//                     {
//                         Id = item.Game.Id,
//                         
//                         Schedule = parsedDateTime,  
//                         Venue = venueSoccerGame,
//                         Status = statusSoccerGame,
//                         RoundName = item.Game.Week,
//                         Round = weekNumber,
//                         HomeTeamId = homeId,  
//                         AwayTeamId = awayId,
//                         HomeScore = homeScore,
//                         AwayScore = awayScore,
//                         WinnerTeamId = WinnerId
//                     };
//
//                     _repository.SoccerGame.Create(newSoccerGame);
//                     bulkSoccerGames.Add(newSoccerGame);
//                 }
//
//                 
//                 if (bulkSoccerGames.Any())
//                 {
//                     await _repository.SaveAsync();
//                 }
//
//                 List<SoccerGameDTO> teamDTO = _mapper.Map<List<SoccerGameDTO>>(bulkSoccerGames);
//
//                 return Ok(teamDTO);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside CreateBulkSoccerGame action: {ex.Message}");
//                 return StatusCode(500, "Internal server error ");
//             }
//         }
//     }
// }
