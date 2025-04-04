using System.Net.Mail;
using System.Runtime.CompilerServices;
using GHM.Validator.Interfaces;

namespace GHM.Validator;

internal partial class Thrower : IThrowerGeneric
{
    private Func<string, Exception> CreateThrower<TException>()
        where TException : Exception
    {
        return (string message) => (TException)Activator.CreateInstance(typeof(TException), message)!;
    }

    public bool IfTrue<TException>(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(condition, message ?? GetDefaultErrorMessage(nameof(IfTrue), paramName, condition));
    }

    public bool IfFalse<TException>(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(!condition, message ?? GetDefaultErrorMessage(nameof(IfFalse), paramName, condition));
    }

    public bool IfDefault<TException, TObj>(
        TObj obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
        where TException : Exception
    {
        bool isDefault = EqualityComparer<TObj>.Default.Equals(obj, default);
        _thrower = CreateThrower<TException>();
        return ThrowIfError(isDefault, message ?? GetDefaultErrorMessage(nameof(IfDefault), paramName, obj));
    }

    public bool IfNotNull<TException>(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(obj != null, message ?? GetDefaultErrorMessage(nameof(IfNotNull), paramName, obj));
    }

    public bool IfNull<TException>(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(obj == null, message ?? GetDefaultErrorMessage(nameof(IfNull), paramName, obj));
    }

    public bool IfNotEqual<TException>(
        object obj,
        object toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(
            !obj.Equals(toCompare),
            message ?? GetDefaultErrorMessage(nameof(IfNotEqual), paramName, obj, toCompare)
        );
    }

    public bool IfZero<TException>(
        int number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(number == 0, message ?? GetDefaultErrorMessage(nameof(IfZero), paramName, number));
    }

    public bool IfZero<TException>(
        decimal number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(number == 0, message ?? GetDefaultErrorMessage(nameof(IfZero), paramName, number));
    }

    public bool IfGreaterOrEqual<TException>(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(
            number >= toCompare,
            message ?? GetDefaultErrorMessage(nameof(IfGreaterOrEqual), paramName, number, toCompare)
        );
    }

    public bool IfGreater<TException>(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(
            number > toCompare,
            message ?? GetDefaultErrorMessage(nameof(IfGreater), paramName, number, toCompare)
        );
    }

    public bool IfGreaterOrEqual<TException>(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(
            number >= toCompare,
            message ?? GetDefaultErrorMessage(nameof(IfGreaterOrEqual), paramName, number, toCompare)
        );
    }

    public bool IfGreater<TException>(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(
            number > toCompare,
            message ?? GetDefaultErrorMessage(nameof(IfGreater), paramName, number, toCompare)
        );
    }

    public bool IfEmpty<TException>(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(string.IsNullOrEmpty(text), message ?? GetDefaultErrorMessage(nameof(IfEmpty), paramName, text));
    }

    public bool IfNotParseToLong<TException>(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(
            !long.TryParse(text, out long _),
            message ?? GetDefaultErrorMessage(nameof(IfNotParseToLong), paramName, text)
        );
    }

    public bool IfEmpty<TException, TList>(
        IEnumerable<TList> list,
        string? message = null,
        [CallerArgumentExpression(nameof(list))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(!list.Any(), message ?? GetDefaultErrorMessage(nameof(IfEmpty), paramName, list));
    }

    public bool IfOlder<TException>(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(
            date < toCompare,
            message ?? GetDefaultErrorMessage(nameof(IfOlder), paramName, date, toCompare)
        );
    }

    public bool IfOlderOrEqual<TException>(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(
            date <= toCompare,
            message ?? GetDefaultErrorMessage(nameof(IfOlderOrEqual), paramName, date, toCompare)
        );
    }

    public bool IfNotEmail<TException>(
        string email,
        string? message = null,
        [CallerArgumentExpression(nameof(email))] string? paramName = null
    )
        where TException : Exception
    {
        bool error = default;
        try
        {
            MailAddress mailAddress = new(email);
            error = false;
        }
        catch (Exception)
        {
            error = true;
        }

        _thrower = CreateThrower<TException>();
        return ThrowIfError(error, message ?? GetDefaultErrorMessage(nameof(IfNotEmail), paramName, email));
    }
}
