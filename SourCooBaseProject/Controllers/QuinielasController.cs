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
    public class QuinielasController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<QuinielasController> _logger;

        public QuinielasController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<QuinielasController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpPost]
        [Route("CreateQuiniela")]
        public async Task<IActionResult> CreateQuiniela(QuinielaInsertDTO quiniela)
        {
            if (quiniela != null)
            {
                _logger.LogError("Quiniela object is null.");
                return BadRequest("Invalid model object");
            }

            Quiniela newQuiniela = _mapper.Map<Quiniela>(quiniela);

            _repository.Quiniela.CreateQuiniela(newQuiniela);
            await _repository.SaveAsync();

            _logger.LogInformation($"Quiniela has been created with id:{newQuiniela.Id}");



            if (newQuiniela.Id != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, response = "User registered successfully" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, response = "An error occurs during the registration" });

        }
    }
}
