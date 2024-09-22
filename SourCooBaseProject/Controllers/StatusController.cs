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
    public class StatusController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<StatusController> _logger;

        public StatusController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<StatusController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }


        [HttpGet("GetAllStatus")]
        public async Task<IActionResult> GetAllStatus()
        {
            try
            {
                var status = await _repository.Status.GetAllAsync();
                var StatusDTOs = _mapper.Map<IEnumerable<StatusDTO>>(status);
                return Ok(StatusDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllStatus action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetStatusById/{id}")]
        public async Task<IActionResult> GetStatusById(int id)
        {
            try
            {
                var Status = await _repository.Status.GetByIdAsync(id);
                if (Status == null)
                {
                    _logger.LogError($"Status with id: {id} hasn't been found in db.");
                    return NotFound($"No Status with the id: {id}");
                }

                var StatusDTO = _mapper.Map<StatusDTO>(Status);
                return Ok(StatusDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetStatusById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateStatus")]
        public async Task<IActionResult> CreateStatus([FromBody] StatusInsertDTO StatusDTO)
        {
            try
            {
                if (StatusDTO == null)
                {
                    _logger.LogError("Status object sent from client is null.");
                    return BadRequest("Status object is null");
                }

                var StatusEntity = _mapper.Map<Status>(StatusDTO);
                _repository.Status.Create(StatusEntity);
                await _repository.SaveAsync();

                var createdStatus = _mapper.Map<StatusDTO>(StatusEntity);

                return CreatedAtRoute("GetStatusById", new { id = StatusEntity.Id }, createdStatus);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateStatus action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateBulkStatus")]
        public async Task<IActionResult> CreateBulkStatus(List<StatusInsertDTO> status)
        {
            try
            {
                if (status == null || !status.Any())
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                List<Status> bulkType = _mapper.Map<List<Status>>(status);


                await _repository.Status.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkStatus action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPut("UpdateStatus/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] StatusDTO StatusDTO)
        {
            try
            {
                if (StatusDTO == null)
                {
                    _logger.LogError("Status object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                var StatusEntity = await _repository.Status.GetByIdAsync(id);
                if (StatusEntity == null)
                {
                    _logger.LogError($"Status with id: {id} hasn't been found in db.");
                    return NotFound($"No Status with the id: {id}");
                }

                _mapper.Map(StatusDTO, StatusEntity);
                _repository.Status.Update(StatusEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateStatus action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("DeleteStatus/{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            try
            {
                var Status = await _repository.Status.GetByIdAsync(id);
                if (Status == null)
                {
                    _logger.LogError($"Status with id: {id} hasn't been found in db.");
                    return NotFound($"No Status with the id: {id}");
                }

                _repository.Status.Delete(Status);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteStatus action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
