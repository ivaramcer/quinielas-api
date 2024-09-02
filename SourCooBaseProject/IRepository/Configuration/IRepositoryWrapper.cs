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

    }
}
