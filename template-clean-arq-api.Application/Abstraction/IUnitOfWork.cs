namespace template_clean_arq_api.Application.Abstraction
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task BeginTransaction(CancellationToken cancellationToken = default);
        Task CommitTransaction(CancellationToken cancellationToken = default);
        Task RollbackTransaction(CancellationToken cancellationToken = default);
        Task<int> SaveChanges(CancellationToken cancellationToken = default);
    }
}
