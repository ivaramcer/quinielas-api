using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class TeamDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public bool IsNational { get; set; } 
    public int ExternalId { get; set; }
    public int SportId { get; set; }
    public SportDTO Sport { get; set; } = default!;
    public int LeagueId { get; set; }
    public LeagueDTO League { get; set; } = default!;
}

public class TeamInsertDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public bool IsNational { get; set; } 
    public int ExternalId { get; set; }
    public int SportId { get; set; }
    public SportInsertDTO Sport { get; set; } = default!;
    public int LeagueId { get; set; }
    public LeagueInsertDTO League { get; set; } = default!;
}


public class TeamUpdateDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public bool IsNational { get; set; } 
    public int ExternalId { get; set; }
    public int SportId { get; set; }
    public SportInsertDTO Sport { get; set; } = default!;
    public int LeagueId { get; set; }
    public LeagueInsertDTO League { get; set; } = default!;
}