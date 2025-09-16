namespace Auth.Domain.UseCases.User.Commands
{
    public sealed class ChangeRoleCommand : ChangeRoleBody
    {
        public required int Id { get; init; }

    }
    public class ChangeRoleBody
    {
        public required string RoleName { get; init; } = string.Empty;
    }
}
