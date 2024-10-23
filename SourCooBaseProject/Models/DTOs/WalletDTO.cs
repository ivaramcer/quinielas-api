using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class WalletDTO
{
    [Key]
    public int Id { get; set; }
    public double Balance { get; set; }
}

public class WalletInsertDTO
{
    [Key]
    public int Id { get; set; }
    public double Balance { get; set; }
}

public class WalletUpdateDTO
{
    [Key]
    public int Id { get; set; }
    public double Balance { get; set; }
}