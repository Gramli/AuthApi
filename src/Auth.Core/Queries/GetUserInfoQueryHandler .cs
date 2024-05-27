using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Queries;
using Auth.Core.Abstractions.Repositories;
using Auth.Domain.Dtos;
using SmallApiToolkit.Core.Extensions;
using SmallApiToolkit.Core.Response;

namespace Auth.Core.Queries
{
    internal class GetUserInfoQueryHandler : IGetUserInfoQueryHandler
    {
        private readonly IUserQueriesRepository _userQueriesRepository;

        public GetUserInfoQueryHandler(IUserQueriesRepository userQueriesRepository)
        {
            _userQueriesRepository = Guard.Against.Null(userQueriesRepository);
        }
        public async Task<HttpDataResponse<IEnumerable<UserDto>>> HandleAsync(EmptyRequest request, CancellationToken cancellationToken)
        {
            var users = await _userQueriesRepository.GetUsers(cancellationToken);
            return HttpDataResponses.AsOK(users);
        }
    }
}
