using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Commands;
using Auth.Core.Abstractions.Services;
using Auth.Domain.Commands;
using Auth.Domain.Extensions;
using Auth.Domain.Http;
using Auth.Domain.Resources;

namespace Auth.Core.Commands
{
    internal class RegisterCommandHandler : IRegisterCommandHandler
    {
        private readonly IAccountService _accountService;

        public RegisterCommandHandler(IAccountService accountService)
        {
            _accountService = Guard.Against.Null(accountService);
        }
        public async Task<HttpDataResponse<bool>> HandleAsync(RegisterCommand request, CancellationToken cancellationToken)
        {
            //TODO ADD COMMAND VALIDATION
            var userResult = await _accountService.CreateNewUser(request, cancellationToken);

            if (userResult.IsFailed)
            {
                return HttpDataResponses.AsBadRequest<bool>(ErrorMessages.InvalidRegistration);
            }

            return HttpDataResponses.AsOK(true);
        }
    }
}
