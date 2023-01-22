namespace File.Domain.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> values, Action<T> action)
        {
            foreach(var item in values)
            {
                action(item);
            }
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> values, Func<T, Task> action)
        {
            foreach (var item in values)
            {
                await action(item);
            }
        }

        public static bool HasAny<T>(this IEnumerable<T> values)
        {
            return values?.Any() ?? false;
        }
    }
}
