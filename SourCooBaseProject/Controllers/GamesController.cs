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
    public class GameController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GameController> _logger;

        public GameController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<GameController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllGame()
        {
            try
            {
                var Games = await _repository.Game.GetAllAsync();
                var GameDTOs = _mapper.Map<IEnumerable<GameDTO>>(Games);
                return Ok(GameDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetGameById(int id)
        {
            try
            {
                var Game = await _repository.Game.GetByIdAsync(id);
                if (Game == null)
                {
                    _logger.LogError($"Game with id: {id} hasn't been found in db.");
                    return NotFound($"No Game with the id: {id}");
                }

                var GameDTO = _mapper.Map<GameDTO>(Game);
                return Ok(GameDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetGameById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateGame([FromBody] GameInsertDTO GameDTO)
        {
            try
            {
                if (GameDTO == null)
                {
                    _logger.LogError("Game object sent from client is null.");
                    return BadRequest("Game object is null");
                }

                var GameEntity = _mapper.Map<Game>(GameDTO);
                _repository.Game.Create(GameEntity);
                await _repository.SaveAsync();

                var createdGame = _mapper.Map<GameDTO>(GameEntity);

                return CreatedAtRoute("GetGameById", new { id = GameEntity.Id }, createdGame);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulkGame(List<GameInsertDTO> Games)
        {
            try
            {
                if (Games == null || !Games.Any())
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                List<Game> bulkType = _mapper.Map<List<Game>>(Games);


                await _repository.Game.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkGame action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateGame(int id, [FromBody] GameDTO GameDTO)
        {
            try
            {
                if (GameDTO == null)
                {
                    _logger.LogError("Game object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                var GameEntity = await _repository.Game.GetByIdAsync(id);
                if (GameEntity == null)
                {
                    _logger.LogError($"Game with id: {id} hasn't been found in db.");
                    return NotFound($"No Game with the id: {id}");
                }

                _mapper.Map(GameDTO, GameEntity);
                _repository.Game.Update(GameEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            try
            {
                var Game = await _repository.Game.GetByIdAsync(id);
                if (Game == null)
                {
                    _logger.LogError($"Game with id: {id} hasn't been found in db.");
                    return NotFound($"No Game with the id: {id}");
                }

                _repository.Game.Delete(Game);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost("GetBulk")]
        public async Task<IActionResult> GetBulk(List<GameInsertDTO> Games)
        {
            try
            {
                if (Games == null || !Games.Any())
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                List<Game> bulkType = _mapper.Map<List<Game>>(Games);


                await _repository.Game.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkGame action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }
    }
}
