﻿public class GetGamesSoccerDTO
{
    public GameDetailDto Game { get; set; } = default!;
    public LeagueDto League { get; set; } = default!;
    public TeamsDto Teams { get; set; } = default!;
    public ScoresDto Scores { get; set; } = default!;
}

public class GameDetailSoccerDto
{
    public int Id { get; set; }
    public string Stage { get; set; } = default!;
    public string Week { get; set; } = default!;
    public GameDateDto Date { get; set; } = default!;
    public VenueDto Venue { get; set; } = default!;
    public StatusDto Status { get; set; } = default!;
}

public class GameDateSoccerDto
{
    public string Timezone { get; set; } = default!;
    public string Date { get; set; } = default!;
    public string Time { get; set; } = default!;
    public long Timestamp { get; set; }
}

public class VenueSoccerDto
{
    public string Name { get; set; } = default!;
    public string City { get; set; } = default!;
}

public class StatusSoccerDto
{
    public string Short { get; set; } = default!;
    public string Long { get; set; } = default!;
    public string Timer { get; set; } = default!; // Nullable, hence string
}

public class LeagueSoccerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Season { get; set; }
    public string Logo { get; set; } = default!;
    public CountryDto Country { get; set; } = default!;
}

public class CountrySoccerDto
{
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string Flag { get; set; } = default!;
}

public class TeamsSoccerDto
{
    public TeamDetailDto Home { get; set; } = default!;
    public TeamDetailDto Away { get; set; } = default!;
}

public class TeamDetailSoccerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Logo { get; set; } = default!;
}

public class ScoresSoccerDto
{
    public ScoreDetailDto Home { get; set; } = default!;
    public ScoreDetailDto Away { get; set; } = default!;
}

public class ScoreDetailSoccerDto
{
    public int? Quarter1 { get; set; }
    public int? Quarter2 { get; set; }
    public int? Quarter3 { get; set; }
    public int? Quarter4 { get; set; }
    public int? Overtime { get; set; }
    public int? Total { get; set; }
}