namespace Auth.Domain.Http
{
    public class DataResponse<T>
    {
        public T? Data { get; init; }

        public IList<string> Errors { get; init; } = new List<string>();
    }
}
