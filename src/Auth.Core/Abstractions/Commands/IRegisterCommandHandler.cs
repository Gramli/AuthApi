using Auth.Domain.Commands;

namespace Auth.Core.Abstractions.Commands
{
    public interface IRegisterCommandHandler : IRequestHandler<bool, RegisterCommand>
    {
    }
}
