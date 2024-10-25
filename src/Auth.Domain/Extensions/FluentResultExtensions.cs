using FluentResults;

namespace Auth.Domain.Extensions
{
    public static class FluentResultExtensions
    {
        public static string ToErrorString(this IResultBase result)
            => string.Join(';', result.Errors);
    }
}
