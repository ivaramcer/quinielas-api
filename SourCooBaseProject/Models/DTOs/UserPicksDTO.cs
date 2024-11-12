using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class UserPicksDTO
{
    public int Id { get; set; }
    public bool IsRegistered { get; set; }
    public DateTime Deadline { get; set; }
    public bool? IsDraw { get; set; }
    public int? Week { get; set; }
    public string Round { get; set; } = String.Empty;
    public int QuinielaGameId { get; set; } 
    public QuinielaGameDTO QuinielaGame { get; set; } = default!;
    public int TeamId { get; set; }
    public TeamDTO Team { get; set; } = default!;
    public int UserId { get; set; }
    public UserDTO User { get; set; } = default!;
    public int QuinielaId { get; set; }
    public QuinielaDTO Quiniela { get; set; } = default!;
}

public class UserPicksInsertDTO
{
    public int Id { get; set; }
    public bool? IsDraw { get; set; }
    public int? Week { get; set; }
    public string Round { get; set; } = String.Empty;
    public int QuinielaGameId { get; set; } 
    public QuinielaGameInsertDTO QuinielaGame { get; set; } = default!;
    public int TeamId { get; set; }
    public TeamInsertDTO Team { get; set; } = default!;
    public int UserId { get; set; }
    public UserInsertDTO User { get; set; } = default!;
    public int QuinielaId { get; set; }
    public QuinielaInsertDTO Quiniela { get; set; } = default!;
}

public class UserPicksInsertBulkDTO
{
    public int Id { get; set; }
    public bool? IsDraw { get; set; }
    public int QuinielaGameId { get; set; }
    public int TeamId { get; set; }
}


public class UserPicksUpdateDTO
{
    public int Id { get; set; }
    public bool? IsDraw { get; set; }
    public int? Week { get; set; }
    public string Round { get; set; } = String.Empty;
    public int QuinielaGameId { get; set; } 
    public QuinielaGameUpdateDTO QuinielaGame { get; set; } = default!;
    public int TeamId { get; set; }
    public TeamUpdateDTO Team { get; set; } = default!;
    public int UserId { get; set; }
    public UserUpdateDTO User { get; set; } = default!;
    public int QuinielaId { get; set; }
    public QuinielaUpdateDTO Quiniela { get; set; } = default!;
}