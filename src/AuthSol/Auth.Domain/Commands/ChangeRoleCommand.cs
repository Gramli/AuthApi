namespace Auth.Domain.Commands
{
    public sealed class ChangeRoleCommand
    {
        public int UserId { get; init; }
        public string RoleName { get; init; } = string.Empty;
    }
}
