using QuinielasApi.Models.DTOs;

namespace QuinielasApi.Utils.NFL.DTO
{
    public class LeagueDto
    {
        public LeagueInfoDto League { get; set; } = default!;
        public CountryDto Country { get; set; } = default!;
        public List<SeasonDto> Seasons { get; set; } = default!;
    }

    public class LeagueInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Logo { get; set; } = default!;
    }

    public class CountryDto
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Flag { get; set; } = default!;
    }

    public class SeasonDto
    {
        public int Year { get; set; }
        public string Start { get; set; } = default!;
        public string End { get; set; } = default!;
        public bool Current { get; set; }
        public CoverageDto Coverage { get; set; } = default!;
    }

    public class CoverageDto
    {
        public GamesCoverageDto Games { get; set; } = default!;
        public StatisticsCoverageDto Statistics { get; set; } = default!;
        public bool Players { get; set; }
        public bool Injuries { get; set; }
        public bool Standings { get; set; }
    }

    public class GamesCoverageDto
    {
        public bool Events { get; set; } = default!;
        public GameStatisticsDto Statistics { get; set; } = default!;
    }

    public class GameStatisticsDto
    {
        public bool Teams { get; set; }
        public bool Players { get; set; }
    }

    public class StatisticsCoverageDto
    {
        public SeasonStatisticsDto Season { get; set; } = default!;
    }

    public class SeasonStatisticsDto
    {
        public bool Players { get; set; }
    }

}
