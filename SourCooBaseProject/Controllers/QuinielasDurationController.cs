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
    public class QuinielasDurationController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<QuinielasDurationController> _logger;

        public QuinielasDurationController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<QuinielasDurationController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllQuinielaDuration()
        {
            try
            {
                var QuinielaDurations = await _repository.QuinielaDuration.GetAllAsync();
                var QuinielaDurationDTOs = _mapper.Map<IEnumerable<QuinielaDurationDTO>>(QuinielaDurations);
                return Ok(QuinielaDurationDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllQuinielaDuration action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetQuinielaDurationById(int id)
        {
            try
            {
                var QuinielaDuration = await _repository.QuinielaDuration.GetByIdAsync(id);
                if (QuinielaDuration == null)
                {
                    _logger.LogError($"QuinielaDuration with id: {id} hasn't been found in db.");
                    return NotFound($"No QuinielaDuration with the id: {id}");
                }

                var QuinielaDurationDTO = _mapper.Map<QuinielaDurationDTO>(QuinielaDuration);
                return Ok(QuinielaDurationDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetQuinielaDurationById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetListByQuinielaTypeId/{quinielaTypeId}")]
        public async Task<IActionResult> GetListByQuinielaTypeId(int quinielaTypeId)
        {
            try
            {
                var QuinielaDurations = await _repository.QuinielaDuration.GetListByQuinielaTypeIdAsync(quinielaTypeId);

                var QuinielaDurationDTOs = _mapper.Map<IEnumerable<QuinielaDurationDTO>>(QuinielaDurations);
                return Ok(QuinielaDurationDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetQuinielaDurationById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateQuinielaDuration([FromBody] QuinielaDurationInsertDTO QuinielaDurationDTO)
        {
            try
            {
                if (QuinielaDurationDTO == null)
                {
                    _logger.LogError("QuinielaDuration object sent from client is null.");
                    return BadRequest("QuinielaDuration object is null");
                }

                var QuinielaDurationEntity = _mapper.Map<QuinielaDuration>(QuinielaDurationDTO);
                _repository.QuinielaDuration.Create(QuinielaDurationEntity);
                await _repository.SaveAsync();

                var createdQuinielaDuration = _mapper.Map<QuinielaDurationDTO>(QuinielaDurationEntity);

                return CreatedAtRoute("GetQuinielaDurationById", new { id = QuinielaDurationEntity.Id }, createdQuinielaDuration);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateQuinielaDuration action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulkQuinielaDuration(List<QuinielaDurationInsertDTO> QuinielaDurations)
        {
            try
            {
                if (QuinielaDurations == null || !QuinielaDurations.Any())
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                List<QuinielaDuration> bulkType = _mapper.Map<List<QuinielaDuration>>(QuinielaDurations);


                await _repository.QuinielaDuration.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkQuinielaDuration action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateQuinielaDuration(int id, [FromBody] QuinielaDurationDTO QuinielaDurationDTO)
        {
            try
            {
                if (QuinielaDurationDTO == null)
                {
                    _logger.LogError("QuinielaDuration object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                var QuinielaDurationEntity = await _repository.QuinielaDuration.GetByIdAsync(id);
                if (QuinielaDurationEntity == null)
                {
                    _logger.LogError($"QuinielaDuration with id: {id} hasn't been found in db.");
                    return NotFound($"No QuinielaDuration with the id: {id}");
                }

                _mapper.Map(QuinielaDurationDTO, QuinielaDurationEntity);
                _repository.QuinielaDuration.Update(QuinielaDurationEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateQuinielaDuration action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteQuinielaDuration(int id)
        {
            try
            {
                var QuinielaDuration = await _repository.QuinielaDuration.GetByIdAsync(id);
                if (QuinielaDuration == null)
                {
                    _logger.LogError($"QuinielaDuration with id: {id} hasn't been found in db.");
                    return NotFound($"No QuinielaDuration with the id: {id}");
                }

                _repository.QuinielaDuration.Delete(QuinielaDuration);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteQuinielaDuration action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
