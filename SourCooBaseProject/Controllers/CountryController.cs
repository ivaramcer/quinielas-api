using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuinielasApi.IRepository.Configuration;
using QuinielasApi.JWTConfiguration;
using QuinielasApi.Models.DTOs;
using QuinielasApi.Models.Entities;
using QuinielasApi.Utils.NFL.SoccerDto;
using QuinielasApi.Utils.Soccer;

namespace QuinielasApi.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CountryController> _logger;

        public CountryController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<CountryController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpGet("GetAll/{sportId}")]
        public async Task<IActionResult> GetAll(int sportId)
        {
            try
            {
                var countries = await _repository.Country.GetAllAsync(sportId);
                var countriesDTO = _mapper.Map<IEnumerable<CountryDTO>>(countries);
                return Ok(countriesDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllCountry action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            try
            {
                var Country = await _repository.Country.GetByIdAsync(id);
                if (Country == null)
                {
                    _logger.LogError($"Country with id: {id} hasn't been found in db.");
                    return NotFound($"No Country with the id: {id}");
                }

                var CountryDTO = _mapper.Map<CountryDTO>(Country);
                return Ok(CountryDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCountryById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateCountry([FromBody] CountryInsertDTO CountryDTO)
        {
            try
            {
                if (CountryDTO == null)
                {
                    _logger.LogError("Country object sent from client is null.");
                    return BadRequest("Country object is null");
                }

                var CountryEntity = _mapper.Map<Country>(CountryDTO);
                _repository.Country.Create(CountryEntity);
                await _repository.SaveAsync();

                var createdCountry = _mapper.Map<CountryDTO>(CountryEntity);

                return CreatedAtRoute("GetCountryById", new { id = CountryEntity.Id }, createdCountry);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateCountry action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulkCountry(List<CountryInsertDTO> Countrys)
        {
            try
            {
                if (Countrys == null || !Countrys.Any())
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }

                List<Country> bulkType = _mapper.Map<List<Country>>(Countrys);


                await _repository.Country.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkCountry action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] CountryDTO CountryDTO)
        {
            try
            {
                if (CountryDTO == null)
                {
                    _logger.LogError("Country object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                var CountryEntity = await _repository.Country.GetByIdAsync(id);
                if (CountryEntity == null)
                {
                    _logger.LogError($"Country with id: {id} hasn't been found in db.");
                    return NotFound($"No Country with the id: {id}");
                }

                _mapper.Map(CountryDTO, CountryEntity);
                _repository.Country.Update(CountryEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateCountry action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            try
            {
                var Country = await _repository.Country.GetByIdAsync(id);
                if (Country == null)
                {
                    _logger.LogError($"Country with id: {id} hasn't been found in db.");
                    return NotFound($"No Country with the id: {id}");
                }

                _repository.Country.Delete(Country);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteCountry action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpPost("ImportBulk/{sportId}")]
        public async Task<IActionResult> CreateBulkCountry(int sportId)
        {
            try
            {
                List<GetCountriesDTO>? countriesFromAPI = await APIClientSoccer.GetCountries();
                if (!countriesFromAPI.Any() && sportId == 1)
                {
                    _logger.LogError($"API it's not working");
                    return StatusCode(500, "API it's not working ");
                }
                List<Country> bulkCountries = new List<Country>();

                foreach (var country in countriesFromAPI)
                {
                    Country newCountry = _mapper.Map<Country>(country);
                    if (string.IsNullOrEmpty(country.Code))
                    {
                        newCountry.Code = newCountry.Name;
                        newCountry.Flag = newCountry.Name;
                    }
                    newCountry.SportId = sportId;
                    newCountry.IsActive = false;
                    bulkCountries.Add(newCountry);
                }

                await _repository.Country.BulkInsert(bulkCountries);
                await _repository.SaveAsync();

                var countryDTO = _mapper.Map<List<CountryDTO>>(bulkCountries);
                return Ok(countryDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkCountry action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }

    }
}
