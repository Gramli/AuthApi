using Auth.Domain.Http;

namespace Auth.Core.Abstractions
{
    public interface IRequestHandler<TResponse, in TRequest>
    {
        Task<HttpDataResponse<TResponse>> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }
}
