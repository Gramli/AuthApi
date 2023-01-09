using Auth.Domain.Http;
using System.Net;

namespace Auth.Domain.Http
{
    public class HttpDataResponse<T> : DataResponse<T>
    {
        public HttpStatusCode StatusCode { get; init; }

    }
}
