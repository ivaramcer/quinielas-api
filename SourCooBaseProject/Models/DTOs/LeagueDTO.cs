using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class LeagueDTO
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string Type { get; set; } = string.Empty;
    public int ExternalId { get; set; }
    public int SportId { get; set; }
    public Sport Sport { get; set; } = default!;
}

public class LeagueInsertDTO
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string Type { get; set; } = string.Empty;
    public int ExternalId { get; set; }
    public int SportId { get; set; }
    public Sport Sport { get; set; } = default!;
}

public class LeagueUpdateDTO
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string Type { get; set; } = string.Empty;
    public int ExternalId { get; set; }
    public int SportId { get; set; }
    public Sport Sport { get; set; } = default!;
}