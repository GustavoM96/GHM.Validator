namespace GHM.Validator.Extensions;

public class GhmValidatorConfig
{
    public Func<string, Exception> ExceptionThrower { get; set; } = message => new ArgumentException(message);
}
