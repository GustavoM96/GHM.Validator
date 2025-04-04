using System.Runtime.CompilerServices;

namespace GHM.Validator.Interfaces;

public interface IThrowerGeneric
{
    bool IfFalse<TException>(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
        where TException : Exception;
    bool IfTrue<TException>(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
        where TException : Exception;
    bool IfDefault<TException, TObj>(
        TObj obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
        where TException : Exception;
    bool IfNotNull<TException>(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
        where TException : Exception;
    bool IfNull<TException>(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
        where TException : Exception;
    bool IfNotEqual<TException>(
        object obj,
        object toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
        where TException : Exception;
    bool IfZero<TException>(
        int number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception;
    bool IfZero<TException>(
        decimal number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception;
    bool IfGreaterOrEqual<TException>(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception;
    bool IfGreater<TException>(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception;
    bool IfGreaterOrEqual<TException>(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception;
    bool IfGreater<TException>(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception;
    bool IfEmpty<TException>(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
        where TException : Exception;
    bool IfNotParseToLong<TException>(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
        where TException : Exception;
    bool IfEmpty<TException, TList>(
        IEnumerable<TList> list,
        string? message = null,
        [CallerArgumentExpression(nameof(list))] string? paramName = null
    )
        where TException : Exception;
    bool IfOlder<TException>(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    )
        where TException : Exception;
    bool IfOlderOrEqual<TException>(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    )
        where TException : Exception;
    bool IfNotEmail<TException>(
        string email,
        string? message = null,
        [CallerArgumentExpression(nameof(email))] string? paramName = null
    )
        where TException : Exception;
}
