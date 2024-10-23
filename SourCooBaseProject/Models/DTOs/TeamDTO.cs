using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class TeamDTO
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public int ExternalId { get; set; }
    public int SportId { get; set; }
    public SportDTO Sport { get; set; } = default!;
    public int LeagueId { get; set; }
    public LeagueDTO League { get; set; } = default!;
}

public class TeamInsertDTO
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public int ExternalId { get; set; }
    public int SportId { get; set; }
    public Sport Sport { get; set; } = default!;
    public int LeagueId { get; set; }
    public League League { get; set; } = default!;
}


public class TeamUpdateDTO
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public int ExternalId { get; set; }
    public int SportId { get; set; }
    public Sport Sport { get; set; } = default!;
    public int LeagueId { get; set; }
    public League League { get; set; } = default!;
}