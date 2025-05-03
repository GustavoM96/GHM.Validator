using System.Runtime.CompilerServices;

namespace GHM.Validator.Interfaces;

/// <summary>
/// Interface for throwing exceptions based on various conditions.
/// </summary>
public interface IThrower : IThrowerGeneric
{
    /// <summary>
    /// Sets the exception thrower function.
    /// </summary>
    /// <param name="exceptionThrower">Function to create an exception based on a message.</param>
    /// <returns>True if an exception is not thrown</returns>
    IThrower WithException(Func<string, Exception> exceptionThrower);

    /// <summary>
    /// Throws an exception if the condition is false.
    /// </summary>
    /// <param name="condition">The condition to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfFalse(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    );

    /// <summary>
    /// Throws an exception if the condition is true.
    /// </summary>
    /// <param name="condition">The condition to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfTrue(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    );

    /// <summary>
    /// Throws an exception if the object is the default value.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="obj">The object to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfDefault<T>(T obj, string? message = null, [CallerArgumentExpression(nameof(obj))] string? paramName = null);

    /// <summary>
    /// Throws an exception if the object is not null.
    /// </summary>
    /// <param name="obj">The object to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfNotNull(object? obj, string? message = null, [CallerArgumentExpression(nameof(obj))] string? paramName = null);

    /// <summary>
    /// Throws an exception if the object is null.
    /// </summary>
    /// <param name="obj">The object to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfNull(object? obj, string? message = null, [CallerArgumentExpression(nameof(obj))] string? paramName = null);

    /// <summary>
    /// Throws an exception if the objects are not equal.
    /// </summary>
    /// <param name="obj">The first object to compare.</param>
    /// <param name="toCompare">The second object to compare.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfNotEqual(
        object obj,
        object toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    );

    /// <summary>
    /// Throws an exception if the number is zero.
    /// </summary>
    /// <param name="number">The number to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfZero(int number, string? message = null, [CallerArgumentExpression(nameof(number))] string? paramName = null);

    /// <summary>
    /// Throws an exception if the decimal number is zero.
    /// </summary>
    /// <param name="number">The decimal number to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfZero(decimal number, string? message = null, [CallerArgumentExpression(nameof(number))] string? paramName = null);

    /// <summary>
    /// Throws an exception if the number is greater than or equal to the comparison value.
    /// </summary>
    /// <param name="number">The number to evaluate.</param>
    /// <param name="toCompare">The comparison value.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfGreaterOrEqual(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );

    /// <summary>
    /// Throws an exception if the number is greater than the comparison value.
    /// </summary>
    /// <param name="number">The number to evaluate.</param>
    /// <param name="toCompare">The comparison value.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfGreater(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );

    /// <summary>
    /// Throws an exception if the decimal number is greater than or equal to the comparison value.
    /// </summary>
    /// <param name="number">The decimal number to evaluate.</param>
    /// <param name="toCompare">The comparison value.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfGreaterOrEqual(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );

    /// <summary>
    /// Throws an exception if the decimal number is greater than the comparison value.
    /// </summary>
    /// <param name="number">The decimal number to evaluate.</param>
    /// <param name="toCompare">The comparison value.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfGreater(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    );

    /// <summary>
    /// Throws an exception if the text is empty.
    /// </summary>
    /// <param name="text">The text to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfEmpty(string? text, string? message = null, [CallerArgumentExpression(nameof(text))] string? paramName = null);

    /// <summary>
    /// Throws an exception if the text cannot be parsed to a long.
    /// </summary>
    /// <param name="text">The text to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfNotParseToLong(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    );

    /// <summary>
    /// Throws an exception if the list is empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the list.</typeparam>
    /// <param name="list">The list to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfEmpty<T>(
        IEnumerable<T> list,
        string? message = null,
        [CallerArgumentExpression(nameof(list))] string? paramName = null
    );

    /// <summary>
    /// Throws an exception if the date is older than the comparison date.
    /// </summary>
    /// <param name="date">The date to evaluate.</param>
    /// <param name="toCompare">The comparison date.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfOlder(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    );

    /// <summary>
    /// Throws an exception if the date is older than or equal to the comparison date.
    /// </summary>
    /// <param name="date">The date to evaluate.</param>
    /// <param name="toCompare">The comparison date.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfOlderOrEqual(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    );

    /// <summary>
    /// Throws an exception if the email is not valid.
    /// </summary>
    /// <param name="email">The email to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfNotEmail(
        string? email,
        string? message = null,
        [CallerArgumentExpression(nameof(email))] string? paramName = null
    );
}
