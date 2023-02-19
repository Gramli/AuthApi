using Auth.Domain.Commands;

namespace Auth.Core.Abstractions.Commands
{
    public interface IChangeRoleCommandHandler : IRequestHandler<bool, ChangeRoleCommand>
    {
    }
}
