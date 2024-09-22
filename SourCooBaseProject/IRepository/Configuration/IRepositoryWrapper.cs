using QuinielaDurationsApi.IRepository;
using QuinielaPickDurationsApi.IRepository;
using QuinielaTypesApi.IRepository;
using StatusApi.IRepository;

namespace QuinielasApi.IRepository.Configuration
{
    public interface IRepositoryWrapper
    {
        void Save();
        Task SaveAsync();
        void Clear();
        IUserRepository User { get; }
        ISportRepository Sport { get; }
        IPermissionRepository Permission { get; }
        IPersonRepository Person { get; }
        IQuinielaRepository Quiniela { get; }
        IQuinielaDurationRepository QuinielaDuration { get; }
        IQuinielaPickDurationRepository QuinielaPickDuration { get; }
        IQuinielaTypeRepository QuinielaType { get; }
        IStatusRepository Status{ get; }

    }
}
