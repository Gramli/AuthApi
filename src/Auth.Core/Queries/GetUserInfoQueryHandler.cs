using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Services;
using Auth.Core.Resources;
using Auth.Domain.Dtos;
using SmallApiToolkit.Core.Extensions;
using SmallApiToolkit.Core.RequestHandlers;
using SmallApiToolkit.Core.Response;
using System.Security.Principal;

namespace Auth.Core.Queries
{
    internal class GetUserInfoQueryHandler : IHttpRequestHandler<UserInfoDto, EmptyRequest>
    {
        private readonly IPrincipal _principal;
        private readonly IUserService _userService;
        public GetUserInfoQueryHandler(IPrincipal principal, IUserService userService)
        {
            _principal = Guard.Against.Null(principal);
            Guard.Against.Null(_principal.Identity);
            _userService = Guard.Against.Null(userService);
        }
        public async Task<HttpDataResponse<UserInfoDto>> HandleAsync(EmptyRequest request, CancellationToken cancellationToken)
        {
            var userResult = await _userService.GetUser(_principal.Identity!.Name!, cancellationToken);
            if (userResult.IsFailed)
            {
                return HttpDataResponses.AsInternalServerError<UserInfoDto>(ErrorMessages.UnableToGetUser);
            }

            return HttpDataResponses.AsOK(userResult.Value);
        }
    }
}
