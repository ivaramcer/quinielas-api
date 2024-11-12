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
    public class UserPicksController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserPicksController> _logger;

        public UserPicksController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<UserPicksController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var UserPickss = await _repository.UserPicks.GetAllAsync();
                var UserPicksDTOs = _mapper.Map<IEnumerable<UserPicksDTO>>(UserPickss);
                return Ok(UserPicksDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUserPicks action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetAllByUserQuiniela/{userId}/{quinielaId}")]
        public async Task<IActionResult> GetAllByUserQuiniela(int userId, int quinielaId)
        {
            try
            {
                var UserPickss = await _repository.UserPicks.GetAllByQuinielaUserIdAsync(userId, quinielaId);
                var UserPicksDTOs = _mapper.Map<IEnumerable<UserPicksDTO>>(UserPickss);
                return Ok(UserPicksDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUserPicks action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetNext/{userId}/{pagination}/{sportId}")]
        public async Task<IActionResult> GetNext(int userId, int pagination, int sportId)
        {
            try
            {
                User? existsUser = await _repository.User.GetUserByIdAsync(userId);
                if (existsUser == null)
                {
                    _logger.LogError($"There is not an user with the id: {userId}");
                    return NotFound($"There is not an user with the id: {userId}");
                }
                var picks = await _repository.UserPicks.GetAllByUserIdAsync(userId, sportId);
                DateTime time = DateTime.Now;


                if (pagination != 0)
                {
                    picks = picks
                                .Where(g => g.Deadline.Day >= time.Day && g.Deadline.Month == time.Month && g.Deadline.Year == time.Year)
                                .Take(5)
                                .ToList();
                }
                var picksDTO = _mapper.Map<IEnumerable<UserPicksDTO>>(picks);
                return Ok(picksDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUserPicks action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var UserPicks = await _repository.UserPicks.GetByIdAsync(id);
                if (UserPicks == null)
                {
                    _logger.LogError($"UserPicks with id: {id} hasn't been found in db.");
                    return NotFound($"No UserPicks with the id: {id}");
                }

                var UserPicksDTO = _mapper.Map<UserPicksDTO>(UserPicks);
                return Ok(UserPicksDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserPicksById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("UpdateBulk/{userId}/{quinielaId}")]
        public async Task<IActionResult> UpdateBulk(List<UserPicksInsertBulkDTO> picksDTO, int userId, int quinielaId)
        {
            try
            {
                if (picksDTO == null || picksDTO.Count == 0)
                {
                    _logger.LogError("UserPicks object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                List<UserPicks> picks = await _repository.UserPicks.MakePicks(userId, quinielaId);

                foreach (var item in picks)
                {
                    var matchingDTO = picksDTO.FirstOrDefault(dto => dto.Id == item.Id);

                    if (matchingDTO != null)
                    {
                        item.IsRegistered = true;
                        item.TeamId = matchingDTO.TeamId;
                    }
                    else
                    {
                        continue;
                    }
                    _repository.UserPicks.Update(item);
                }

                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateUserPicks action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateUserPicks([FromBody] UserPicksInsertDTO UserPicksDTO)
        {
            try
            {
                if (UserPicksDTO == null)
                {
                    _logger.LogError("UserPicks object sent from client is null.");
                    return BadRequest("UserPicks object is null");
                }

                var UserPicksEntity = _mapper.Map<UserPicks>(UserPicksDTO);
                _repository.UserPicks.Create(UserPicksEntity);
                await _repository.SaveAsync();

                var createdUserPicks = _mapper.Map<UserPicksDTO>(UserPicksEntity);

                return CreatedAtRoute("GetUserPicksById", new { id = UserPicksEntity.Id }, createdUserPicks);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUserPicks action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulkUserPicks(List<UserPicksInsertDTO> UserPickss)
        {
            try
            {
                if (UserPickss == null || !UserPickss.Any())
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                List<UserPicks> bulkType = _mapper.Map<List<UserPicks>>(UserPickss);


                await _repository.UserPicks.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkUserPicks action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUserPicks(int id, [FromBody] UserPicksDTO UserPicksDTO)
        {
            try
            {
                if (UserPicksDTO == null)
                {
                    _logger.LogError("UserPicks object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                var UserPicksEntity = await _repository.UserPicks.GetByIdAsync(id);
                if (UserPicksEntity == null)
                {
                    _logger.LogError($"UserPicks with id: {id} hasn't been found in db.");
                    return NotFound($"No UserPicks with the id: {id}");
                }

                _mapper.Map(UserPicksDTO, UserPicksEntity);
                _repository.UserPicks.Update(UserPicksEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateUserPicks action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUserPicks(int id)
        {
            try
            {
                var UserPicks = await _repository.UserPicks.GetByIdAsync(id);
                if (UserPicks == null)
                {
                    _logger.LogError($"UserPicks with id: {id} hasn't been found in db.");
                    return NotFound($"No UserPicks with the id: {id}");
                }

                _repository.UserPicks.Delete(UserPicks);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteUserPicks action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
