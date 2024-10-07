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
    public class PreferenceController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<PreferenceController> _logger;

        public PreferenceController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<PreferenceController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }


        [HttpGet("GetAll/{sportId}/{userId}")]
        public async Task<IActionResult> GetAllPreference(int sportId, int userId)
        {
            try
            {
                var Preferences = await _repository.Preference.GetAllAsync(sportId, userId);
                if (sportId == NFLTeamController.SoccerId)
                {
                    var PreferenceDTOs = _mapper.Map<IEnumerable<PreferenceSoccerDTO>>(Preferences);
                    return Ok(PreferenceDTOs);
                }
                else
                {
                    var PreferenceDTOs = _mapper.Map<IEnumerable<PreferenceNFLDTO>>(Preferences);
                    return Ok(PreferenceDTOs);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPreference action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetPreferenceById(int id)
        {
            try
            {
                var Preference = await _repository.Preference.GetByIdAsync(id);
                if (Preference == null)
                {
                    _logger.LogError($"Preference with id: {id} hasn't been found in db.");
                    return NotFound($"No Preference with the id: {id}");
                }

                if (Preference.SportId == NFLTeamController.SoccerId)
                {
                    var PreferenceDTO = _mapper.Map<PreferenceSoccerDTO>(Preference);
                    return Ok(PreferenceDTO);
                }
                else
                {
                    var PreferenceDTO = _mapper.Map<PreferenceNFLDTO>(Preference);
                    return Ok(PreferenceDTO);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPreferenceById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulkPreference(List<PreferenceNFLInsertDTO>? NFLPreferences, List<PreferenceSoccerInsertDTO>? SoccerPreferences)
        {
            try
            {
                if ((NFLPreferences == null || !NFLPreferences.Any()) && (SoccerPreferences == null || !SoccerPreferences.Any()))
                {
                    _logger.LogError($"The server doesn't receive any object from the client");
                    return StatusCode(500, "The server doesn't receive any object from the client");
                }
                List<Preference> bulkType = new List<Preference>();
                if (!(NFLPreferences == null || !NFLPreferences.Any()))
                {
                    bulkType = _mapper.Map<List<Preference>>(NFLPreferences);

                }
                if (!(SoccerPreferences == null || !SoccerPreferences.Any()))
                {
                    bulkType = _mapper.Map<List<Preference>>(SoccerPreferences);
                }

                await _repository.Preference.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkPreference action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }



        [HttpDelete("Delete/{sportId}/{userId}")]
        public async Task<IActionResult> DeletePreference(List<int> ids, int sportId, int userId)
        {
            try
            {

                List<Preference> preferences = await _repository.Preference.GetAllAsync(sportId, userId);

                List<Preference> preferencesToDelete = preferences
                    .Where(p => !ids.Contains(p.Id))
                    .ToList();

                foreach (var item in preferencesToDelete)
                {
                    _repository.Preference.Delete(item);
                }

                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeletePreference action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
