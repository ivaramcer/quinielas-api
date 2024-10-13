using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class QuinielaGame
{
    [Key]
    public int Id { get; set; }
    public int QuinielaId { get; set; }
    public Quiniela Quiniela { get; set; } = default!;
    public int NFLGameId { get; set; }
    public NFLGame NFLGame { get; set; } = default!;
    public int SoccerGameId { get; set; }
    public SoccerGame SoccerGame { get; set; } = default!;
    public string Group  { get; set; } = default!;
    public string GroupNumber {get; set;} = default!;

}