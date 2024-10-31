using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Services;
using Auth.Core.Resources;
using Auth.Domain.UseCases.User.Dto;
using SmallApiToolkit.Core.Extensions;
using SmallApiToolkit.Core.RequestHandlers;
using SmallApiToolkit.Core.Response;

namespace Auth.Core.UseCases.User.Queries
{
    internal class GetUserInfoQueryHandler : IHttpRequestHandler<UserInfoDto, EmptyRequest>
    {
        private readonly IUserService _userService;
        public GetUserInfoQueryHandler(IUserService userService)
        {
            _userService = Guard.Against.Null(userService);
        }
        public async Task<HttpDataResponse<UserInfoDto>> HandleAsync(EmptyRequest request, CancellationToken cancellationToken)
        {
            var userResult = await _userService.GetAuthorizedUser(cancellationToken);
            if (userResult.IsFailed)
            {
                return HttpDataResponses.AsInternalServerError<UserInfoDto>(ErrorMessages.UnableToGetUser);
            }

            return HttpDataResponses.AsOK(userResult.Value);
        }
    }
}
