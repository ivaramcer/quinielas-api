// using AutoMapper;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using QuinielasApi.IRepository.Configuration;
// using QuinielasApi.JWTConfiguration;
// using QuinielasApi.Models.DTOs;
// using QuinielasApi.Models.Entities;
// using QuinielasApi.Utils.NFL.SoccerDto;
// using QuinielasApi.Utils.Soccer;
//
// namespace QuinielasApi.Controllers
// {
//     [Route("api/[controller]")]
//     [AllowAnonymous]
//     [ApiController]
//     public class SoccerTeamController : ControllerBase
//     {
//         public const int SoccerId = 2;
//         public const int NFLId = 1;
//         private readonly JWTUtils _jwtUtils;
//         private readonly IRepositoryWrapper _repository;
//         private readonly IMapper _mapper;
//         private readonly ILogger<SoccerTeamController> _logger;
//
//         public SoccerTeamController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<SoccerTeamController> logger)
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
//         public async Task<IActionResult> GetAllSoccerTeam()
//         {
//             try
//             {
//                 var SoccerTeams = await _repository.SoccerTeam.GetAllAsync();
//                 var SoccerTeamDTOs = _mapper.Map<IEnumerable<SoccerTeamDTO>>(SoccerTeams);
//                 return Ok(SoccerTeamDTOs);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside GetAllSoccerTeam action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//         [HttpGet("GetById/{id}")]
//         public async Task<IActionResult> GetSoccerTeamById(int id)
//         {
//             try
//             {
//                 var SoccerTeam = await _repository.SoccerTeam.GetByIdAsync(id);
//                 if (SoccerTeam == null)
//                 {
//                     _logger.LogError($"SoccerTeam with id: {id} hasn't been found in db.");
//                     return NotFound($"No SoccerTeam with the id: {id}");
//                 }
//
//                 var SoccerTeamDTO = _mapper.Map<SoccerTeamDTO>(SoccerTeam);
//                 return Ok(SoccerTeamDTO);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside GetSoccerTeamById action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//         [HttpPost("CreateBulk")]
//         public async Task<IActionResult> CreateBulkSoccerTeam(List<SoccerTeamInsertDTO> SoccerTeams)
//         {
//             try
//             {
//                 if (SoccerTeams == null || !SoccerTeams.Any())
//                 {
//                     _logger.LogError($"The server doesn't receive any object from the client");
//                     return StatusCode(500, "The server doesn't receive any object from the client");
//                 }
//
//                 List<SoccerTeam> bulkType = _mapper.Map<List<SoccerTeam>>(SoccerTeams);
//
//
//                 await _repository.SoccerTeam.BulkInsert(bulkType);
//                 await _repository.SaveAsync();
//
//                 return Ok();
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside CreateBulkSoccerTeam action: {ex.Message}");
//                 return StatusCode(500, "Internal server error ");
//             }
//         }
//
//         [HttpPut("Update/{id}")]
//         public async Task<IActionResult> UpdateSoccerTeam(int id, [FromBody] SoccerTeamDTO SoccerTeamDTO)
//         {
//             try
//             {
//                 if (SoccerTeamDTO == null)
//                 {
//                     _logger.LogError("SoccerTeam object is null or mismatching ids.");
//                     return BadRequest("Invalid model object or mismatching ids");
//                 }
//
//                 var SoccerTeamEntity = await _repository.SoccerTeam.GetByIdAsync(id);
//                 if (SoccerTeamEntity == null)
//                 {
//                     _logger.LogError($"SoccerTeam with id: {id} hasn't been found in db.");
//                     return NotFound($"No SoccerTeam with the id: {id}");
//                 }
//
//                 _mapper.Map(SoccerTeamDTO, SoccerTeamEntity);
//                 _repository.SoccerTeam.Update(SoccerTeamEntity);
//                 await _repository.SaveAsync();
//
//                 return NoContent();
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside UpdateSoccerTeam action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//         [HttpDelete("Delete/{id}")]
//         public async Task<IActionResult> DeleteSoccerTeam(int id)
//         {
//             try
//             {
//                 var SoccerTeam = await _repository.SoccerTeam.GetByIdAsync(id);
//                 if (SoccerTeam == null)
//                 {
//                     _logger.LogError($"SoccerTeam with id: {id} hasn't been found in db.");
//                     return NotFound($"No SoccerTeam with the id: {id}");
//                 }
//
//                 _repository.SoccerTeam.Delete(SoccerTeam);
//                 await _repository.SaveAsync();
//
//                 return NoContent();
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside DeleteSoccerTeam action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//
//         [HttpPost("GetTeamsSoccer")]
//         public async Task<IActionResult> GetTeamsSoccer(int leagueId)
//         {
//             try
//             {
//                 List<GetTeamsSoccerDto>? SoccerTeamsFromAPI = await APIClientSoccer.GetTeams();
//
//                 List<SoccerTeam> bulkType = new List<SoccerTeam>();
//                 List<SoccerTeam> ourSoccerTeams = await _repository.SoccerTeam.GetAllAsync();
//
//                 foreach (var item in SoccerTeamsFromAPI!)
//                 {
//                     if (ourSoccerTeams.Any(t => t.Id == item.Id))
//                     {
//                         continue;
//                     }
//
//                     if (item.Id.HasValue == false)
//                     {
//                         continue;
//                     }
//                     SoccerTeam newSoccerTeam = new SoccerTeam
//                     {
//                         Id = item.Id.Value,
//                         Name = item.Name!,
//                         SoccerLeagueId = leagueId,
//                         Abbreviation = string.IsNullOrEmpty(item.Code) ? "" : item.Code,
//                         ImageURL = string.IsNullOrEmpty(item.Logo) ? "" : item.Logo,
//                         City = string.IsNullOrEmpty(item.City) ? "" : item.City
//                     };
//
//                     _repository.SoccerTeam.Create(newSoccerTeam);
//                     bulkType.Add(newSoccerTeam);
//                 }
//
//                 if (bulkType.Any())
//                 {
//                     await _repository.SaveAsync();
//                 }
//
//                 List<SoccerTeamDTO> SoccerTeamDTO = _mapper.Map<List<SoccerTeamDTO>>(bulkType);
//
//                 return Ok(SoccerTeamDTO);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside CreateBulkSoccerTeam action: {ex.Message}");
//                 return StatusCode(500, "Internal server error ");
//             }
//         }
//
//
//         [HttpPost("GetLeaguesSoccer")]
//         public async Task<IActionResult> GetLeaguesSoccer()
//         {
//             try
//             {
//                 List<LeagueInfoSoccerDto>? SoccerTeamsFromAPI = await APIClientSoccer.GetLeagues();
//
//                 List<SoccerLeague> bulkType = new List<SoccerLeague>();
//                 List<SoccerLeague> ourSoccerLeagues = await _repository.SoccerLeague.GetAllAsync();
//
//                 foreach (var item in SoccerTeamsFromAPI!)
//                 {
//                     if (ourSoccerLeagues.Any(t => t.Id == item.League.Id))
//                     {
//                         continue;
//                     }
//
//                     SoccerLeague newSoccerLeague = new SoccerLeague
//                     {
//                         Id = item.League.Id,
//                         Name = item.League.Name!,
//                         ImageURL = string.IsNullOrEmpty(item.League.Logo) ? "" : item.League.Logo,
//                         IsActive = true,
//                     };
//
//                     _repository.SoccerLeague.Create(newSoccerLeague);
//                     bulkType.Add(newSoccerLeague);
//                 }
//
//                 if (bulkType.Any())
//                 {
//                     await _repository.SaveAsync();
//                 }
//
//
//                 return Ok(bulkType);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside CreateBulkSoccerTeam action: {ex.Message}");
//                 return StatusCode(500, "Internal server error ");
//             }
//         }
//     }
//
//
//
// }
