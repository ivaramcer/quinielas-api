﻿using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class LeagueDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string Type { get; set; } = string.Empty;
    public int ExternalId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CountryId { get; set; }
    public CountryDTO Country { get; set; } = default!;
    public int SportId { get; set; }
    public SportDTO Sport { get; set; } = default!;
    public ICollection<QuinielaDTO> Quinielas { get; set; } = new List<QuinielaDTO>();

}

public class LeagueInsertDTO
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CountryId { get; set; }

    public string Type { get; set; } = string.Empty;
    public int ExternalId { get; set; }
    public int SportId { get; set; }
}

public class LeagueUpdateDTO
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CountryId { get; set; }

    public string Type { get; set; } = string.Empty;
    public int ExternalId { get; set; }
    public int SportId { get; set; }
}
public class LeagueQuinielasDTO
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string Type { get; set; } = string.Empty;
    public int ExternalId { get; set; }
    public int SportId { get; set; }
    public List<QuinielaDTO> Quinielas { get; set; } = new List<QuinielaDTO>();
}

