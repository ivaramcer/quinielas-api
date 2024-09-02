using QuinielasApi.Models.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.JWTConfiguration;
using QuinielasApi.Models.Entities;
using QuinielasApi.DBContext;

namespace QuinielasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly JWTUtils _jwtUtils;
        public UserController(DatabaseContext databaseContext, JWTUtils jwtUtils)
        {
            _databaseContext = databaseContext;
            _jwtUtils = jwtUtils;
        }

        [HttpGet]
        [Route("AllUsers")]
        public async Task<IActionResult> AllUsers()
        {
            var users = await _databaseContext.Users.ToListAsync();

            return StatusCode(StatusCodes.Status200OK, users);

        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _databaseContext.Users.FindAsync(id);

            if ( user == null)
            {
                return NotFound();

            }

            return user;

        }

        [HttpPost]
        [Route("CreateUser/{id}")]
        public async Task<ActionResult<User>> CreateUser(int id)
        {
            var user = await _databaseContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();

            }

            return user;

        }


        [HttpPut]
        [Route("EditUser/{id}")]
        public async Task<ActionResult<User>> EditUser(int id)
        {
            var user = await _databaseContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();

            }

            return user;

        }


    }
}
