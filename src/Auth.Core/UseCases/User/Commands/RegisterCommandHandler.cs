﻿using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Services;
using Auth.Core.Resources;
using Auth.Domain.UseCases.User.Commands;
using SmallApiToolkit.Core.Extensions;
using SmallApiToolkit.Core.RequestHandlers;
using SmallApiToolkit.Core.Response;
using Validot;

namespace Auth.Core.UseCases.User.Commands
{
    internal sealed class RegisterCommandHandler : IHttpRequestHandler<bool, RegisterCommand>
    {
        private readonly IAccountService _accountService;
        private readonly IValidator<RegisterCommand> _validator;

        public RegisterCommandHandler(IAccountService accountService, IValidator<RegisterCommand> validator)
        {
            _accountService = Guard.Against.Null(accountService);
            _validator = Guard.Against.Null(validator);
        }
        public async Task<HttpDataResponse<bool>> HandleAsync(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (!_validator.IsValid(request))
            {
                return HttpDataResponses.AsBadRequest<bool>(ErrorMessages.InvalidRequest);
            }

            var userResult = await _accountService.CreateNewUser(request, cancellationToken);

            if (userResult.IsFailed)
            {
                return HttpDataResponses.AsBadRequest<bool>(ErrorMessages.InvalidRegistration);
            }

            return HttpDataResponses.AsOK(true);
        }
    }
}
