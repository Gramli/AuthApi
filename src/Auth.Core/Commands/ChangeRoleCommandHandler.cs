using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Repositories;
using Auth.Core.Abstractions.Services;
using Auth.Core.Resources;
using Auth.Domain.Commands;
using SmallApiToolkit.Core.Extensions;
using SmallApiToolkit.Core.RequestHandlers;
using SmallApiToolkit.Core.Response;
using Validot;

namespace Auth.Core.Commands
{
    //TODO IMPLEMENT LOGIC TO CHANGE ROLE, SAME USER CANT CHANGE ROLE TO HIMSELF
    //ADMINISTRATOR CANT DECREASE ANOTHER ADMINISTRATOR
    internal sealed class ChangeRoleCommandHandler : IHttpRequestHandler<bool, ChangeRoleCommand>
    {
        private readonly IUserService _userService;
        private readonly IRoleQueriesRepository _roleQueriesRepository;
        private readonly IValidator<ChangeRoleCommand> _validator;

        public ChangeRoleCommandHandler(IUserService userService, IRoleQueriesRepository roleQueriesRepository, IValidator<ChangeRoleCommand> validator)
        {
            _userService = Guard.Against.Null(userService);
            _roleQueriesRepository = Guard.Against.Null(roleQueriesRepository);
            _validator = Guard.Against.Null(validator);
        }

        public async Task<HttpDataResponse<bool>> HandleAsync(ChangeRoleCommand request, CancellationToken cancellationToken)
        {
            if(!_validator.IsValid(request))
            {
                return HttpDataResponses.AsBadRequest<bool>(ErrorMessages.InvalidRequest);
            }

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
