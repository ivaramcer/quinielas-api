using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class Wallet
{
    [Key]
    public int Id { get; set; }
    public double Balance { get; set; }
}