using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class GameDTO
{
    public int Id { get; set; }
    public DateTime Schedule { get; set; }
    public string Venue { get; set; }  = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int? Week { get; set; }
    public string? Round { get; set; }
    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }
    public bool? IsDraw { get; set; }
    public int ExternalId { get; set; }
    public int SportId { get; set; }
    public SportDTO Sport { get; set; } = default!;
    public int HomeTeamId { get; set; }
    public TeamDTO HomeTeam { get; set; } = default!;
    public int AwayTeamId { get; set; }
    public TeamDTO AwayTeam { get; set; } = default!;
    public int? WinnerTeamId { get; set; }
    public TeamDTO? WinnerTeam { get; set; } = default!;
}

public class GameInsertDTO
{
    [Key]
    public int Id { get; set; }
    public DateTime Schedule { get; set; }
    public string Venue { get; set; }  = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int? Week { get; set; }
    public string? Round { get; set; }
    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }
    public bool? IsDraw { get; set; }
    public int ExternalId { get; set; }
    public int SportId { get; set; }
    public Sport Sport { get; set; } = default!;
    public int HomeTeamId { get; set; }
    public Team HomeTeam { get; set; } = default!;
    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; } = default!;
    public int? WinnerTeamId { get; set; }
    public Team? WinnerTeam { get; set; } = default!;
}

public class GameUpdateDTO
{
    [Key]
    public int Id { get; set; }
    public DateTime Schedule { get; set; }
    public string Venue { get; set; }  = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int? Week { get; set; }
    public string? Round { get; set; }
    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }
    public bool? IsDraw { get; set; }
    public int ExternalId { get; set; }
    public int SportId { get; set; }
    public Sport Sport { get; set; } = default!;
    public int HomeTeamId { get; set; }
    public Team HomeTeam { get; set; } = default!;
    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; } = default!;
    public int? WinnerTeamId { get; set; }
    public Team? WinnerTeam { get; set; } = default!;
}