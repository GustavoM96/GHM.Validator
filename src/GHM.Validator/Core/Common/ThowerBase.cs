namespace GHM.Validator;

public abstract class ThowerBase
{
    protected static string GetDefaultErrorMessage(string validationName, string? paramName, object? value) =>
        $"Error to validate param: {paramName}. Value: {value}. ThrowerName: {validationName}";

    protected static string GetDefaultErrorMessage(
        string validationName,
        string? paramName,
        object? value,
        object? toCompare
    ) => $"Error to validate param: {paramName}. Value: {value}. Compare: {toCompare}. ThrowerName: {validationName}";
}
