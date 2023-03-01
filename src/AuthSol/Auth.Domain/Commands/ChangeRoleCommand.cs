namespace Auth.Domain.Commands
{
    public sealed class ChangeRoleCommand
    {
        public string UserName { get; init; } = string.Empty;
        public string RoleName { get; init; } = string.Empty;
    }
}
