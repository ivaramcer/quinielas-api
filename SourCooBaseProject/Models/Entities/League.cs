using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class League
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string Type { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ExternalId { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; } = default!;
    public int SportId { get; set; }
    public Sport Sport { get; set; } = default!;
    public ICollection<Quiniela> Quinielas { get; set; } = new List<Quiniela>();
}