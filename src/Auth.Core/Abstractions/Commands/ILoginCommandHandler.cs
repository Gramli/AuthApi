using Auth.Domain.Commands;
using Auth.Domain.Dtos;

namespace Auth.Core.Abstractions.Commands
{
    public interface ILoginCommandHandler : IRequestHandler<LoggedUserDto, LoginCommand>
    {
    }
}
