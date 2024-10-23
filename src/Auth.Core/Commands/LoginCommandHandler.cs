using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Services;
using Auth.Core.Resources;
using Auth.Domain.Commands;
using Auth.Domain.Dtos;
using SmallApiToolkit.Core.Extensions;
using SmallApiToolkit.Core.RequestHandlers;
using SmallApiToolkit.Core.Response;
using Validot;

namespace Auth.Core.Commands
{
    internal sealed class LoginCommandHandler : IHttpRequestHandler<string, LoginCommand>
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

        public async Task<HttpDataResponse<string>> HandleAsync(LoginCommand request, CancellationToken cancellationToken)
        {
            if(!_validator.IsValid(request))
            {
                return HttpDataResponses.AsBadRequest<string>(ErrorMessages.InvalidRequest);
            }

            var userResult = await _accountService.FindUser(request, cancellationToken);

            if(userResult.IsFailed)
            {
                return HttpDataResponses.AsBadRequest<string>(ErrorMessages.InvalidUsernameOrPassword);
            }

            var token = _tokenService.GenerateToken(new UserDto(request.Username, userResult.Value.Role));
            return HttpDataResponses.AsOK(token);
        }
    }
}
