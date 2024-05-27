using Auth.Domain.Commands;
using Auth.Domain.Dtos;
using SmallApiToolkit.Core.RequestHandlers;

namespace Auth.Core.Abstractions.Commands
{
    public interface ILoginCommandHandler : IHttpRequestHandler<LoggedUserDto, LoginCommand>
    {
    }
}
