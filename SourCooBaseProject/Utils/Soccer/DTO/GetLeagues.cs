
namespace QuinielasApi.Utils.NFL.SoccerDto
{
    public class LeagueParametersSoccerDto
    {
        public string Season { get; set; } = string.Empty;
    }

    public class LeagueInfoSoccerDto
    {
        public LeagueSoccerDto League { get; set; } = default!;
        public CountrySoccerDto Country { get; set; } = default!;
        public List<SeasonSoccerDto> Seasons { get; set; } = default!;
    }

    public class LeagueSoccerDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
    }

    public class CountrySoccerDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Flag { get; set; } = string.Empty;
    }

    public class SeasonSoccerDto
    {
        public int Year { get; set; }
        public string Start { get; set; } = string.Empty;
        public string End { get; set; } = string.Empty;
        public bool Current { get; set; }
        public CoverageSoccerDto Coverage { get; set; }  = default!;
    }

    public class CoverageSoccerDto
    {
        public GameCoverageSoccerDto Games { get; set; }  = default!;
        public SeasonStatisticsSoccerDto Statistics { get; set; }  = default!;
        public bool Players { get; set; }
        public bool Injuries { get; set; }
        public bool Standings { get; set; }
    }

    public class GameCoverageSoccerDto
    {
        public bool Events { get; set; }
        public StatisticsDetailsSoccerDto Statisitcs { get; set; }= default!;
    }

    public class StatisticsDetailsSoccerDto
    {
        public bool Teams { get; set; }
        public bool Players { get; set; }
    }

    public class SeasonStatisticsSoccerDto
    {
        public PlayerStatisticsSoccerDto Season { get; set; }= default!;
    }

    public class PlayerStatisticsSoccerDto
    {
        public bool Players { get; set; }
    }

}
