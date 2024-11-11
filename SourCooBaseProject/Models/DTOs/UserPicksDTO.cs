using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class UserPicksDTO
{
    [Key]
    public int Id { get; set; }
    public bool IsRegistered { get; set; }
    public DateTime Deadline { get; set; }
    public bool? IsDraw { get; set; }
    public int? Week { get; set; }
    public string Round { get; set; } = String.Empty;
    public int QuinielaGameId { get; set; } 
    public QuinielaGame QuinielaGame { get; set; } = default!;
    public int TeamId { get; set; }
    public Team Team { get; set; } = default!;
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public int QuinielaId { get; set; }
    public Quiniela Quiniela { get; set; } = default!;
}

public class UserPicksInsertDTO
{
    [Key]
    public int Id { get; set; }
    public bool? IsDraw { get; set; }
    public int? Week { get; set; }
    public string Round { get; set; } = String.Empty;
    public int QuinielaGameId { get; set; } 
    public QuinielaGame QuinielaGame { get; set; } = default!;
    public int TeamId { get; set; }
    public Team Team { get; set; } = default!;
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public int QuinielaId { get; set; }
    public Quiniela Quiniela { get; set; } = default!;
}


public class UserPicksUpdateDTO
{
    [Key]
    public int Id { get; set; }
    public bool? IsDraw { get; set; }
    public int? Week { get; set; }
    public string Round { get; set; } = String.Empty;
    public int QuinielaGameId { get; set; } 
    public QuinielaGame QuinielaGame { get; set; } = default!;
    public int TeamId { get; set; }
    public Team Team { get; set; } = default!;
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public int QuinielaId { get; set; }
    public Quiniela Quiniela { get; set; } = default!;
}