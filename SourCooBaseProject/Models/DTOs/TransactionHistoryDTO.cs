using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class TransactionHistoryDTO
{
    [Key]
    public int Id { get; set; }
    public double Balance { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public int GamepassId { get; set; }
    public Gamepass Gamepass { get; set; }
    public int WalletId { get; set; }
    public Wallet Wallet { get; set; }
}

public class TransactionHistoryInsertDTO
{
    [Key]
    public int Id { get; set; }
    public double Balance { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public int GamepassId { get; set; }
    public Gamepass Gamepass { get; set; }
    public int WalletId { get; set; }
    public Wallet Wallet { get; set; }
}

public class TransactionHistoryUpdateDTO
{
    [Key]
    public int Id { get; set; }
    public double Balance { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public int GamepassId { get; set; }
    public Gamepass Gamepass { get; set; }
    public int WalletId { get; set; }
    public Wallet Wallet { get; set; }
}