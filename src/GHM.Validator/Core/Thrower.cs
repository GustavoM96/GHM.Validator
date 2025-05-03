using System.Net.Mail;
using System.Runtime.CompilerServices;
using GHM.Validator.Interfaces;

namespace GHM.Validator;

internal partial class Thrower : ThowerBase, IThrower
{
    public Thrower(Func<string, Exception> exceptionThrower)
        : base(exceptionThrower) { }

    public IThrower WithException(Func<string, Exception> exceptionThrower)
    {
        _thrower = exceptionThrower;
        return this;
    }

    public bool IfTrue(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
    {
        return ThrowIfError(condition, message ?? GetDefaultErrorMessage(nameof(IfTrue), paramName, condition));
    }

    public bool IfFalse(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
    {
        return ThrowIfError(!condition, message ?? GetDefaultErrorMessage(nameof(IfFalse), paramName, condition));
    }

    public bool IfDefault<T>(T obj, string? message = null, [CallerArgumentExpression(nameof(obj))] string? paramName = null)
    {
        bool isDefault = EqualityComparer<T>.Default.Equals(obj, default);
        return ThrowIfError(isDefault, message ?? GetDefaultErrorMessage(nameof(IfDefault), paramName, obj));
    }

    public bool IfNotNull(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
    {
        return ThrowIfError(obj != null, message ?? GetDefaultErrorMessage(nameof(IfNotNull), paramName, obj));
    }

    public bool IfNull(object? obj, string? message = null, [CallerArgumentExpression(nameof(obj))] string? paramName = null)
    {
        return ThrowIfError(obj == null, message ?? GetDefaultErrorMessage(nameof(IfNull), paramName, obj));
    }

    public bool IfNotEqual(
        object obj,
        object toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
    {
        return ThrowIfError(
            !obj.Equals(toCompare),
            message ?? GetDefaultErrorMessage(nameof(IfNotEqual), paramName, obj, toCompare)
        );
    }

    public bool IfZero(
        int number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return ThrowIfError(number == 0, message ?? GetDefaultErrorMessage(nameof(IfZero), paramName, number));
    }

    public bool IfZero(
        decimal number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return ThrowIfError(number == 0, message ?? GetDefaultErrorMessage(nameof(IfZero), paramName, number));
    }

    public bool IfGreaterOrEqual(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return ThrowIfError(
            number >= toCompare,
            message ?? GetDefaultErrorMessage(nameof(IfGreaterOrEqual), paramName, number, toCompare)
        );
    }

    public bool IfGreater(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return ThrowIfError(
            number > toCompare,
            message ?? GetDefaultErrorMessage(nameof(IfGreater), paramName, number, toCompare)
        );
    }

    public bool IfGreaterOrEqual(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return ThrowIfError(
            number >= toCompare,
            message ?? GetDefaultErrorMessage(nameof(IfGreaterOrEqual), paramName, number, toCompare)
        );
    }

    public bool IfGreater(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return ThrowIfError(
            number > toCompare,
            message ?? GetDefaultErrorMessage(nameof(IfGreater), paramName, number, toCompare)
        );
    }

    public bool IfEmpty(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
    {
        return ThrowIfError(string.IsNullOrEmpty(text), message ?? GetDefaultErrorMessage(nameof(IfEmpty), paramName, text));
    }

    public bool IfNotParseToLong(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
    {
        return ThrowIfError(
            !long.TryParse(text, out long _),
            message ?? GetDefaultErrorMessage(nameof(IfNotParseToLong), paramName, text)
        );
    }

    public bool IfEmpty<T>(
        IEnumerable<T> list,
        string? message = null,
        [CallerArgumentExpression(nameof(list))] string? paramName = null
    )
    {
        return ThrowIfError(!list.Any(), message ?? GetDefaultErrorMessage(nameof(IfEmpty), paramName, list));
    }

    public bool IfOlder(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    )
    {
        return ThrowIfError(
            date < toCompare,
            message ?? GetDefaultErrorMessage(nameof(IfOlder), paramName, date, toCompare)
        );
    }

    public bool IfOlderOrEqual(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    )
    {
        return ThrowIfError(
            date <= toCompare,
            message ?? GetDefaultErrorMessage(nameof(IfOlderOrEqual), paramName, date, toCompare)
        );
    }

    public bool IfNotEmail(
        string? email,
        string? message = null,
        [CallerArgumentExpression(nameof(email))] string? paramName = null
    )
    {
        if (string.IsNullOrEmpty(email))
        {
            return ThrowIfError(true, message ?? GetDefaultErrorMessage(nameof(IfNotEmail), paramName, email));
        }

        bool error = false;
        try
        {
            MailAddress mailAddress = new(email);
        }
        catch (Exception)
        {
            error = true;
        }
        return ThrowIfError(error, message ?? GetDefaultErrorMessage(nameof(IfNotEmail), paramName, email));
    }
}
