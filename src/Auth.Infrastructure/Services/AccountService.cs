using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Services;
using Auth.Core.Resources;
using Auth.Domain.UseCases.User.Commands;
using Auth.Domain.UseCases.User.Dto;
using Auth.Infrastructure.Abstractions;
using Auth.Infrastructure.Extensions;
using Auth.Infrastructure.UseCases.User.Entities;
using FluentResults;
using Mapster;

namespace Auth.Infrastructure.Services
{
    internal sealed class AccountService : IAccountService
    {
        private readonly IUserQueriesRepository _secretUserQueriesRepository;
        private readonly IUserCommandsRepository _secretUserCommandsRepository;
        private readonly IRoleQueriesRepository _secretRoleQueriesRepository;

        public AccountService(
            IUserQueriesRepository secretUserQueriesRepository, 
            IUserCommandsRepository secretUserCommandsRepository,
            IRoleQueriesRepository secretRoleQueriesRepository)
        {
            _secretUserQueriesRepository = Guard.Against.Null(secretUserQueriesRepository);
            _secretUserCommandsRepository = Guard.Against.Null(secretUserCommandsRepository);
            _secretRoleQueriesRepository = Guard.Against.Null(secretRoleQueriesRepository);
        }
        public async Task<Result<UserDto>> FindUser(LoginCommand loginCommand, CancellationToken cancellationToken)
        {
            var userEntityResult = await _secretUserQueriesRepository.FindUser(loginCommand.Username, cancellationToken);
            if (userEntityResult.IsFailed) 
            {
                return Result.Fail<UserDto>(ErrorMessages.InvalidUsernameOrPassword);
            }

            var isPasswordVerified = PasswordHasher.VerifyPassword(loginCommand.Password, userEntityResult.Value.Password);

            if(isPasswordVerified)
            {
                return Result.Ok(userEntityResult.Value.Adapt<UserDto>());
            }

            return Result.Fail<UserDto>(ErrorMessages.InvalidUsernameOrPassword);

        }

        public async Task<Result<int>> CreateNewUser(RegisterCommand registerCommand, CancellationToken cancellationToken)
        {
            var userEntityResult = await _secretUserQueriesRepository.FindUser(registerCommand.Username, cancellationToken);
            if (userEntityResult.IsSuccess)
            {
                return Result.Fail<int>(ErrorMessages.InvalidUsernameOrEmail);
            }

            var roleEntityResult = await _secretRoleQueriesRepository.GetRoleEntity("user", cancellationToken);

            if (roleEntityResult.IsFailed) 
            {
                return Result.Fail<int>(ErrorMessages.InvalidRequest);
            }

            var userEntity = new UserEntity
            {
                Username = registerCommand.Username,
                Email = registerCommand.Email,
                Password = PasswordHasher.HashPassword(registerCommand.Password),
                Role = roleEntityResult.Value
            };

            var userId = await _secretUserCommandsRepository.AddUser(userEntity, cancellationToken);

            return Result.Ok(userId);
        }
    }
}
