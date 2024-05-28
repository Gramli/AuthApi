using Auth.Domain.Commands;
using SmallApiToolkit.Core.RequestHandlers;

namespace Auth.Core.Abstractions.Commands
{
    public interface IRegisterCommandHandler : IHttpRequestHandler<bool, RegisterCommand>
    {
    }
}
