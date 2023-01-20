using Auth.Core.Abstractions;
using Auth.Domain.Commands;
using Auth.Domain.Dtos;
using Auth.Domain.Http;

namespace Auth.Core.Commands
{
    internal class LoginCommandHandler : IRequestHandler<LogedUserDto, LoginCommand>
    {
        private readonly ITokenService _tokenService;
        public Task<HttpDataResponse<LogedUserDto>> HandleAsync(LoginCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
