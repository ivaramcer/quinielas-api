// using AutoMapper;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using QuinielasApi.IRepository.Configuration;
// using QuinielasApi.JWTConfiguration;
// using QuinielasApi.Models.DTOs;
// using QuinielasApi.Models.Entities;
// using QuinielasApi.Utils.NFL;
// using QuinielasApi.Utils.NFL.DTO;
//
// namespace QuinielasApi.Controllers
// {
//     [Route("api/[controller]")]
//     [AllowAnonymous]
//     [ApiController]
//     public class NFLTeamController : ControllerBase
//     {
//         public const int NFLId = 2;
//         public const int SoccerId = 1;
//         private readonly JWTUtils _jwtUtils;
//         private readonly IRepositoryWrapper _repository;
//         private readonly IMapper _mapper;
//         private readonly ILogger<NFLTeamController> _logger;
//
//         public NFLTeamController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<NFLTeamController> logger)
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
//         public async Task<IActionResult> GetAllNFLTeam()
//         {
//             try
//             {
//                 var NFLTeams = await _repository.NFLTeam.GetAllAsync();
//                 var NFLTeamDTOs = _mapper.Map<IEnumerable<NFLTeamDTO>>(NFLTeams);
//                 return Ok(NFLTeamDTOs);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside GetAllNFLTeam action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//         [HttpGet("GetById/{id}")]
//         public async Task<IActionResult> GetNFLTeamById(int id)
//         {
//             try
//             {
//                 var NFLTeam = await _repository.NFLTeam.GetByIdAsync(id);
//                 if (NFLTeam == null)
//                 {
//                     _logger.LogError($"NFLTeam with id: {id} hasn't been found in db.");
//                     return NotFound($"No NFLTeam with the id: {id}");
//                 }
//
//                 var NFLTeamDTO = _mapper.Map<NFLTeamDTO>(NFLTeam);
//                 return Ok(NFLTeamDTO);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside GetNFLTeamById action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//         [HttpPost("Create")]
//         public async Task<IActionResult> CreateNFLTeam([FromBody] NFLTeamInsertDTO NFLTeamDTO)
//         {
//             try
//             {
//                 if (NFLTeamDTO == null)
//                 {
//                     _logger.LogError("NFLTeam object sent from client is null.");
//                     return BadRequest("NFLTeam object is null");
//                 }
//
//                 var NFLTeamEntity = _mapper.Map<NFLTeam>(NFLTeamDTO);
//                 _repository.NFLTeam.Create(NFLTeamEntity);
//                 await _repository.SaveAsync();
//
//                 var createdNFLTeam = _mapper.Map<NFLTeamDTO>(NFLTeamEntity);
//
//                 return CreatedAtRoute("GetNFLTeamById", new { id = NFLTeamEntity.Id }, createdNFLTeam);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside CreateNFLTeam action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//         [HttpPost("CreateBulk")]
//         public async Task<IActionResult> CreateBulkNFLTeam(List<NFLTeamInsertDTO> NFLTeams)
//         {
//             try
//             {
//                 if (NFLTeams == null || !NFLTeams.Any())
//                 {
//                     _logger.LogError($"The server doesn't receive any object from the client");
//                     return StatusCode(500, "The server doesn't receive any object from the client");
//                 }
//
//                 List<NFLTeam> bulkType = _mapper.Map<List<NFLTeam>>(NFLTeams);
//
//
//                 await _repository.NFLTeam.BulkInsert(bulkType);
//                 await _repository.SaveAsync();
//
//                 return Ok();
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside CreateBulkNFLTeam action: {ex.Message}");
//                 return StatusCode(500, "Internal server error ");
//             }
//         }
//
//         [HttpPut("Update/{id}")]
//         public async Task<IActionResult> UpdateNFLTeam(int id, [FromBody] NFLTeamDTO NFLTeamDTO)
//         {
//             try
//             {
//                 if (NFLTeamDTO == null)
//                 {
//                     _logger.LogError("NFLTeam object is null or mismatching ids.");
//                     return BadRequest("Invalid model object or mismatching ids");
//                 }
//
//                 var NFLTeamEntity = await _repository.NFLTeam.GetByIdAsync(id);
//                 if (NFLTeamEntity == null)
//                 {
//                     _logger.LogError($"NFLTeam with id: {id} hasn't been found in db.");
//                     return NotFound($"No NFLTeam with the id: {id}");
//                 }
//
//                 _mapper.Map(NFLTeamDTO, NFLTeamEntity);
//                 _repository.NFLTeam.Update(NFLTeamEntity);
//                 await _repository.SaveAsync();
//
//                 return NoContent();
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside UpdateNFLTeam action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//         [HttpDelete("Delete/{id}")]
//         public async Task<IActionResult> DeleteNFLTeam(int id)
//         {
//             try
//             {
//                 var NFLTeam = await _repository.NFLTeam.GetByIdAsync(id);
//                 if (NFLTeam == null)
//                 {
//                     _logger.LogError($"NFLTeam with id: {id} hasn't been found in db.");
//                     return NotFound($"No NFLTeam with the id: {id}");
//                 }
//
//                 _repository.NFLTeam.Delete(NFLTeam);
//                 await _repository.SaveAsync();
//
//                 return NoContent();
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside DeleteNFLTeam action: {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }
//
//
//         [HttpPost("GetTeamsNFL")]
//         public async Task<IActionResult> GetTeamsNFL(int leagueId)
//         {
//             try
//             {
//                 List<GetTeamsDTO>? NFLTeamsFromAPI = await APIClientNFL.GetTeams();
//
//                 List<NFLTeam> bulkType = new List<NFLTeam>();
//                 List<NFLTeam> ourNFLTeams = await _repository.NFLTeam.GetAllAsync();
//
//                 foreach (var item in NFLTeamsFromAPI!)
//                 {
//                     if (ourNFLTeams.Any(t => t.Id == item.Id))
//                     {
//                         continue;
//                     }
//
//                     if (item.Id.HasValue == false)
//                     {
//                         continue;
//                     }
//                     NFLTeam newNFLTeam = new NFLTeam
//                     {
//                         Id = item.Id.Value,
//                         Name = item.Name!,
//                         NFLLeagueId = leagueId,
//                         Abbreviation = string.IsNullOrEmpty(item.Code) ? "" : item.Code,
//                         ImageURL = string.IsNullOrEmpty(item.Logo) ? "" : item.Logo,
//                         City = string.IsNullOrEmpty(item.City) ? "" : item.City
//                     };
//
//                     _repository.NFLTeam.Create(newNFLTeam);
//                     bulkType.Add(newNFLTeam);
//                 }
//
//                 if (bulkType.Any())
//                 {
//                     await _repository.SaveAsync();
//                 }
//
//                 List<NFLTeamDTO> NFLTeamDTO = _mapper.Map<List<NFLTeamDTO>>(bulkType);
//
//                 return Ok(NFLTeamDTO);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError($"Something went wrong inside CreateBulkNFLTeam action: {ex.Message}");
//                 return StatusCode(500, "Internal server error ");
//             }
//         }
//
//
//         [HttpPost("GetLeaguesNFL")]
//         public async Task<IActionResult> GetLeaguesNFL()
//         {
//             try
//             {
//                 List<LeagueInfoDto>? NFLTeamsFromAPI = await APIClientNFL.GetLeagues();
//
//                 List<NFLLeague> bulkType = new List<NFLLeague>();
//                 List<NFLLeague> ourNFLLeagues = await _repository.NFLLeague.GetAllAsync();
//
//                 foreach (var item in NFLTeamsFromAPI!)
//                 {
//                     if (ourNFLLeagues.Any(t => t.Id == item.League.Id))
//                     {
//                         continue;
//                     }
//
//                     NFLLeague newNFLLeague = new NFLLeague
//                     {
//                         Id = item.League.Id,
//                         Name = item.League.Name!,
//                         ImageURL = string.IsNullOrEmpty(item.League.Logo) ? "" : item.League.Logo,
//                         IsActive = true,
//                     };
//
//                     _repository.NFLLeague.Create(newNFLLeague);
//                     bulkType.Add(newNFLLeague);
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
//                 _logger.LogError($"Something went wrong inside CreateBulkNFLTeam action: {ex.Message}");
//                 return StatusCode(500, "Internal server error ");
//             }
//         }
//     }
//
//
//
// }
