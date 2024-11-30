using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class Country
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Flag { get; set; } = string.Empty;
    public int SportId { get; set; }
    public Sport Sport { get; set; } = default!;
    public bool IsActive { get; set; }
}