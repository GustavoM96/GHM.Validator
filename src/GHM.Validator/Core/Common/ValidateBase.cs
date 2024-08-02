namespace GHM.Validator;

internal abstract class ValidateBase
{
    protected static string GetDefaultErrorMessage(string validationName, string? paramName, object? value) =>
        $"Error to validate param: {paramName}. Value: {value}. ValidationName: {validationName}";

    protected static string GetDefaultSuccessMessage(string validationName, string? paramName, object? value) =>
        $"Validated param: {paramName}. Value: {value}. ValidationName: {validationName}";

    protected static string GetDefaultErrorMessage(
        string validationName,
        string? paramName,
        object? value,
        object? toCompare
    ) => $"Error to validate param: {paramName}. Value: {value}. Compare: {toCompare}. ValidationName: {validationName}";

    protected static string GetDefaultSuccessMessage(
        string validationName,
        string? paramName,
        object? value,
        object? toCompare
    ) => $"Validated param: {paramName}. Value: {value}. Compare: {toCompare}. ValidationName: {validationName}";
}
