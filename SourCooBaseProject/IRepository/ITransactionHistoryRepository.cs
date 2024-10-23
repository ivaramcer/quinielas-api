using QuinielasApi.Models.Entities;

namespace TransactionHistorysApi.IRepository
{
    public interface ITransactionHistoryRepository
    {
        Task<List<TransactionHistory>> GetAllAsync();
        Task<TransactionHistory?> GetByIdAsync(int id);
        Task BulkInsert(List<TransactionHistory> entities);
        void Create(TransactionHistory entity);
        void Update(TransactionHistory entity);
        void Delete(TransactionHistory entity);
    }
}
