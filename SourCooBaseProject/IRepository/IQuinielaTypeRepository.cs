using QuinielasApi.Models.Entities;

namespace QuinielaTypesApi.IRepository
{
    public interface IQuinielaTypeRepository
    {
        Task<List<QuinielaType>> GetAllAsync();
        Task<QuinielaType?> GetByIdAsync(int id);
        Task BulkInsert(List<QuinielaType> entities);
        void Create(QuinielaType entity);
        void Update(QuinielaType entity);
        void Delete(QuinielaType entity);
    }
}
