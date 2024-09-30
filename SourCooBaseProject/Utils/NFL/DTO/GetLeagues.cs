using QuinielasApi.Models.DTOs;

namespace QuinielasApi.Utils.NFL.DTO
{
    public class LeagueDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Logo { get; set; } = default!;
        public CountryDTO Country { get; set; } = default!;
        public List<SeasonDTO> Seasons { get; set; } = default!;
    }

    public class CountryDTO
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Flag { get; set; } = default!;
    }

    public class SeasonDTO
    {
        public int Year { get; set; }
        public string Start { get; set; } = default!;
        public string End { get; set; } = default!;
        public bool Current { get; set; }
        public CoverageDTO Coverage { get; set; } = default!;
    }

    public class CoverageDTO
    {
        public GameCoverageDTO Games { get; set; } = default!;
        public StatisticCoverageDTO Statistics { get; set; } = default!;
        public bool Players { get; set; }
        public bool Injuries { get; set; }
        public bool Standings { get; set; }
    }

    public class GameCoverageDTO
    {
        public bool Events { get; set; }
        public StatisticDetailDTO Statistics { get; set; } = default!;
    }

    public class StatisticCoverageDTO
    {
        public SeasonStatisticDTO Season { get; set; } = default!;
    }

    public class StatisticDetailDTO
    {
        public bool Teams { get; set; }
        public bool Players { get; set; }
    }

    public class SeasonStatisticDTO
    {
        public bool Players { get; set; }
    }
}
