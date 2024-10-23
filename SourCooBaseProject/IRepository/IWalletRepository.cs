using QuinielasApi.Models.Entities;

namespace WalletsApi.IRepository
{
    public interface IWalletRepository
    {
        Task<List<Wallet>> GetAllAsync();
        Task<Wallet?> GetByIdAsync(int id);
        Task<Wallet?> GetByUserIdAsync(int userId);
        Task BulkInsert(List<Wallet> entities);
        void Create(Wallet entity);
        void Update(Wallet entity);
        void Delete(Wallet entity);
    }
}
