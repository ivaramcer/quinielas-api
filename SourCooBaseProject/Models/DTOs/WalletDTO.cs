using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class WalletDTO
{
    public int Id { get; set; }
    public double Balance { get; set; }
}

public class WalletInsertDTO
{
    public int Id { get; set; }
    public double Balance { get; set; }
}

public class WalletUpdateDTO
{
    public int Id { get; set; }
    public double Balance { get; set; }
}