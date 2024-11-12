using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities;

public class TransactionHistoryDTO
{
    public int Id { get; set; }
    public double Balance { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public int GamepassId { get; set; }
    public GamepassDTO Gamepass { get; set; } = default!;
    public int WalletId { get; set; }
    public WalletDTO Wallet { get; set; }= default!;
}

public class TransactionHistoryInsertDTO
{
    public int Id { get; set; }
    public double Balance { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public int GamepassId { get; set; }
    public GamepassInsertDTO Gamepass { get; set; }= default!;
    public int WalletId { get; set; }
    public WalletInsertDTO Wallet { get; set; }= default!;
}

public class TransactionHistoryUpdateDTO
{
    public int Id { get; set; }
    public double Balance { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public int GamepassId { get; set; }
    public GamepassUpdateDTO Gamepass { get; set; }= default!;
    public int WalletId { get; set; }
    public WalletUpdateDTO Wallet { get; set; }= default!;
}