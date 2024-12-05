

public class FixtureSoccerDTO
{
    public FixtureDetailSoccerDTO? Fixture { get; set; } = default!;
    public LeagueSoccerDTO? League { get; set; } = default!;
    public TeamsSoccerDTO? Teams { get; set; } = default!;
    public GoalsSoccerDTO? Goals { get; set; } = default!;
    public ScoreSoccerDTO? Score { get; set; } = default!;
}

public class FixtureDetailSoccerDTO
{
    public int? Id { get; set; }
    public string? Referee { get; set; } = default!;
    public string? Timezone { get; set; } = default!;
    public string? Date { get; set; } = default!;
    public long? Timestamp { get; set; }
    public PeriodsSoccerDTO? Periods { get; set; } = default!;
    public VenueSoccerDTO? Venue { get; set; } = default!;
    public StatusSoccerDTO? Status { get; set; } = default!;
}

public class PeriodsSoccerDTO
{
    public long? First { get; set; }
    public long? Second { get; set; }
}

public class VenueSoccerDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; } = default!;
    public string? City { get; set; } = default!;
}

public class StatusSoccerDTO
{
    public string? Long { get; set; } = default!;
    public string? Short { get; set; } = default!;
    public int? Elapsed { get; set; }
}

public class LeagueSoccerDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; } = default!;
    public string? Country { get; set; } = default!;
    public string? Logo { get; set; } = default!;
    public string? Flag { get; set; } = default!;
    public int? Season { get; set; }
    public string? Round { get; set; } = default!;
}

public class TeamsSoccerDTO
{
    public TeamDetailSoccerDTO? Home { get; set; } = default!;
    public TeamDetailSoccerDTO? Away { get; set; } = default!;
}

public class TeamDetailSoccerDTO
{
    public int? Id{ get; set; }
    public string? Name { get; set; } = default!;
    public string? Logo { get; set; } = default!;
    public bool? Winner { get; set; }
}

public class GoalsSoccerDTO
{
    public int? Home { get; set; }
    public int? Away { get; set; }
}

public class ScoreSoccerDTO
{
    public ScoreDetailSoccerDTO? Halftime { get; set; } = default!;
    public ScoreDetailSoccerDTO? Fulltime { get; set; } = default!;
    public ScoreDetailSoccerDTO? Extratime { get; set; }
    public ScoreDetailSoccerDTO? Penalty { get; set; }
}

public class ScoreDetailSoccerDTO
{
    public int? Home { get; set; }
    public int? Away { get; set; }
}
