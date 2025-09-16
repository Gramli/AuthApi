using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Services;
using Auth.Domain.UseCases.User.Commands;
using Auth.Domain.UseCases.User.Dto;
using Auth.Infrastructure.Abstractions;
using FluentResults;
using System.Security.Principal;

namespace Auth.Infrastructure.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly ISecretUserQueriesRepository _secretUserQueriesRepository;
        private readonly ISecretUserCommandsRepository _secretUserCommandsRepository;
        private readonly ISecretRoleQueriesRepository _secretRoleQueriesRepository;
        private readonly IPrincipal _principal;

        public UserService(
            ISecretUserQueriesRepository secretUserQueriesRepository,
            ISecretUserCommandsRepository secretUserCommandsRepository, 
            ISecretRoleQueriesRepository secretRoleQueriesRepository,
            IPrincipal principal)
        {
            _secretUserQueriesRepository = Guard.Against.Null(secretUserQueriesRepository);
            _secretUserCommandsRepository = Guard.Against.Null(secretUserCommandsRepository);
            _secretRoleQueriesRepository = Guard.Against.Null(secretRoleQueriesRepository);
            _principal = Guard.Against.Null(principal);
            Guard.Against.Null(_principal.Identity);
        }

        public async Task<Result<bool>> ChangeUserRole(ChangeRoleCommand changeRoleCommand, CancellationToken cancellationToken)
        {
            var userResult = await _secretUserQueriesRepository.GetUser(changeRoleCommand.Id, cancellationToken);
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

        public async Task<Result<UserInfoDto>> FindUser(string name, CancellationToken cancellationToken)
        {
            var userResult = await _secretUserQueriesRepository.FindUser(name, cancellationToken);

            if (userResult.IsFailed)
            {
                return Result.Fail(userResult.Errors);
            }

            return Result.Ok(new UserInfoDto(userResult.Value.Id, userResult.Value.Username, userResult.Value.Role.Role, userResult.Value.Email));
        }

        public async Task<Result<UserInfoDto>> GetAuthorizedUser(CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_principal!.Identity!.Name))
            {
                return Result.Fail("No identity name!");
            }

            return await FindUser(_principal!.Identity!.Name!, cancellationToken);
        }

        public async Task<Result<UserInfoDto>> GetUser(int id, CancellationToken cancellationToken)
        {
            var userResult = await _secretUserQueriesRepository.GetUser(id, cancellationToken);

            if (userResult.IsFailed)
            {
                return Result.Fail(userResult.Errors);
            }

            return Result.Ok(new UserInfoDto(userResult.Value.Id, userResult.Value.Username, userResult.Value.Role.Role, userResult.Value.Email));
        }
    }
}
