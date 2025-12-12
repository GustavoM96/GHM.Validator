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
        return ThrowIfError(condition, GetErrorMessage(message, nameof(IfTrue), paramName, condition));
    }

    public bool IfFalse<TException>(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(!condition, GetErrorMessage(message, nameof(IfFalse), paramName, condition));
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
        return ThrowIfError(isDefault, GetErrorMessage(message, nameof(IfDefault), paramName, obj));
    }

    public bool IfNotNull<TException>(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(obj != null, GetErrorMessage(message, nameof(IfNotNull), paramName, obj));
    }

    public bool IfNull<TException>(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(obj == null, GetErrorMessage(message, nameof(IfNull), paramName, obj));
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
        return ThrowIfError(!obj.Equals(toCompare), GetErrorMessage(message, nameof(IfNotEqual), paramName, obj, toCompare));
    }

    public bool IfZero<TException>(
        int number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(number == 0, GetErrorMessage(message, nameof(IfZero), paramName, number));
    }

    public bool IfZero<TException>(
        decimal number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(number == 0, GetErrorMessage(message, nameof(IfZero), paramName, number));
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
            GetErrorMessage(message, nameof(IfGreaterOrEqual), paramName, number, toCompare)
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
        return ThrowIfError(number > toCompare, GetErrorMessage(message, nameof(IfGreater), paramName, number, toCompare));
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
            GetErrorMessage(message, nameof(IfGreaterOrEqual), paramName, number, toCompare)
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
        return ThrowIfError(number > toCompare, GetErrorMessage(message, nameof(IfGreater), paramName, number, toCompare));
    }

    public bool IfEmpty<TException>(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();
        return ThrowIfError(string.IsNullOrEmpty(text), GetErrorMessage(message, nameof(IfEmpty), paramName, text));
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
            GetErrorMessage(message, nameof(IfNotParseToLong), paramName, text)
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
        return ThrowIfError(!list.Any(), GetErrorMessage(message, nameof(IfEmpty), paramName, list));
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
        return ThrowIfError(date < toCompare, GetErrorMessage(message, nameof(IfOlder), paramName, date, toCompare));
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
        return ThrowIfError(date <= toCompare, GetErrorMessage(message, nameof(IfOlderOrEqual), paramName, date, toCompare));
    }

    public bool IfNotEmail<TException>(
        string? email,
        string? message = null,
        [CallerArgumentExpression(nameof(email))] string? paramName = null
    )
        where TException : Exception
    {
        _thrower = CreateThrower<TException>();

        if (string.IsNullOrEmpty(email))
        {
            return ThrowIfError(true, GetErrorMessage(message, nameof(IfNotEmail), paramName, email));
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
        return ThrowIfError(error, GetErrorMessage(message, nameof(IfNotEmail), paramName, email));
    }
}
