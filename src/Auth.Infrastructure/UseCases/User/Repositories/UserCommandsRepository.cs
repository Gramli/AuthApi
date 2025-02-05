﻿using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Repositories;
using Auth.Infrastructure.Abstractions;
using Auth.Infrastructure.Database.EFContext;
using Auth.Infrastructure.UseCases.User.Entities;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.UseCases.User.Repositories
{
    internal sealed class UserCommandsRepository : IUserCommandsRepository, ISecretUserCommandsRepository
    {
        private readonly UserContext _context;
        public UserCommandsRepository(UserContext userContext)
        {
            _context = Guard.Against.Null(userContext);
        }
        public async Task<int> AddUser(UserEntity userEntity, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return userEntity.Id;
        }

        public async Task<Result<bool>> ChangeUserRole(UserEntity user, RoleEntity role, CancellationToken cancellationToken)
        {
            try
            {
                user.Role = role;
                await _context.SaveChangesAsync(cancellationToken);
                return Result.Ok(true);
            }
            catch (DbUpdateException ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }
}
