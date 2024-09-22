using QuinielasApi.Models.Entities;

namespace StatusApi.IRepository
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetAllAsync();
        Task<Status?> GetByIdAsync(int id);
        Task BulkInsert(List<Status> entities);
        void Create(Status entity);
        void Update(Status entity);
        void Delete(Status entity);
    }
}
