using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Services;
using Auth.Domain.Commands;
using Auth.Domain.Dtos;
using Auth.Domain.Resources;
using Auth.Infrastructure.Abstractions;
using Auth.Infrastructure.Database.EFContext.Entities;
using Auth.Infrastructure.Extensions;
using FluentResults;
using Mapster;

namespace Auth.Infrastructure.Services
{
    internal class AccountService : IAccountService
    {
        private readonly ISecretUserQueriesRepository _secretUserQueriesRepository;
        private readonly ISecretUserCommandsRepository _secretUserCommandsRepository;

        public AccountService(ISecretUserQueriesRepository secretUserQueriesRepository, ISecretUserCommandsRepository secretUserCommandsRepository)
        {
            _secretUserQueriesRepository = Guard.Against.Null(secretUserQueriesRepository);
            _secretUserCommandsRepository = Guard.Against.Null(secretUserCommandsRepository);
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

            var userEntity = registerCommand.Adapt<UserEntity>();

            //TODO ADD DEFAULT USER ROLE
            var userId = await _secretUserCommandsRepository.AddUser(userEntity, cancellationToken);

            return Result.Ok(userId);
        }
    }
}
