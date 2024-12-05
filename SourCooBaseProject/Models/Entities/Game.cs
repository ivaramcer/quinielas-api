using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class Game
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
    public int LeagueId { get; set; }
    public League League { get; set; } = default!;
    public int SportId { get; set; }
    public Sport Sport { get; set; }= default!;
    public int HomeTeamId { get; set; }
    public Team HomeTeam { get; set; } = default!;
    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; } = default!;
    public int? WinnerTeamId { get; set; }
    public Team? WinnerTeam { get; set; } = default!;

}