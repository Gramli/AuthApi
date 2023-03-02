
using Auth.Core.Abstractions;

namespace Auth.Api.Extensions
{
    internal static class IHandlerExtension
    {
        internal static async Task<IResult> SendAsync<TResponse, TRequest>(this IRequestHandler<TResponse, TRequest> requestHandler, TRequest request, CancellationToken cancellationToken)
        {
            var response = await requestHandler.HandleAsync(request, cancellationToken);
            return Results.Json(response.Data, statusCode: (int)response.StatusCode);
        }
    }
}
