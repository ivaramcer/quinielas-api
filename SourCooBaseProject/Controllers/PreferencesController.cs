﻿using AutoMapper;
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
                List<int> preferencesIds =  Preferences.Select(p=>  p.TeamId).ToList();

                return Ok(preferencesIds);
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


                    var PreferenceDTO = _mapper.Map<PreferenceDTO>(Preference);
                    return Ok(PreferenceDTO);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPreferenceById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulkPreference([FromBody] PreferenceBulkDTO bulkPreferences)
        {
            try
            {
                if (bulkPreferences == null )
                {
                    _logger.LogError("The server didn't receive any object from the client");
                    return StatusCode(500, "The server didn't receive any object from the client");
                }

                List<Preference> userPreferences = await _repository.Preference.GetAllAsync(bulkPreferences.SportId, bulkPreferences.UserId);
                List<int> preferencesIds = bulkPreferences.TeamsId;
                List<int> userPreferenceIds = new List<int>();

                userPreferenceIds = userPreferences
                    .Select(up => up.TeamId)    
                    .ToList();

                
                 

                List<int> idsToDelete = userPreferenceIds.Except(preferencesIds).ToList();
                List<Preference> preferencesToDelete = new List<Preference>();  
                preferencesToDelete = userPreferences
                    .Where(up =>   idsToDelete.Contains(up.TeamId))
                    .ToList();

                foreach (var pref in preferencesToDelete)
                {
                    _repository.Preference.Delete(pref);
                }

                await _repository.SaveAsync();
                
                
                List<Preference> bulkType = new List<Preference>();

                foreach (var item in preferencesIds)
                {
                    Preference newPreference = new Preference();
                    newPreference.SportId = bulkPreferences.SportId;
                    newPreference.UserId = bulkPreferences.UserId;
                    newPreference.TeamId = item;
                    
                    bulkType.Add(newPreference);
                }


                await _repository.Preference.BulkInsert(bulkType);
                await _repository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkPreference action: {ex.Message}");
                return StatusCode(500, "Internal server error");
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
