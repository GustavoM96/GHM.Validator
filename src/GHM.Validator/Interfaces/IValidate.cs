using System.Runtime.CompilerServices;

namespace GHM.Validator.Interfaces;

/// <summary>
/// Interface for validation values based on various conditions.
/// </summary>
public interface IValidate
{
    /// <summary>
    /// Validates if the condition is true.
    /// </summary>
    /// <param name="condition">The condition to check.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfTrue(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    );

    /// <summary>
    /// Validates if the condition is false.
    /// </summary>
    /// <param name="condition">The condition to check.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfFalse(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    );

    /// <summary>
    /// Validates if the object is not the default value.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="obj">The object to check.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfNotDefault<T>(
        T obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    );

    /// <summary>
    /// Validates if the object is not null.
    /// </summary>
    /// <param name="obj">The object to check.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfNotNull(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    );

    /// <summary>
    /// Validates if the object is null.
    /// </summary>
    /// <param name="obj">The object to check.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfNull(object? obj, string? message = null, [CallerArgumentExpression(nameof(obj))] string? paramName = null);

    /// <summary>
    /// Validates if the object is equal to another object.
    /// </summary>
    /// <param name="obj">The object to check.</param>
    /// <param name="toCompare">The object to compare against.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfEqual(
        object obj,
        object toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    );

    /// <summary>
    /// Validates if the number is not zero.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfNotZero(
        int number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );

    /// <summary>
    /// Validates if the decimal number is not zero.
    /// </summary>
    /// <param name="number">The decimal number to check.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfNotZero(
        decimal number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );

    /// <summary>
    /// Validates if the number is greater than or equal to another number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <param name="toCompare">The number to compare against.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfGreaterOrEqual(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );

    /// <summary>
    /// Validates if the number is greater than another number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <param name="toCompare">The number to compare against.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfGreater(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );

    /// <summary>
    /// Validates if the decimal number is greater than or equal to another decimal number.
    /// </summary>
    /// <param name="number">The decimal number to check.</param>
    /// <param name="toCompare">The decimal number to compare against.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfGreaterOrEqual(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );

    /// <summary>
    /// Validates if the decimal number is greater than another decimal number.
    /// </summary>
    /// <param name="number">The decimal number to check.</param>
    /// <param name="toCompare">The decimal number to compare against.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfGreater(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );

    /// <summary>
    /// Validates if the text is not empty.
    /// </summary>
    /// <param name="text">The text to check.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfNotEmpty(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    );

    /// <summary>
    /// Validates if the text can be parsed to a long.
    /// </summary>
    /// <param name="text">The text to check.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfParseToLong(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    );

    /// <summary>
    /// Validates if the list is not empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the list.</typeparam>
    /// <param name="list">The list to check.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfNotEmpty<T>(
        IEnumerable<T> list,
        string? message = null,
        [CallerArgumentExpression(nameof(list))] string? paramName = null
    );

    /// <summary>
    /// Validates if the date is older than another date.
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <param name="toCompare">The date to compare against.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfOlder(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    );

    /// <summary>
    /// Validates if the date is older than or equal to another date.
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <param name="toCompare">The date to compare against.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfOlderOrEqual(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    );

    /// <summary>
    /// Validates if the email is in a valid format.
    /// </summary>
    /// <param name="email">The email to check.</param>
    /// <param name="message">Optional message for the validation.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>A Validation object.</returns>
    Validation IfEmail(
        string email,
        string? message = null,
        [CallerArgumentExpression(nameof(email))] string? paramName = null
    );
}
