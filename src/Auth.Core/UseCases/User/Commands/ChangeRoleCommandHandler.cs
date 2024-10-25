using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Repositories;
using Auth.Core.Abstractions.Services;
using Auth.Core.Resources;
using Auth.Domain;
using Auth.Domain.Extensions;
using Auth.Domain.UseCases.User.Commands;
using FluentResults;
using Microsoft.Extensions.Logging;
using SmallApiToolkit.Core.Extensions;
using SmallApiToolkit.Core.RequestHandlers;
using SmallApiToolkit.Core.Response;
using Validot;

namespace Auth.Core.UseCases.User.Commands
{
    internal sealed class ChangeRoleCommandHandler : IHttpRequestHandler<bool, ChangeRoleCommand>
    {
        private readonly IUserService _userService;
        private readonly IRoleQueriesRepository _roleQueriesRepository;
        private readonly IValidator<ChangeRoleCommand> _validator;
        private readonly ILogger<ChangeRoleCommandHandler> _logger;           

        public ChangeRoleCommandHandler(
            IUserService userService, 
            IRoleQueriesRepository roleQueriesRepository, 
            IValidator<ChangeRoleCommand> validator,
            ILogger<ChangeRoleCommandHandler> logger)
        {
            _userService = Guard.Against.Null(userService);
            _roleQueriesRepository = Guard.Against.Null(roleQueriesRepository);
            _validator = Guard.Against.Null(validator);
            _logger = Guard.Against.Null(logger);
        }

        public async Task<HttpDataResponse<bool>> HandleAsync(ChangeRoleCommand request, CancellationToken cancellationToken)
        {
            if (!_validator.IsValid(request))
            {
                return HttpDataResponses.AsBadRequest<bool>(ErrorMessages.InvalidRequest);
            }

            var roles = await _roleQueriesRepository.GetRoles(cancellationToken);

            if (!roles.Contains(request.RoleName, StringComparer.OrdinalIgnoreCase))
            {
                return HttpDataResponses.AsBadRequest<bool>(ErrorMessages.FailedRoleChange);
            }

            var isAllowedResult = await IsAllowedToChangeRoleAsync(request, cancellationToken);

            if (isAllowedResult.IsFailed)
            {
                _logger.LogError(isAllowedResult.ToErrorString());
                return HttpDataResponses.AsForbidden<bool>(ErrorMessages.FailedRoleChange);
            }

            var changeResult = await _userService.ChangeUserRole(request, cancellationToken);

            if (changeResult.IsFailed)
            {
                _logger.LogError(changeResult.ToErrorString());
                return HttpDataResponses.AsInternalServerError<bool>(ErrorMessages.FailedRoleChange);
            }

            return HttpDataResponses.AsOK(changeResult.Value);
        }

        private async Task<Result> IsAllowedToChangeRoleAsync(ChangeRoleCommand request, CancellationToken cancellationToken)
        {
            var authorizedUserResult = await _userService.GetAuthorizedUser(cancellationToken);

            if (authorizedUserResult.IsFailed)
            {
                return Result.Fail(authorizedUserResult.Errors);
            }

            var requestUserResult = await _userService.GetUser(request.UserName, cancellationToken);

            if(requestUserResult.IsFailed)
            {
                return Result.Fail(requestUserResult.Errors);
            }

            if (authorizedUserResult.Value.Role.IsAdministrator() && requestUserResult.Value.Role.IsAdministrator())
            {
                return Result.Fail("Not allowed");
            }

            if(requestUserResult.Value.Role.Equals(request.RoleName))
            {
                return Result.Fail("User is already in the role");
            }

            return Result.Ok();
        }
    }
}
