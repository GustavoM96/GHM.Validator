using System.Net.Mail;
using System.Runtime.CompilerServices;
using GHM.Validator;
using GHM.Validator.Core.Enum;
using GHM.Validator.Interfaces;

internal class Validate : ValidateBase, IValidate
{
    public Validation IfTrue(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
    {
        var type = ValidationType.IfTrue;
        return condition
            ? Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, condition))
            : Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, condition));
    }

    public Validation IfFalse(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
    {
        var type = ValidationType.IfFalse;
        return condition
            ? Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, condition))
            : Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, condition));
    }

    public Validation IfNotDefault<T>(
        T obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
    {
        var type = ValidationType.IfNotDefault;
        bool isDefault = EqualityComparer<T>.Default.Equals(obj, default);
        return isDefault
            ? Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, obj))
            : Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, obj));
    }

    public Validation IfNotNull(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
    {
        var type = ValidationType.IfNotNull;
        return obj != null
            ? Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, obj))
            : Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, obj));
    }

    public Validation IfNull(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
    {
        var type = ValidationType.IfNull;
        return obj == null
            ? Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, obj))
            : Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, obj));
    }

    public Validation IfEqual(
        object obj,
        object toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
    {
        var type = ValidationType.IfEqual;
        return obj.Equals(toCompare)
            ? Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, obj))
            : Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, obj));
    }

    public Validation IfNotZero(
        int number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        var type = ValidationType.IfNotZero;
        return number != 0
            ? Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, number))
            : Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, number));
    }

    public Validation IfNotZero(
        decimal number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        var type = ValidationType.IfNotZero;
        return number != 0
            ? Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, number))
            : Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, number));
    }

    public Validation IfGreaterOrEqual(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        var type = ValidationType.IfGreaterOrEqual;
        return number >= toCompare
            ? Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, number, toCompare))
            : Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, number, toCompare));
    }

    public Validation IfGreater(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        var type = ValidationType.IfGreater;
        return number > toCompare
            ? Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, number, toCompare))
            : Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, number, toCompare));
    }

    public Validation IfGreaterOrEqual(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        var type = ValidationType.IfGreaterOrEqual;
        return number >= toCompare
            ? Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, number, toCompare))
            : Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, number, toCompare));
    }

    public Validation IfGreater(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
    {
        var type = ValidationType.IfGreater;
        return number > toCompare
            ? Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, number, toCompare))
            : Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, number, toCompare));
    }

    public Validation IfNotEmpty(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
    {
        var type = ValidationType.IfNotEmpty;
        return string.IsNullOrEmpty(text)
            ? Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, text))
            : Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, text));
    }

    public Validation IfParseToLong(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
    {
        var type = ValidationType.IfParseToLong;
        return long.TryParse(text, out long _)
            ? Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, text))
            : Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, text));
    }

    public Validation IfNotEmpty<T>(
        IEnumerable<T> list,
        string? message = null,
        [CallerArgumentExpression(nameof(list))] string? paramName = null
    )
    {
        var type = ValidationType.IfNotEmpty;
        return list.Any()
            ? Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, list))
            : Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, list));
    }

    public Validation IfOlder(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    )
    {
        var type = ValidationType.IfOlder;
        return date < toCompare
            ? Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, date, toCompare))
            : Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, date, toCompare));
    }

    public Validation IfOlderOrEqual(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    )
    {
        var type = ValidationType.IfOlderOrEqual;
        return date <= toCompare
            ? Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, date, toCompare))
            : Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, date, toCompare));
    }

    public Validation IfEmail(
        string? email,
        string? message = null,
        [CallerArgumentExpression(nameof(email))] string? paramName = null
    )
    {
        var type = ValidationType.IfEmail;
        try
        {
            if (string.IsNullOrEmpty(email))
            {
                return Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, email));
            }
            MailAddress mailAddress = new(email);
            return Validation.Success(type, GetSuccessMessage(message, type.ToString(), paramName, email));
        }
        catch (Exception)
        {
            return Validation.Error(type, GetErrorMessage(message, type.ToString(), paramName, email));
        }
    }
}
