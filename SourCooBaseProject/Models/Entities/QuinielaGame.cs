using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class QuinielaGame
{
    [Key]
    public int Id { get; set; }
    public int QuinielaId { get; set; }
    public Quiniela Quiniela { get; set; } = default!;
    public int GameId { get; set; }
    public Game Game { get; set; } = default!;
    public string? Group  { get; set; } = default!;
    public int? GroupNumber {get; set;}

}