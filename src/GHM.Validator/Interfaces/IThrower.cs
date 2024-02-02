using System.Runtime.CompilerServices;

namespace GHM.Validator.Interfaces;

public interface IThrower
{
    void SetException(Func<string, Exception> exceptionThrower);
    bool IfFalse(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    );
    bool IfTrue(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    );
    bool IfDefault<T>(T obj, string? message = null, [CallerArgumentExpression(nameof(obj))] string? paramName = null);
    bool IfNotNull(object? obj, string? message = null, [CallerArgumentExpression(nameof(obj))] string? paramName = null);
    bool IfNull(object? obj, string? message = null, [CallerArgumentExpression(nameof(obj))] string? paramName = null);
    bool IfNotEqual(
        object obj,
        object toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    );
    bool IfZero(int number, string? message = null, [CallerArgumentExpression(nameof(number))] string? paramName = null);
    bool IfZero(decimal number, string? message = null, [CallerArgumentExpression(nameof(number))] string? paramName = null);
    bool IfGreaterOrEqual(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );
    bool IfGreater(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );
    bool IfGreaterOrEqual(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );
    bool IfGreater(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );
    bool IfEmpty(string text, string? message = null, [CallerArgumentExpression(nameof(text))] string? paramName = null);
    bool IfNotParseToLong(
        string text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    );
    bool IfEmpty<T>(
        IEnumerable<T> list,
        string? message = null,
        [CallerArgumentExpression(nameof(list))] string? paramName = null
    );
    bool IfOlder(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    );
    bool IfOlderOrEqual(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    );
}
