using System.Runtime.CompilerServices;

namespace GHM.Validator.Interfaces;

/// <summary>
/// Interface for throwing exceptions based on various conditions with generic exception types.
/// </summary>
public interface IThrowerGeneric
{
    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the condition is false.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="condition">The condition to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfFalse<TException>(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the condition is true.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="condition">The condition to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfTrue<TException>(
        bool condition,
        string? message = null,
        [CallerArgumentExpression(nameof(condition))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the object is the default value.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <typeparam name="TObj">The type of the object.</typeparam>
    /// <param name="obj">The object to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfDefault<TException, TObj>(
        TObj obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the object is not null.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="obj">The object to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfNotNull<TException>(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the object is null.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="obj">The object to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfNull<TException>(
        object? obj,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the objects are not equal.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="obj">The first object to compare.</param>
    /// <param name="toCompare">The second object to compare.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfNotEqual<TException>(
        object obj,
        object toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(obj))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the number is zero.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="number">The number to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfZero<TException>(
        int number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the decimal number is zero.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="number">The decimal number to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfZero<TException>(
        decimal number,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the number is greater than or equal to the comparison value.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="number">The number to evaluate.</param>
    /// <param name="toCompare">The comparison value.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfGreaterOrEqual<TException>(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the number is greater than the comparison value.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="number">The number to evaluate.</param>
    /// <param name="toCompare">The comparison value.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfGreater<TException>(
        int number,
        int toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the decimal number is greater than or equal to the comparison value.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="number">The decimal number to evaluate.</param>
    /// <param name="toCompare">The comparison value.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfGreaterOrEqual<TException>(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the decimal number is greater than the comparison value.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="number">The decimal number to evaluate.</param>
    /// <param name="toCompare">The comparison value.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfGreater<TException>(
        decimal number,
        decimal toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(number))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the text is empty.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="text">The text to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfEmpty<TException>(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the text cannot be parsed to a long.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="text">The text to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfNotParseToLong<TException>(
        string? text,
        string? message = null,
        [CallerArgumentExpression(nameof(text))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the list is empty.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <typeparam name="TList">The type of the elements in the list.</typeparam>
    /// <param name="list">The list to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfEmpty<TException, TList>(
        IEnumerable<TList> list,
        string? message = null,
        [CallerArgumentExpression(nameof(list))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the date is older than the comparison date.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="date">The date to evaluate.</param>
    /// <param name="toCompare">The comparison date.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfOlder<TException>(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the date is older than or equal to the comparison date.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="date">The date to evaluate.</param>
    /// <param name="toCompare">The comparison date.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfOlderOrEqual<TException>(
        DateTime date,
        DateTime toCompare,
        string? message = null,
        [CallerArgumentExpression(nameof(date))] string? paramName = null
    )
        where TException : Exception;

    /// <summary>
    /// Throws an exception of type <typeparamref name="TException"/> if the email is not valid.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to throw.</typeparam>
    /// <param name="email">The email to evaluate.</param>
    /// <param name="message">The message for the exception.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>True if an exception is not thrown</returns>
    bool IfNotEmail<TException>(
        string? email,
        string? message = null,
        [CallerArgumentExpression(nameof(email))] string? paramName = null
    )
        where TException : Exception;
}
