using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Services;
using Auth.Domain.Commands;
using Auth.Infrastructure.Abstractions;
using FluentResults;

namespace Auth.Infrastructure.Services
{
    internal class UserService : IUserService
    {
        private readonly ISecretUserQueriesRepository _secretUserQueriesRepository;
        private readonly ISecretUserCommandsRepository _secretUserCommandsRepository;

        public UserService(ISecretUserQueriesRepository secretUserQueriesRepository, ISecretUserCommandsRepository secretUserCommandsRepository)
        {
            _secretUserQueriesRepository = Guard.Against.Null(secretUserQueriesRepository);
            _secretUserCommandsRepository = Guard.Against.Null(secretUserCommandsRepository);
        }

        public async Task<Result<bool>> ChangeUserRole(ChangeRoleCommand changeRoleCommand, CancellationToken cancellationToken)
        {
            var userResult = await _secretUserQueriesRepository.FindUser(changeRoleCommand.UserName, cancellationToken);
            if(userResult.IsFailed) 
            {
                return Result.Fail(userResult.Errors);
            }

            return  await _secretUserCommandsRepository.ChangeUserRole(userResult.Value, changeRoleCommand.RoleName, cancellationToken);
        }
    }
}
