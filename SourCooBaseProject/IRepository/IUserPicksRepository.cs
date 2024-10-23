using QuinielasApi.Models.Entities;

namespace UserPickssApi.IRepository
{
    public interface IUserPicksRepository
    {
        Task<List<UserPicks>> GetAllAsync();
        Task<UserPicks?> GetByIdAsync(int id);
        Task BulkInsert(List<UserPicks> entities);
        void Create(UserPicks entity);
        void Update(UserPicks entity);
        void Delete(UserPicks entity);
    }
}
