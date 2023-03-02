using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Commands;
using Auth.Core.Abstractions.Repositories;
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
        private readonly IRoleQueriesRepository _roleQueriesRepository;

        public ChangeRoleCommandHandler(IUserService userService, IRoleQueriesRepository roleQueriesRepository)
        {
            _userService = Guard.Against.Null(userService);
            _roleQueriesRepository = Guard.Against.Null(roleQueriesRepository);
        }

        public async Task<HttpDataResponse<bool>> HandleAsync(ChangeRoleCommand request, CancellationToken cancellationToken)
        {
            //TODO ADD VALIDATIOn
            var roles = await _roleQueriesRepository.GetRoles(cancellationToken);

            if(!roles.Contains(request.RoleName, StringComparer.OrdinalIgnoreCase))
            {
                return HttpDataResponses.AsBadRequest<bool>(ErrorMessages.FailedRoleChange);
            }

            var changeResult = await _userService.ChangeUserRole(request, cancellationToken);
            
            if(changeResult.IsFailed) 
            {
                return HttpDataResponses.AsInternalServerError<bool>(ErrorMessages.FailedRoleChange);
            }

            return HttpDataResponses.AsOK(changeResult.Value);
        }
    }
}
