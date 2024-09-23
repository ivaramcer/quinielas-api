using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using QuinielasApi.DBContext;
using QuinielasApi.IRepository.Configuration;
using QuinielasApi.JWTConfiguration;
using QuinielasApi.Models.DTOs;
using QuinielasApi.Models.Entities;

namespace QuinielasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SportsController : ControllerBase
    {

        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<SportsController> _logger;


        public SportsController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<SportsController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<SportDTO>>> GetAllSports()
        {
            try
            {
                var sports = await _repository.Sport.GetAllSportsAsync();
                if (sports == null || !sports.Any())
                {
                    return NotFound("No sports found.");
                }

                var sportsDTO = _mapper.Map<IEnumerable<SportDTO>>(sports);
                return Ok(sportsDTO);
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging
                 _logger.LogError(ex, "Error fetching sports");
                return StatusCode(500, "An error occurred while fetching sports.");
            }
        }


    }
}
