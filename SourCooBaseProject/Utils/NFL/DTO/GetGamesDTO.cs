public class GetGamesDTO
{
    public GameDetailDto Game { get; set; }
    public LeagueDto League { get; set; }
    public TeamsDto Teams { get; set; }
    public ScoresDto Scores { get; set; }
}

public class GameDetailDto
{
    public int Id { get; set; }
    public string Stage { get; set; }
    public string Week { get; set; }
    public GameDateDto Date { get; set; }
    public VenueDto Venue { get; set; }
    public StatusDto Status { get; set; }
}

public class GameDateDto
{
    public string Timezone { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public long Timestamp { get; set; }
}

public class VenueDto
{
    public string Name { get; set; }
    public string City { get; set; }
}

public class StatusDto
{
    public string Short { get; set; }
    public string Long { get; set; }
    public string Timer { get; set; } // Nullable, hence string
}

public class LeagueDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Season { get; set; }
    public string Logo { get; set; }
    public CountryDto Country { get; set; }
}

public class CountryDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Flag { get; set; }
}

public class TeamsDto
{
    public TeamDetailDto Home { get; set; }
    public TeamDetailDto Away { get; set; }
}

public class TeamDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
}

public class ScoresDto
{
    public ScoreDetailDto Home { get; set; }
    public ScoreDetailDto Away { get; set; }
}

public class ScoreDetailDto
{
    public int? Quarter1 { get; set; }
    public int? Quarter2 { get; set; }
    public int? Quarter3 { get; set; }
    public int? Quarter4 { get; set; }
    public int? Overtime { get; set; }
    public int? Total { get; set; }
}
