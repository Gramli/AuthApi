using Ardalis.GuardClauses;
using Auth.Core.Abstractions;
using Auth.Domain.Commands;
using Auth.Domain.Dtos;
using Auth.Domain.Extensions;
using Auth.Domain.Http;
using Auth.Domain.Resources;

namespace Auth.Core.Commands
{
    internal class LoginCommandHandler : IRequestHandler<LogedUserDto, LoginCommand>
    {
        private readonly ITokenService _tokenService;
        private readonly IAccountService _accountService;

        public LoginCommandHandler(ITokenService tokenService, IAccountService accountService)
        {
            _tokenService = Guard.Against.Null(tokenService);
            _accountService = Guard.Against.Null(accountService);
        }
        public async Task<HttpDataResponse<LogedUserDto>> HandleAsync(LoginCommand request, CancellationToken cancellationToken)
        {
            var userResult = await _accountService.FindUser(request, cancellationToken);

            if(userResult.IsFailed)
            {
                HttpDataResponses.AsBadRequest<LogedUserDto>(ErrorMessages.InvalidUsernameOrPassword);
            }

            var token = _tokenService.GenerateToken(new UserDto(request.Username, userResult.Value.Role));
            return HttpDataResponses.AsOK(new LogedUserDto(request.Username, userResult.Value.Role, token));
        }
    }
}
