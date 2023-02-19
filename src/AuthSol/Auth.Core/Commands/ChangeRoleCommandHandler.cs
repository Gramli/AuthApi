using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Commands;
using Auth.Core.Abstractions.Services;
using Auth.Domain.Commands;
using Auth.Domain.Extensions;
using Auth.Domain.Http;
using Auth.Domain.Resources;

namespace Auth.Core.Commands
{
    internal sealed class ChangeRoleCommandHandler : IChangeRoleCommandHandler
    {
        private readonly IUserService _userService;

        public ChangeRoleCommandHandler(IUserService userService)
        {
            _userService = Guard.Against.Null(userService);
        }

        public async Task<HttpDataResponse<bool>> HandleAsync(ChangeRoleCommand request, CancellationToken cancellationToken)
        {
            //TODO ADD VALIDATIOn
            var changeResult = await _userService.ChangeUserRole(request, cancellationToken);
            if(changeResult.IsFailed) 
            {
                return HttpDataResponses.AsInternalServerError<bool>(ErrorMessages.FailedRoleChange);
            }

            return HttpDataResponses.AsOK(changeResult.Value);
        }
    }
}
