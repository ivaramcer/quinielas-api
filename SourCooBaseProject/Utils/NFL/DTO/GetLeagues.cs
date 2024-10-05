using QuinielasApi.Models.DTOs;

namespace QuinielasApi.Utils.NFL.DTO
{
    public class LeagueParametersDto
    {
        public string Season { get; set; }
    }

    public class LeagueInfoDto
    {
        public LeagueDto League { get; set; }
        public CountryDto Country { get; set; }
        public List<SeasonDto> Seasons { get; set; }
    }

    public class LeagueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
    }

    public class CountryDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
    }

    public class SeasonDto
    {
        public int Year { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public bool Current { get; set; }
        public CoverageDto Coverage { get; set; }
    }

    public class CoverageDto
    {
        public GameCoverageDto Games { get; set; }
        public SeasonStatisticsDto Statistics { get; set; }
        public bool Players { get; set; }
        public bool Injuries { get; set; }
        public bool Standings { get; set; }
    }

    public class GameCoverageDto
    {
        public bool Events { get; set; }
        public StatisticsDetailsDto Statisitcs { get; set; }
    }

    public class StatisticsDetailsDto
    {
        public bool Teams { get; set; }
        public bool Players { get; set; }
    }

    public class SeasonStatisticsDto
    {
        public PlayerStatisticsDto Season { get; set; }
    }

    public class PlayerStatisticsDto
    {
        public bool Players { get; set; }
    }

}
