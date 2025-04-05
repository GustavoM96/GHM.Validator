namespace GHM.Validator.Extensions;

/// <summary>
/// Represents the configuration for GHM Validator.
/// </summary>
public class GhmValidatorConfig
{
    /// <summary>
    /// Gets or sets the function that throws an exception with the specified message.
    /// </summary>
    public Func<string, Exception> ExceptionThrower { get; set; } = message => new ArgumentException(message);
}
