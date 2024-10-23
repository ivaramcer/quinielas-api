using QuinielasApi.Models.DTOs;

namespace QuinielasApi.Utils.NFL.DTO
{
    public class LeagueParametersDto
    {
        public string Season { get; set; } = String.Empty;
    }

    public class LeagueInfoDto
    {
        public LeagueDto League { get; set; } = default!;
        public CountryDto Country { get; set; } = default!;
        public List<SeasonDto> Seasons { get; set; } = default!;
    }

    public class LeagueDto
    {
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public string Logo { get; set; } = String.Empty;
    }

    public class CountryDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Flag { get; set; } = string.Empty;
    }

    public class SeasonDto
    {
        public int Year { get; set; }
        public string Start { get; set; } = string.Empty;
        public string End { get; set; } = string.Empty;
        public bool Current { get; set; }
        public CoverageDto Coverage { get; set; } = default!;
    }

    public class CoverageDto
    {
        public GameCoverageDto Games { get; set; } = default!;
        public SeasonStatisticsDto Statistics { get; set; } = default!;
        public bool Players { get; set; }
        public bool Injuries { get; set; }
        public bool Standings { get; set; }
    }

    public class GameCoverageDto
    {
        public bool Events { get; set; }
        public StatisticsDetailsDto Statisitcs { get; set; } = default!;
    }

    public class StatisticsDetailsDto
    {
        public bool Teams { get; set; }
        public bool Players { get; set; }
    }

    public class SeasonStatisticsDto
    {
        public PlayerStatisticsDto Season { get; set; } = default!;
    }

    public class PlayerStatisticsDto
    {
        public bool Players { get; set; }
    }

}
