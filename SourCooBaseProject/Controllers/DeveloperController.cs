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
    public class DeveloperController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeveloperController> _logger;

        public DeveloperController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<DeveloperController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpGet("FixPicks")]
        public async Task<IActionResult> FixPicks()
        {
            try
            {
                var picks = await _repository.UserPicks.GetAllAsync();
                foreach (var item in picks)
                {
                    item.Deadline = item.QuinielaGame.Game.Schedule;

                }

                await _repository.UserPicks.BulkUpdate(picks);
                await _repository.SaveAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllDeveloper action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

       
    }
}
