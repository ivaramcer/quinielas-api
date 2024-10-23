using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class Gamepass
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int QuinielaId { get; set; }
    public Quiniela Quiniela { get; set; }
}