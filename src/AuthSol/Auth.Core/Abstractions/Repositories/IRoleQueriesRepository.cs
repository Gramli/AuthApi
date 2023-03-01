namespace Auth.Core.Abstractions.Repositories
{
    public interface IRoleQueriesRepository
    {
        Task<IEnumerable<string>> GetRoles(CancellationToken cancellationToken);
    }
}
