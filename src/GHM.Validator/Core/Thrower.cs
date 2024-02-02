using System.Runtime.CompilerServices;
using GHM.Validator.Interfaces;

namespace GHM.Validator;

public class Thrower : ThowerBase, IThrower
{
    public static Thrower Create(Func<string, Exception> exceptionThrower)
    {
        var thrower = new Thrower();
        thrower.SetException(exceptionThrower);
        return thrower;
    }

    private Func<string, Exception> _thrower = (string message) => new ArgumentException(message);

    public void SetException(Func<string, Exception> exceptionThrower) => _thrower = exceptionThrower;

    public bool IfTrue(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
    {
        return condition ? throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfTrue), paramName, condition)) : true;
    }

    public bool IfFalse(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
    {
        return condition ? true : throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfFalse), paramName, condition));
    }

    public bool IfDefault<T>(T obj, string? message = null, [CallerArgumentExpression(nameof(obj))] string? paramName = null)
    {
        var isDefault = EqualityComparer<T>.Default.Equals(obj, default);
        return isDefault ? throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfDefault), paramName, obj)) : true;
    }

    public bool IfNotNull(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
    {
        return obj != null ? throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfNotNull), paramName, obj)) : true;
    }

    public bool IfNull(object? obj, string? message = null, [CallerArgumentExpression(nameof(obj))] string? paramName = null)
    {
        return obj == null ? throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfNull), paramName, obj)) : true;
    }

    public bool IfNotEqual(
        object obj,
        object toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
    {
        return obj.Equals(toCompare)
            ? true
            : throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfNotEqual), paramName, obj, toCompare));
    }

    public bool IfZero(
        int number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return number == 0 ? throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfZero), paramName, number)) : true;
    }

    public bool IfZero(
        decimal number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return number == 0 ? throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfZero), paramName, number)) : true;
    }

    public bool IfGreaterOrEqual(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return number >= toCompare
            ? throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfGreaterOrEqual), paramName, number, toCompare))
            : true;
    }

    public bool IfGreater(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return number > toCompare
            ? throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfGreater), paramName, number, toCompare))
            : true;
    }

    public bool IfGreaterOrEqual(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return number >= toCompare
            ? throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfGreaterOrEqual), paramName, number, toCompare))
            : true;
    }

    public bool IfGreater(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return number > toCompare
            ? throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfGreater), paramName, number, toCompare))
            : true;
    }

    public bool IfEmpty(
        string text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
    {
        return string.IsNullOrEmpty(text)
            ? throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfEmpty), paramName, text))
            : true;
    }

    public bool IfNotParseToLong(
        string text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
    {
        return long.TryParse(text, out var _)
            ? true
            : throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfNotParseToLong), paramName, text));
    }

    public bool IfEmpty<T>(
        IEnumerable<T> list,
        string? message = null,
        [CallerArgumentExpression(nameof(list))] string? paramName = null
    )
    {
        return list.Any() ? true : throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfEmpty), paramName, list));
    }

    public bool IfOlder(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    )
    {
        return date < toCompare
            ? throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfOlder), paramName, date, toCompare))
            : true;
    }

    public bool IfOlderOrEqual(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    )
    {
        return date <= toCompare
            ? throw _thrower(message ?? GetDefaultErrorMessage(nameof(IfOlderOrEqual), paramName, date, toCompare))
            : true;
    }
}
