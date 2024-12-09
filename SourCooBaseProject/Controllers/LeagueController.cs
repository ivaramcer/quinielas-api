using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuinielasApi.IRepository.Configuration;
using QuinielasApi.JWTConfiguration;
using QuinielasApi.Models.DTOs;
using QuinielasApi.Models.Entities;
using QuinielasApi.Utils;
using QuinielasApi.Utils.NFL;
using QuinielasApi.Utils.NFL.DTO;
using QuinielasApi.Utils.NFL.SoccerDto;
using QuinielasApi.Utils.Soccer;

namespace QuinielasApi.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<LeagueController> _logger;

        public LeagueController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper, ILogger<LeagueController> logger)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpGet("GetAll/{sportId}")]
        public async Task<IActionResult> GetAllLeague(int sportId, bool? isActive, int? countryId)
        {
            try
            {
                var Leagues = await _repository.League.GetAllBySportAsync(sportId);

                if (countryId.HasValue)
                {
                    Leagues = Leagues.Where(l => l.CountryId == countryId.Value).ToList();
                }

                if (isActive.HasValue)
                {
                    Leagues = Leagues.Where(l => l.IsActive == isActive.Value).ToList();
                }



                var LeagueDTOs = _mapper.Map<IEnumerable<LeagueDTO>>(Leagues);
                return Ok(LeagueDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllLeague action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetAllQuinielas/{sportId}/{pagination}")]
        public async Task<IActionResult> GetAllQuinielas(int sportId, int pagination, int? leagueId)
        {
            try
            {
                int pageSize = 5; 
                List<League> leagues = await _repository.League.GetAllQuinielasAsync(sportId);

                if (leagueId.HasValue)
                {
                    leagues = leagues.Where(l => l.Id == leagueId).ToList();
                }

                foreach (var league in leagues)
                {
                    league.Quinielas = league.Quinielas.Where(q => q.StatusId == 1).ToList();
                    foreach (var element in league.Quinielas)
                    {
                        element.QuinielaPickDuration.QuinielaDuration.QuinielaPickDurations = null;
                        element.QuinielaPickDuration.QuinielaDuration.QuinielaType.QuinielaDurations = null;
                    }
                }

                leagues = leagues
                    .Skip(pageSize * (pagination - 1))
                    .Take(pageSize)
                    .ToList();
                IEnumerable<LeagueQuinielasDTO> LeagueDTOs = _mapper.Map<IEnumerable<LeagueQuinielasDTO>>(leagues);
                return Ok(LeagueDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllLeague action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetLeagueById(int id)
        {
            try
            {
                var League = await _repository.League.GetByIdAsync(id);
                if (League == null)
                {
                    _logger.LogError($"League with id: {id} hasn't been found in db.");
                    return NotFound($"No League with the id: {id}");
                }

                var LeagueDTO = _mapper.Map<LeagueDTO>(League);
                return Ok(LeagueDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetLeagueById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

      
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateLeague(int id, [FromBody] LeagueDTO LeagueDTO)
        {
            try
            {
                if (LeagueDTO == null)
                {
                    _logger.LogError("League object is null or mismatching ids.");
                    return BadRequest("Invalid model object or mismatching ids");
                }

                var LeagueEntity = await _repository.League.GetByIdAsync(id);
                if (LeagueEntity == null)
                {
                    _logger.LogError($"League with id: {id} hasn't been found in db.");
                    return NotFound($"No League with the id: {id}");
                }

                _mapper.Map(LeagueDTO, LeagueEntity);
                _repository.League.Update(LeagueEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateLeague action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteLeague(int id)
        {
            try
            {
                var League = await _repository.League.GetByIdAsync(id);
                if (League == null)
                {
                    _logger.LogError($"League with id: {id} hasn't been found in db.");
                    return NotFound($"No League with the id: {id}");
                }

                _repository.League.Delete(League);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteLeague action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpPost("GetLeaguesNFL")]
        public async Task<IActionResult> GetLeaguesNFL()
        {
            try
            {
                List<LeagueInfoDto>? TeamsFromAPI = await APIClientNFL.GetLeagues();

                List<League> bulkType = new List<League>();
                List<League> ourLeagues = await _repository.League.GetAllBySportAsync(UtilsVariables.SportNFLId);

                foreach (var item in TeamsFromAPI!)
                {
                    League? previousLeague = ourLeagues.Find(t => t.ExternalId == item.League.Id);
                    if (previousLeague != null)
                    {
                        continue;
                    }

                    DateTime now = DateTime.Now.ToUniversalTime();
                    if (item?.Seasons != null && item.Seasons.Count > 0)
                    {
                        now = DateTime.Parse(item.Seasons[0].Start).ToUniversalTime();
                    }
                    
                    DateTime end = DateTime.Now.ToUniversalTime();
                    if (item?.Seasons != null && item.Seasons.Count > 0)
                    {
                        end = DateTime.Parse(item.Seasons[0].End).ToUniversalTime();
                    }
                    

                    League newLeague = new League
                    {
                        ExternalId = item.League.Id,
                        Name = item.League.Name!,
                        ImageURL = string.IsNullOrEmpty(item.League.Logo) ? "" : item.League.Logo,
                        IsActive = true,
                        Type = "",
                        StartDate = now,
                        EndDate = end,
                        SportId = 2,
                        CountryId = 168

                    };

                    _repository.League.Create(newLeague);
                    bulkType.Add(newLeague);
                }

                if (bulkType.Any())
                {
                    await _repository.SaveAsync();
                }


                return Ok(bulkType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkTeam action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }
        
        
        //SOCCER
        [HttpPost("GetLeaguesSoccer/{country}")]
        public async Task<IActionResult> GetLeaguesSoccer(string country)
        {
            try
            {
                Country? countryEntity = await _repository.Country.GetByNameAsync(country);
                if (countryEntity == null)
                {
                    _logger.LogError($"Country with id: {country} has not been found in db.");
                    return NotFound($"Country with id: {country} has not been found in db.");
                }
                List<LeagueInfoSoccerDto>? TeamsFromAPI = await APIClientSoccer.GetLeagues(country);

                List<League> bulkType = new List<League>();
                List<League> ourLeagues = await _repository.League.GetAllBySportAsync(UtilsVariables.SportSoccerId);

                foreach (var item in TeamsFromAPI!)
                {
                    League? previousLeague = ourLeagues.Find(t => t.ExternalId == item.League.Id);
                    if (previousLeague != null)
                    {
                        continue;
                    }
                    
                    DateTime now = DateTime.Now.ToUniversalTime();
                    if (item?.Seasons != null && item.Seasons.Count > 0)
                    {
                        now = DateTime.Parse(item.Seasons[0].Start).ToUniversalTime();
                    }
                    
                    DateTime end = DateTime.Now.ToUniversalTime();
                    if (item?.Seasons != null && item.Seasons.Count > 0)
                    {
                        end = DateTime.Parse(item.Seasons[0].End).ToUniversalTime();
                    }

                    League newLeague = new League
                    {
                        ExternalId = item.League.Id,
                        Name = item.League.Name!,
                        ImageURL = string.IsNullOrEmpty(item.League.Logo) ? "" : item.League.Logo,
                        IsActive = true,
                        Type = item.League.Type,
                        StartDate = now,
                        EndDate = end,
                        SportId = 1,
                        CountryId = countryEntity.Id
                    };


                    _repository.League.Create(newLeague);
                    bulkType.Add(newLeague);
                }

                if (bulkType.Any())
                {
                    await _repository.SaveAsync();
                }


                return Ok(bulkType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBulkTeam action: {ex.Message}");
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPut("SelectActivesLeagues/{sportId}")]
        public async Task<IActionResult> SelectActivesLeagues(int sportId, List<int> activeLeagues)
        {
            try
            {
                if (activeLeagues == null || activeLeagues.Count == 0)
                {
                    _logger.LogError("The server didn't receive any object from the client");
                    return BadRequest("No countries were provided.");
                }

                List<League> leagues = await _repository.League.GetAllBySportAsync(sportId);
                HashSet<int> activeLeaguesSet = new HashSet<int>(activeLeagues);

                foreach (var league in leagues)
                {
                    if (activeLeaguesSet.Contains(league.Id) && !league.IsActive)
                    {
                        league.IsActive = true;
                    }
                    else if (!activeLeaguesSet.Contains(league.Id) && league.IsActive)
                    {
                        league.IsActive = false;
                    }
                }

                await _repository.League.BulkUpdate(leagues);
                await _repository.SaveAsync();

                return Ok(leagues);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside SelectActivesLeagues action: {ex.Message}", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

    }
}
