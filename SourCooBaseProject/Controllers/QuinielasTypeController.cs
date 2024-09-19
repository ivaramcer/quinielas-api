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
    public class QuinielasTypeController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<QuinielasTypeController> _logger;

        public QuinielasTypeController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<QuinielasTypeController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }


        [HttpGet("GetAllQuinielaType")]
        public async Task<IActionResult> GetAllQuinielaType()
        {
            try
            {
                var QuinielaTypes = await _repository.QuinielaType.GetAllAsync();
                var QuinielaTypeDTOs = _mapper.Map<IEnumerable<QuinielaTypeDTO>>(QuinielaTypes);
                return Ok(QuinielaTypeDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllQuinielaType action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetQuinielaTypeById/{id}")]
        public async Task<IActionResult> GetQuinielaTypeById(int id)
        {
            try
            {
                var QuinielaType = await _repository.QuinielaType.GetByIdAsync(id);
                if (QuinielaType == null)
                {
                    _logger.LogError($"QuinielaType with id: {id} hasn't been found in db.");
                    return NotFound($"No QuinielaType with the id: {id}");
                }

                var QuinielaTypeDTO = _mapper.Map<QuinielaTypeDTO>(QuinielaType);
                return Ok(QuinielaTypeDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetQuinielaTypeById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateQuinielaType")]
        public async Task<IActionResult> CreateQuinielaType([FromBody] QuinielaTypeDTO QuinielaTypeDTO)
        {
            try
            {
                if (QuinielaTypeDTO == null)
                {
                    _logger.LogError("QuinielaType object sent from client is null.");
                    return BadRequest("QuinielaType object is null");
                }

                var QuinielaTypeEntity = _mapper.Map<QuinielaType>(QuinielaTypeDTO);
                _repository.QuinielaType.Create(QuinielaTypeEntity);
                await _repository.SaveAsync();

                var createdQuinielaType = _mapper.Map<QuinielaTypeDTO>(QuinielaTypeEntity);

                return CreatedAtRoute("GetQuinielaTypeById", new { id = QuinielaTypeEntity.Id }, createdQuinielaType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateQuinielaType action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateBulkQuinielaType")]
        public async Task<IActionResult> CreateBulkQuinielaType(List<QuinielaTypeDTO> QuinielaTypes)
        {
            try
            {
                if (QuinielaTypes == null || !QuinielaTypes.Any())
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                List<QuinielaType> bulkType = _mapper.Map<List<QuinielaType>>(QuinielaTypes);


                await _repository.QuinielaType.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkQuinielaType action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPut("UpdateQuinielaType/{id}")]
        public async Task<IActionResult> UpdateQuinielaType(int id, [FromBody] QuinielaTypeDTO QuinielaTypeDTO)
        {
            try
            {
                if (QuinielaTypeDTO == null)
                {
                    _logger.LogError("QuinielaType object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                var QuinielaTypeEntity = await _repository.QuinielaType.GetByIdAsync(id);
                if (QuinielaTypeEntity == null)
                {
                    _logger.LogError($"QuinielaType with id: {id} hasn't been found in db.");
                    return NotFound($"No QuinielaType with the id: {id}");
                }

                _mapper.Map(QuinielaTypeDTO, QuinielaTypeEntity);
                _repository.QuinielaType.Update(QuinielaTypeEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateQuinielaType action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("DeleteQuinielaType/{id}")]
        public async Task<IActionResult> DeleteQuinielaType(int id)
        {
            try
            {
                var QuinielaType = await _repository.QuinielaType.GetByIdAsync(id);
                if (QuinielaType == null)
                {
                    _logger.LogError($"QuinielaType with id: {id} hasn't been found in db.");
                    return NotFound($"No QuinielaType with the id: {id}");
                }

                _repository.QuinielaType.Delete(QuinielaType);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteQuinielaType action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
