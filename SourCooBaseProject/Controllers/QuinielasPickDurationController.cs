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
    public class QuinielasPickDurationController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<QuinielasPickDurationController> _logger;

        public QuinielasPickDurationController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<QuinielasPickDurationController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }


        [HttpGet("GetAllQuinielaPickDuration")]
        public async Task<IActionResult> GetAllQuinielaPickDuration()
        {
            try
            {
                var QuinielaPickDurations = await _repository.QuinielaPickDuration.GetAllAsync();
                var QuinielaPickDurationDTOs = _mapper.Map<IEnumerable<QuinielaPickDurationDTO>>(QuinielaPickDurations);
                return Ok(QuinielaPickDurationDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllQuinielaPickDuration action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetQuinielaPickDurationById/{id}")]
        public async Task<IActionResult> GetQuinielaPickDurationById(int id)
        {
            try
            {
                var QuinielaPickDuration = await _repository.QuinielaPickDuration.GetByIdAsync(id);
                if (QuinielaPickDuration == null)
                {
                    _logger.LogError($"QuinielaPickDuration with id: {id} hasn't been found in db.");
                    return NotFound($"No QuinielaPickDuration with the id: {id}");
                }

                var QuinielaPickDurationDTO = _mapper.Map<QuinielaPickDurationDTO>(QuinielaPickDuration);
                return Ok(QuinielaPickDurationDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetQuinielaPickDurationById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateQuinielaPickDuration")]
        public async Task<IActionResult> CreateQuinielaPickDuration([FromBody] QuinielaPickDurationDTO QuinielaPickDurationDTO)
        {
            try
            {
                if (QuinielaPickDurationDTO == null)
                {
                    _logger.LogError("QuinielaPickDuration object sent from client is null.");
                    return BadRequest("QuinielaPickDuration object is null");
                }

                var QuinielaPickDurationEntity = _mapper.Map<QuinielaPickDuration>(QuinielaPickDurationDTO);
                _repository.QuinielaPickDuration.Create(QuinielaPickDurationEntity);
                await _repository.SaveAsync();

                var createdQuinielaPickDuration = _mapper.Map<QuinielaPickDurationDTO>(QuinielaPickDurationEntity);

                return CreatedAtRoute("GetQuinielaPickDurationById", new { id = QuinielaPickDurationEntity.Id }, createdQuinielaPickDuration);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateQuinielaPickDuration action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateBulkQuinielaPickDuration")]
        public async Task<IActionResult> CreateBulkQuinielaPickDuration(List<QuinielaPickDurationDTO> QuinielaPickDurations)
        {
            try
            {
                if (QuinielaPickDurations == null || !QuinielaPickDurations.Any())
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                List<QuinielaPickDuration> bulkType = _mapper.Map<List<QuinielaPickDuration>>(QuinielaPickDurations);


                await _repository.QuinielaPickDuration.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkQuinielaPickDuration action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPut("UpdateQuinielaPickDuration/{id}")]
        public async Task<IActionResult> UpdateQuinielaPickDuration(int id, [FromBody] QuinielaPickDurationDTO QuinielaPickDurationDTO)
        {
            try
            {
                if (QuinielaPickDurationDTO == null)
                {
                    _logger.LogError("QuinielaPickDuration object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                var QuinielaPickDurationEntity = await _repository.QuinielaPickDuration.GetByIdAsync(id);
                if (QuinielaPickDurationEntity == null)
                {
                    _logger.LogError($"QuinielaPickDuration with id: {id} hasn't been found in db.");
                    return NotFound($"No QuinielaPickDuration with the id: {id}");
                }

                _mapper.Map(QuinielaPickDurationDTO, QuinielaPickDurationEntity);
                _repository.QuinielaPickDuration.Update(QuinielaPickDurationEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateQuinielaPickDuration action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("DeleteQuinielaPickDuration/{id}")]
        public async Task<IActionResult> DeleteQuinielaPickDuration(int id)
        {
            try
            {
                var QuinielaPickDuration = await _repository.QuinielaPickDuration.GetByIdAsync(id);
                if (QuinielaPickDuration == null)
                {
                    _logger.LogError($"QuinielaPickDuration with id: {id} hasn't been found in db.");
                    return NotFound($"No QuinielaPickDuration with the id: {id}");
                }

                _repository.QuinielaPickDuration.Delete(QuinielaPickDuration);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteQuinielaPickDuration action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
