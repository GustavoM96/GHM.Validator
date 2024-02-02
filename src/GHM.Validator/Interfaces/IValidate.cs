using System.Runtime.CompilerServices;

namespace GHM.Validator.Interfaces;

public interface IValidate
{
    Validation IfTrue(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    );
    Validation IfFalse(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    );
    Validation IfNotDefault<T>(
        T obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    );
    Validation IfNotNull(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    );
    Validation IfNull(object? obj, string? message = null, [CallerArgumentExpression(nameof(obj))] string? paramName = null);
    Validation IfEqual(
        object obj,
        object toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    );
    Validation IfNotZero(
        int number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );
    Validation IfNotZero(
        decimal number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );
    Validation IfGreaterOrEqual(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );
    Validation IfGreater(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );
    Validation IfGreaterOrEqual(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );
    Validation IfGreater(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );
    Validation IfNotEmpty(
        string text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    );
    Validation IfParseToLong(
        string text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    );
    Validation IfNotEmpty<T>(
        IEnumerable<T> list,
        string? message = null,
        [CallerArgumentExpression(nameof(list))] string? paramName = null
    );
    Validation IfOlder(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    );
    Validation IfOlderOrEqual(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    );
}
