using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class GamepassDTO
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }= default!;
    public int QuinielaId { get; set; }
    public Quiniela Quiniela { get; set; }= default!;
}

public class GamepassInsertDTO
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }= default!;
    public int QuinielaId { get; set; }
    public Quiniela Quiniela { get; set; }= default!;
}

public class GamepassUpdateDTO
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }= default!;
    public int QuinielaId { get; set; }
    public Quiniela Quiniela { get; set; }= default!;
}