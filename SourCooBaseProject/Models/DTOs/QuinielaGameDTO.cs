using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class QuinielaGameDTO
{
    [Key]
    public int Id { get; set; }
    public int QuinielaId { get; set; }
    public QuinielaDTO Quiniela { get; set; } = default!;
    public int GameId { get; set; }
    public GameDTO Game { get; set; } = default!;
    public string? Group  { get; set; } = default!;
    public int? GroupNumber {get; set;}

}

public class QuinielaGameInsertDTO
{
    [Key]
    public int Id { get; set; }
    public int QuinielaId { get; set; }
    public QuinielaInsertDTO Quiniela { get; set; } = default!;
    public int GameId { get; set; }
    public GameInsertDTO Game { get; set; } = default!;
    public string? Group  { get; set; } = default!;
    public int? GroupNumber {get; set;}

}

public class QuinielaGameUpdateDTO
{
    [Key]
    public int Id { get; set; }
    public int QuinielaId { get; set; }
    public QuinielaUpdateDTO Quiniela { get; set; } = default!;
    public int GameId { get; set; }
    public GameUpdateDTO Game { get; set; } = default!;
    public string? Group  { get; set; } = default!;
    public int? GroupNumber {get; set;}

}