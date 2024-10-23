using QuinielasApi.Models.Entities;

namespace OperationTypesApi.IRepository
{
    public interface IOperationTypeRepository
    {
        Task<List<OperationType>> GetAllAsync();
        Task<OperationType?> GetByIdAsync(int id);
        Task BulkInsert(List<OperationType> entities);
        void Create(OperationType entity);
        void Update(OperationType entity);
        void Delete(OperationType entity);
    }
}
