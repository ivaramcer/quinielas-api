namespace QuinielasApi.Utils.NFL.DTO
{
    public class GetGamesDTO
    {
        public int Id { get; set; } = default!;
        public string Stage { get; set; } = default!;
        public string Week { get; set; } = default!;
        public GameDate Date { get; set; } = default!;
        public Venue Venue { get; set; } = default!;
        public GameStatus Status { get; set; } = default!;
        public League League { get; set; } = default!;
        public Teams Teams { get; set; } = default!;
        public Scores Scores { get; set; } = default!;
    }

    public class GameDate
    {
        public string Timezone { get; set; } = default!;
        public string Date { get; set; } = default!;
        public string Time { get; set; } = default!;
        public long Timestamp { get; set; } = default!;
    }

    public class Venue
    {
        public string Name { get; set; } = default!;
        public string City { get; set; } = default!;
    }

    public class GameStatus
    {
        public string Short { get; set; } = default!;
        public string Long { get; set; } = default!;
        public string Timer { get; set; } = default!;
    }

    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Season { get; set; } = default!;
        public string Logo { get; set; } = default!;
        public Country Country { get; set; } = default!;
    }

    public class Country
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Flag { get; set; } = default!;
    }

    public class Teams
    {
        public Team Home { get; set; } = default!;
        public Team Away { get; set; } = default!;
    }

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Logo { get; set; } = default!;
    }

    public class Scores
    {
        public Score Home { get; set; } = default!;
        public Score Away { get; set; } = default!;
    }

    public class Score
    {
        public int? Quarter_1 { get; set; }
        public int? Quarter_2 { get; set; }
        public int? Quarter_3 { get; set; }
        public int? Quarter_4 { get; set; }
        public int? Overtime { get; set; }
        public int Total { get; set; }
    }
}
