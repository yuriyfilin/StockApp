namespace StockApp.Application.Extensions;

public static class EnumerableExtensions
{
    public static string JoinStrings(this IEnumerable<string> strings, string separator = "\n")
        => string.Join(separator, strings);
}