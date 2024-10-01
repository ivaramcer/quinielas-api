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
    public class TeamController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<TeamController> _logger;

        public TeamController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<TeamController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllTeam()
        {
            try
            {
                var Teams = await _repository.Team.GetAllAsync();
                var TeamDTOs = _mapper.Map<IEnumerable<TeamDTO>>(Teams);
                return Ok(TeamDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllTeam action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            try
            {
                var Team = await _repository.Team.GetByIdAsync(id);
                if (Team == null)
                {
                    _logger.LogError($"Team with id: {id} hasn't been found in db.");
                    return NotFound($"No Team with the id: {id}");
                }

                var TeamDTO = _mapper.Map<TeamDTO>(Team);
                return Ok(TeamDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetTeamById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTeam([FromBody] TeamInsertDTO TeamDTO)
        {
            try
            {
                if (TeamDTO == null)
                {
                    _logger.LogError("Team object sent from client is null.");
                    return BadRequest("Team object is null");
                }

                var TeamEntity = _mapper.Map<Team>(TeamDTO);
                _repository.Team.Create(TeamEntity);
                await _repository.SaveAsync();

                var createdTeam = _mapper.Map<TeamDTO>(TeamEntity);

                return CreatedAtRoute("GetTeamById", new { id = TeamEntity.Id }, createdTeam);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateTeam action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulkTeam(List<TeamInsertDTO> Teams)
        {
            try
            {
                if (Teams == null || !Teams.Any())
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                List<Team> bulkType = _mapper.Map<List<Team>>(Teams);


                await _repository.Team.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkTeam action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] TeamDTO TeamDTO)
        {
            try
            {
                if (TeamDTO == null)
                {
                    _logger.LogError("Team object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                var TeamEntity = await _repository.Team.GetByIdAsync(id);
                if (TeamEntity == null)
                {
                    _logger.LogError($"Team with id: {id} hasn't been found in db.");
                    return NotFound($"No Team with the id: {id}");
                }

                _mapper.Map(TeamDTO, TeamEntity);
                _repository.Team.Update(TeamEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateTeam action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            try
            {
                var Team = await _repository.Team.GetByIdAsync(id);
                if (Team == null)
                {
                    _logger.LogError($"Team with id: {id} hasn't been found in db.");
                    return NotFound($"No Team with the id: {id}");
                }

                _repository.Team.Delete(Team);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteTeam action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost("GetBulk")]
        public async Task<IActionResult> GetBulk(List<TeamInsertDTO> Teams)
        {
            try
            {
                if (Teams == null || !Teams.Any())
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                List<Team> bulkType = _mapper.Map<List<Team>>(Teams);


                await _repository.Team.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkTeam action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }
    }
}
