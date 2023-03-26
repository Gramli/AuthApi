using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Commands;
using Auth.Core.Abstractions.Services;
using Auth.Core.Resources;
using Auth.Domain.Commands;
using Auth.Domain.Dtos;
using Auth.Domain.Extensions;
using Auth.Domain.Http;
using Validot;

namespace Auth.Core.Commands
{
    internal class LoginCommandHandler : ILoginCommandHandler
    {
        private readonly ITokenService _tokenService;
        private readonly IAccountService _accountService;
        private readonly IValidator<LoginCommand> _validator;

        public LoginCommandHandler(ITokenService tokenService, IAccountService accountService, IValidator<LoginCommand> validator)
        {
            _tokenService = Guard.Against.Null(tokenService);
            _accountService = Guard.Against.Null(accountService);
            _validator = Guard.Against.Null(validator);
        }

        public async Task<HttpDataResponse<LogedUserDto>> HandleAsync(LoginCommand request, CancellationToken cancellationToken)
        {
            if(!_validator.IsValid(request))
            {
                return HttpDataResponses.AsBadRequest<LogedUserDto>(ErrorMessages.InvalidRequest);
            }

            var userResult = await _accountService.FindUser(request, cancellationToken);

            if(userResult.IsFailed)
            {
                return HttpDataResponses.AsBadRequest<LogedUserDto>(ErrorMessages.InvalidUsernameOrPassword);
            }

            var token = _tokenService.GenerateToken(new UserDto(request.Username, userResult.Value.Role));
            return HttpDataResponses.AsOK(new LogedUserDto(request.Username, userResult.Value.Role, token));
        }
    }
}
