using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Services;
using Auth.Domain.Commands;
using Auth.Infrastructure.Abstractions;
using FluentResults;

namespace Auth.Infrastructure.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly ISecretUserQueriesRepository _secretUserQueriesRepository;
        private readonly ISecretUserCommandsRepository _secretUserCommandsRepository;
        private readonly ISecretRoleQueriesRepository _secretRoleQueriesRepository;

        public UserService(
            ISecretUserQueriesRepository secretUserQueriesRepository,
            ISecretUserCommandsRepository secretUserCommandsRepository, 
            ISecretRoleQueriesRepository secretRoleQueriesRepository)
        {
            _secretUserQueriesRepository = Guard.Against.Null(secretUserQueriesRepository);
            _secretUserCommandsRepository = Guard.Against.Null(secretUserCommandsRepository);
            _secretRoleQueriesRepository = Guard.Against.Null(secretRoleQueriesRepository);
        }

        public async Task<Result<bool>> ChangeUserRole(ChangeRoleCommand changeRoleCommand, CancellationToken cancellationToken)
        {
            var userResult = await _secretUserQueriesRepository.FindUser(changeRoleCommand.UserName, cancellationToken);
            if(userResult.IsFailed) 
            {
                return Result.Fail(userResult.Errors);
            }

            var roleResult = await _secretRoleQueriesRepository.GetRoleEntity(changeRoleCommand.RoleName, cancellationToken);

            if (roleResult.IsFailed)
            {
                return Result.Fail(roleResult.Errors);
            }

            return  await _secretUserCommandsRepository.ChangeUserRole(userResult.Value, roleResult.Value, cancellationToken);
        }
    }
}
