namespace Auth.Infrastructure.Abstractions
{
    internal interface IRoleCommandRepository
    {
        Task AddRoles(IEnumerable<string> roles, CancellationToken cancellationToken);
    }
}
