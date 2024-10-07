
namespace QuinielasApi.Utils.NFL.SoccerDto
{
    public class LeagueParametersSoccerDto
    {
        public string Season { get; set; }
    }

    public class LeagueInfoSoccerDto
    {
        public LeagueSoccerDto League { get; set; }
        public CountrySoccerDto Country { get; set; }
        public List<SeasonSoccerDto> Seasons { get; set; }
    }

    public class LeagueSoccerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
    }

    public class CountrySoccerDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
    }

    public class SeasonSoccerDto
    {
        public int Year { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public bool Current { get; set; }
        public CoverageSoccerDto Coverage { get; set; }
    }

    public class CoverageSoccerDto
    {
        public GameCoverageSoccerDto Games { get; set; }
        public SeasonStatisticsSoccerDto Statistics { get; set; }
        public bool Players { get; set; }
        public bool Injuries { get; set; }
        public bool Standings { get; set; }
    }

    public class GameCoverageSoccerDto
    {
        public bool Events { get; set; }
        public StatisticsDetailsSoccerDto Statisitcs { get; set; }
    }

    public class StatisticsDetailsSoccerDto
    {
        public bool Teams { get; set; }
        public bool Players { get; set; }
    }

    public class SeasonStatisticsSoccerDto
    {
        public PlayerStatisticsSoccerDto Season { get; set; }
    }

    public class PlayerStatisticsSoccerDto
    {
        public bool Players { get; set; }
    }

}
