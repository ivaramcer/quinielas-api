using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class CountryDTO
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Flag { get; set; } = string.Empty;
    public int SportId { get; set; }
    public SportDTO Sport { get; set; } = default!;
    public bool IsActive { get; set; }
}

public class CountryInsertDTO
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Flag { get; set; } = string.Empty;
    public int SportId { get; set; }
    public bool IsActive { get; set; }
}

public class CountryUpdateDTO
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Flag { get; set; } = string.Empty;
    public int SportId { get; set; }
    public bool IsActive { get; set; }
}