using System.Net.Mail;
using System.Runtime.CompilerServices;
using GHM.Validator.Interfaces;

namespace GHM.Validator;

internal class Validate : ValidateBase, IValidate
{
    public Validation IfTrue(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
    {
        return condition
            ? Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfTrue), paramName, condition))
            : Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfTrue), paramName, condition));
    }

    public Validation IfFalse(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
    {
        return condition
            ? Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfFalse), paramName, condition))
            : Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfFalse), paramName, condition));
    }

    public Validation IfNotDefault<T>(
        T obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
    {
        bool isDefault = EqualityComparer<T>.Default.Equals(obj, default);
        return isDefault
            ? Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfNotDefault), paramName, obj))
            : Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfNotDefault), paramName, obj));
    }

    public Validation IfNotNull(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
    {
        return obj != null
            ? Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfNotNull), paramName, obj))
            : Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfNotNull), paramName, obj));
    }

    public Validation IfNull(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
    {
        return obj == null
            ? Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfNull), paramName, obj))
            : Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfNull), paramName, obj));
    }

    public Validation IfEqual(
        object obj,
        object toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
    {
        return obj.Equals(toCompare)
            ? Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfEqual), paramName, obj))
            : Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfEqual), paramName, obj));
    }

    public Validation IfNotZero(
        int number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return number != 0
            ? Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfNotZero), paramName, number))
            : Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfNotZero), paramName, number));
    }

    public Validation IfNotZero(
        decimal number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return number != 0
            ? Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfNotZero), paramName, number))
            : Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfNotZero), paramName, number));
    }

    public Validation IfGreaterOrEqual(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return number >= toCompare
            ? Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfGreaterOrEqual), paramName, number, toCompare))
            : Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfGreaterOrEqual), paramName, number, toCompare));
    }

    public Validation IfGreater(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return number > toCompare
            ? Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfGreater), paramName, number, toCompare))
            : Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfGreater), paramName, number, toCompare));
    }

    public Validation IfGreaterOrEqual(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return number >= toCompare
            ? Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfGreaterOrEqual), paramName, number, toCompare))
            : Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfGreaterOrEqual), paramName, number, toCompare));
    }

    public Validation IfGreater(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        return number > toCompare
            ? Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfGreater), paramName, number, toCompare))
            : Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfGreater), paramName, number, toCompare));
    }

    public Validation IfNotEmpty(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
    {
        return string.IsNullOrEmpty(text)
            ? Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfNotEmpty), paramName, text))
            : Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfNotEmpty), paramName, text));
    }

    public Validation IfParseToLong(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
    {
        return long.TryParse(text, out long _)
            ? Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfParseToLong), paramName, text))
            : Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfParseToLong), paramName, text));
    }

    public Validation IfNotEmpty<T>(
        IEnumerable<T> list,
        string? message = null,
        [CallerArgumentExpression(nameof(list))] string? paramName = null
    )
    {
        return list.Any()
            ? Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfNotEmpty), paramName, list))
            : Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfNotEmpty), paramName, list));
    }

    public Validation IfOlder(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    )
    {
        return date < toCompare
            ? Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfOlder), paramName, date, toCompare))
            : Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfOlder), paramName, date, toCompare));
    }

    public Validation IfOlderOrEqual(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    )
    {
        return date <= toCompare
            ? Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfOlderOrEqual), paramName, date, toCompare))
            : Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfOlderOrEqual), paramName, date, toCompare));
    }

    public Validation IfEmail(
        string? email,
        string? message = null,
        [CallerArgumentExpression(nameof(email))] string? paramName = null
    )
    {
        try
        {
            if (string.IsNullOrEmpty(email))
            {
                return Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfEmail), paramName, email));
            }
            MailAddress mailAddress = new(email);
            return Validation.Success(message ?? GetDefaultSuccessMessage(nameof(IfEmail), paramName, email));
        }
        catch (Exception)
        {
            return Validation.Error(message ?? GetDefaultErrorMessage(nameof(IfEmail), paramName, email));
        }
    }
}
