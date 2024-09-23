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
    public class SoccerLeagueController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<SoccerLeagueController> _logger;

        public SoccerLeagueController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<SoccerLeagueController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSoccerLeague()
        {
            try
            {
                var SoccerLeagues = await _repository.SoccerLeague.GetAllAsync();
                var SoccerLeagueDTOs = _mapper.Map<IEnumerable<SoccerLeagueDTO>>(SoccerLeagues);
                return Ok(SoccerLeagueDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllSoccerLeague action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetSoccerLeagueById(int id)
        {
            try
            {
                var SoccerLeague = await _repository.SoccerLeague.GetByIdAsync(id);
                if (SoccerLeague == null)
                {
                    _logger.LogError($"SoccerLeague with id: {id} hasn't been found in db.");
                    return NotFound($"No SoccerLeague with the id: {id}");
                }

                var SoccerLeagueDTO = _mapper.Map<SoccerLeagueDTO>(SoccerLeague);
                return Ok(SoccerLeagueDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSoccerLeagueById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateSoccerLeague([FromBody] SoccerLeagueDTO SoccerLeagueDTO)
        {
            try
            {
                if (SoccerLeagueDTO == null)
                {
                    _logger.LogError("SoccerLeague object sent from client is null.");
                    return BadRequest("SoccerLeague object is null");
                }

                var SoccerLeagueEntity = _mapper.Map<SoccerLeague>(SoccerLeagueDTO);
                _repository.SoccerLeague.Create(SoccerLeagueEntity);
                await _repository.SaveAsync();

                var createdSoccerLeague = _mapper.Map<SoccerLeagueDTO>(SoccerLeagueEntity);

                return CreatedAtRoute("GetSoccerLeagueById", new { id = SoccerLeagueEntity.Id }, createdSoccerLeague);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSoccerLeague action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulkSoccerLeague(List<SoccerLeagueDTO> SoccerLeagues)
        {
            try
            {
                if (SoccerLeagues == null || !SoccerLeagues.Any())
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                List<SoccerLeague> bulkType = _mapper.Map<List<SoccerLeague>>(SoccerLeagues);


                await _repository.SoccerLeague.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkSoccerLeague action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateSoccerLeague(int id, [FromBody] SoccerLeagueDTO SoccerLeagueDTO)
        {
            try
            {
                if (SoccerLeagueDTO == null)
                {
                    _logger.LogError("SoccerLeague object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                var SoccerLeagueEntity = await _repository.SoccerLeague.GetByIdAsync(id);
                if (SoccerLeagueEntity == null)
                {
                    _logger.LogError($"SoccerLeague with id: {id} hasn't been found in db.");
                    return NotFound($"No SoccerLeague with the id: {id}");
                }

                _mapper.Map(SoccerLeagueDTO, SoccerLeagueEntity);
                _repository.SoccerLeague.Update(SoccerLeagueEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSoccerLeague action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteSoccerLeague(int id)
        {
            try
            {
                var SoccerLeague = await _repository.SoccerLeague.GetByIdAsync(id);
                if (SoccerLeague == null)
                {
                    _logger.LogError($"SoccerLeague with id: {id} hasn't been found in db.");
                    return NotFound($"No SoccerLeague with the id: {id}");
                }

                _repository.SoccerLeague.Delete(SoccerLeague);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteSoccerLeague action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
