using QuinielasApi.Models.DTOs;
using QuinielasApi.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using QuinielasApi.IRepository.Configuration;
using QuinielasApi.JWTConfiguration;
using QuinielasApi.Models.DTOs.Access;
using AutoMapper;

namespace QuinielasApi.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public AccessController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;


        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserForCreation user)
        {
            User? previousUser = await _repository.User.GetUserByEmailAsync(user.Email);
            if ( previousUser != null)
            {
                return StatusCode(StatusCodes.Status200OK, new {isSuccess = false, response = "There is another user with this email"});
            }

            Person person = new Person();
            person.Gender = user.Gender;
            person.DateOfBirthday = DateTime.SpecifyKind(user.DateOfBirthday, DateTimeKind.Utc); 
            person.Name = user.Name;
            person.Lastname = user.Lastname;

            _repository.Person.Create(person);
            await _repository.SaveAsync();


            User newUser = new User();
            newUser.Email = user.Email;
            newUser.Password = _jwtUtils.secureSHA256(user.Password);
            newUser.PersonId = person.Id;
            newUser.RoleId = 1;
            
            _repository.User.CreateUser(newUser);
            await _repository.SaveAsync();
            
            Wallet wallet = new Wallet();
            wallet.Balance = 1000;
            wallet.UserId = newUser.Id;
            _repository.Wallet.Create(wallet);
            await _repository.SaveAsync();

            if (newUser.Id != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, response = "User registered successfully" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, response = "An error occurs during the registration" });

        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO login) 
        {
            User? previousUser = await _repository.User.GetUserByEmailAsync(login.Email);

            if (previousUser == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, response = "There is not an user with this email" });

            string passwordHash = _jwtUtils.secureSHA256(login.Password);

            User? successUser = await _repository.User.LogInUser(login.Email, passwordHash);
            if (successUser == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, response = "The password it's incorrect" });

            Person? person = await _repository.Person.GetByIdAsync(successUser.PersonId);

            PersonNameDTO successPerson = _mapper.Map<PersonNameDTO>(person);

            return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, response = _jwtUtils.generateToken(successUser), person = successPerson, userId = successUser.Id });

        }

        [HttpGet]
        [Route("ValidateToken")]
        public  IActionResult ValidateToken(string token)
        {
            bool response = _jwtUtils.validateToken(token);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = response });

        }

    }
}
