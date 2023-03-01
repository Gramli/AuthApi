namespace Auth.Infrastructure.Abstractions
{
    internal interface ISecretRoleCommandRepository
    {
        Task AddRoles(IEnumerable<string> roles, CancellationToken cancellationToken);
    }
}
