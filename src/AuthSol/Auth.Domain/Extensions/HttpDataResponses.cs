using Auth.Domain.Http;

namespace Auth.Domain.Extensions
{
    public static class HttpDataResponses
    {
        public static HttpDataResponse<T> AsBadRequest<T>(IEnumerable<string> errorMessages)
        {
            return new HttpDataResponse<T>
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Errors = errorMessages.ToList()
            };
        }

        public static HttpDataResponse<T> AsBadRequest<T>(string errorMessages)
        {
            return new HttpDataResponse<T>
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Errors = new List<string> { errorMessages }
            };
        }

        public static HttpDataResponse<T> AsInternalServerError<T>(IEnumerable<string> errorMessages)
        {
            return new HttpDataResponse<T>
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Errors = errorMessages.ToList()
            };
        }

        public static HttpDataResponse<T> AsInternalServerError<T>(string errorMessage)
        {
            return new HttpDataResponse<T>
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Errors = new List<string> { errorMessage }
            };
        }

        public static HttpDataResponse<T> AsOK<T>(T data)
        {
            return new HttpDataResponse<T>
            {
                Data = data,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }

        public static HttpDataResponse<T> AsOK<T>(T data, IEnumerable<string> errorMessages)
        {
            return new HttpDataResponse<T>
            {
                Data = data,
                StatusCode = System.Net.HttpStatusCode.OK,
                Errors = errorMessages.ToList()
            };
        }

        public static HttpDataResponse<T> AsNoContent<T>()
        {
            return new HttpDataResponse<T>
            {
                StatusCode = System.Net.HttpStatusCode.NoContent,
            };
        }
    }
}
