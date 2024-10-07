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
    public class NFLLeagueController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<NFLLeagueController> _logger;

        public NFLLeagueController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<NFLLeagueController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllNFLLeague()
        {
            try
            {
                var NFLLeagues = await _repository.NFLLeague.GetAllAsync();
                var NFLLeagueDTOs = _mapper.Map<IEnumerable<NFLLeagueDTO>>(NFLLeagues);
                return Ok(NFLLeagueDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllNFLLeague action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetNFLLeagueById(int id)
        {
            try
            {
                var NFLLeague = await _repository.NFLLeague.GetByIdAsync(id);
                if (NFLLeague == null)
                {
                    _logger.LogError($"NFLLeague with id: {id} hasn't been found in db.");
                    return NotFound($"No NFLLeague with the id: {id}");
                }

                var NFLLeagueDTO = _mapper.Map<NFLLeagueDTO>(NFLLeague);
                return Ok(NFLLeagueDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetNFLLeagueById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

      
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateNFLLeague(int id, [FromBody] NFLLeagueDTO NFLLeagueDTO)
        {
            try
            {
                if (NFLLeagueDTO == null)
                {
                    _logger.LogError("NFLLeague object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                var NFLLeagueEntity = await _repository.NFLLeague.GetByIdAsync(id);
                if (NFLLeagueEntity == null)
                {
                    _logger.LogError($"NFLLeague with id: {id} hasn't been found in db.");
                    return NotFound($"No NFLLeague with the id: {id}");
                }

                _mapper.Map(NFLLeagueDTO, NFLLeagueEntity);
                _repository.NFLLeague.Update(NFLLeagueEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateNFLLeague action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteNFLLeague(int id)
        {
            try
            {
                var NFLLeague = await _repository.NFLLeague.GetByIdAsync(id);
                if (NFLLeague == null)
                {
                    _logger.LogError($"NFLLeague with id: {id} hasn't been found in db.");
                    return NotFound($"No NFLLeague with the id: {id}");
                }

                _repository.NFLLeague.Delete(NFLLeague);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteNFLLeague action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
