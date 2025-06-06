<p align="center">
<img src="logo.png" alt="logo" width="200px"/>
</p>

<h1 align="center"> GHM.Validator </h1>

[![Build & Test](https://github.com/GustavoM96/GHM.Validator/actions/workflows/build.yml/badge.svg)](https://github.com/GustavoM96/GHM.Validator/actions/workflows/build.yml)

GHM.Validator is a nuget package aims to validate data.

## Install Package

.NET CLI

```sh
dotnet add package GHM.Validator
```

Package Manager

```sh
NuGet\Install-Package GHM.Validator
```

## IServiceCollectionExtensions

To add transient interface `IValidate` to implementate `Validate` or `IThrower` to implementate `Thrower` , call extension method to your serviceCollection `AddGhmValidator()`.
If you want to set a default exception for `IThrower`, pass a GhmValidatorConfigAction as a parameter.

```csharp
using GHM.Validator.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
services.AddGhmValidator(config =>
{
    config.ExceptionThrower = (string message) => new Exception(message);
});
// or
services.AddGhmValidator()
```

## Example

### To validate request data

```csharp
using GHM.Validator;
public class UserValidator(IValidate validate)
{
    public Validation[] ValidateUserRequest(UserRequest request)
    {
        return new Validation[]
        {
            validate.IfNotNull(request.Name,"Name must not be null"),
            validate.IfNotZero(request.Age,"Age must not be 0")
        };
    }
}
```

If error message is null, it will be passed a default message.

```csharp
using GHM.Validator;
public class UserValidator(IValidate validate)
{
    public Validation[] ValidateUserRequest(UserRequest request)
    {
        return new Validation[]
        {
            validate.IfNotNull(request.UserName), // Validated param: UserName. Value: null. ValidationName: IfNotNull
            validate.IfNotZero(request.UserAge)   // Error to validate param: UserAge. Value: 0. ValidationName: IfNotZero
        };
    }
}
```

You can set a errorType.

```csharp
using GHM.Validator;
public class UserValidator(IValidate validate)
{
    public Validation[] ValidateUserRequest(UserRequest request)
    {
        return new Validation[]
        {
            validate.IfNotNull(request.UserName).AsNotFound(), // validate.ErrorType = ErrorType.NotFound
            validate.IfNotZero(request.UserAge).AsFailure()   // validate.ErrorType = ErrorType.Failure
        };
    }
}
```

You can set a ErrorData.

```csharp
using GHM.Validator;

public static class UserError
{
    public static Error NotFoundByName => Error.NotFound("User not found","User.NotFoundByName");
    public static Error InvalidAge => Error.AsFailure("Age must not be 0","User.InvalidAge");
}
public class UserValidator(IValidate validate)
{
    public Validation[] ValidateUserRequest(UserRequest request)
    {
        return new Validation[]
        {
            validate.IfNotNull(request.UserName).BindError(UserError.NotFoundByName),
            validate.IfNotZero(request.UserAge).BindError(UserError.InvalidAge)
        };
    }
}
```

Throw Exception from validation if it's invalid.

```csharp
using GHM.Validator;
public class UserValidator(IValidate validate)
{
    public Validation[] ValidateUserRequest(UserRequest request)
    {
        ValidationList list = new
        {
            validate.IfNotNull(request.Name,"Name must not be null"),
            validate.IfNotZero(request.Age,"Age must not be 0")
        };

        list.ThrowErrorsWithMessage(" | ") //throw new ValidationException("Name must not be null | Age must not be 0").
        return list;
    }
}
```

### To throw if request data is invalid

```csharp
using GHM.Validator;
public class UserValidator(IThrower thrower)
{
    public bool ValidateUserRequest(UserRequest request)
    {
        thrower.IfNull(request.Name,"Name must not be null");// if null, throw ArgumentException.
        thrower.IfZero(request.Age,"Age must not be 0"); // if zero, throw ArgumentException.

        return true;
    }
}
```

Setting a Exception.

```csharp
using GHM.Validator;
public class UserValidator(IThrower thrower)
{
    public bool ValidateUserRequest(UserRequest request)
    {
        thrower
            .WithException((message) => new NameTestException(message))
            .IfNull(request.Name,"Name must not be null");

        thrower
            .WithException((message) => new AgeTestException(message))
            .IfZero(request.Age,"Age must not be 0");

        // or set by generic

        thrower
            .IfNull<NameTestException>(request.Name,"Name must not be null");

        thrower
            .IfZero<NameTestException>(request.Age,"Age must not be 0");

        return true;
    }
}
```

## Classes

### Validation

Validation is a object with properties(Message, IsValid).

```csharp
using GHM.Validator;

Validation validationSuccess = Validation.Success("Successful message");

validationSuccess.Message; // "Successful message"
validationSuccess.IsValid; // true

Validation validationError = Validation.Error("Error message");

validationError.Message; // "Error message"
validationError.IsValid; // false
```

### Result

Result is a object to return a value and/or validations

```csharp
using GHM.Validator;
public class UserService(IValidate validate)
{
    public Result<User> CreateUser(UserRequest request)
    {
        ValidationList validations = new
        {
            validate.IfNotNull(request.Name,"Name must not be null"),
            validate.IfNotZero(request.Age,"Age must not be 0")
        };

        if(validations.IsError)
        {
            return validations
        }

        User user = _userRepository.Create(request);

        return new(validations, user); // Return all validations and value
    }
}
```

Using the Match Method to execute a action on success or error condition.

```csharp
using GHM.Validator;
public class UserService(IValidate validate)
{
    public IEnumerable<string> GetResultAsListOfString(UserRequest request)
    {
        ValidationList validations = new
        {
            validate.IfNotNull(request.Name,"Name must not be null"),
            validate.IfNotZero(request.Age,"Age must not be 0")
        };

        Result<User> result = new(validations, user);
        return result.Match(
            (vals) => vals.Select(val => val.Message),
            (errors) => errors.Select(error => error.Message));
    }
}
```

## Interfaces

### IValidate

You can use it to return a validation result.

```csharp

public interface IValidate
{
    Validation IfTrue(bool condition, string message = null);
    Validation IfFalse(bool condition, string message = null);
    Validation IfNotDefault<T>(T obj, string message = null);
    Validation IfNotNull(object? obj, string message = null);
    Validation IfNull(object? obj, string message = null);
    Validation IfEqual(object obj, object toCompare, string message = null);
    Validation IfNotZero(int number, string message = null);
    Validation IfNotZero(decimal number, string message = null);
    Validation IfGreaterOrEqual(int number, int toCompare, string message = null);
    Validation IfGreater(int number, int toCompare, string message = null);
    Validation IfGreaterOrEqual(decimal number, decimal toCompare, string message = null);
    Validation IfGreater(decimal number, decimal toCompare, string message = null);
    Validation IfNotEmpty(string text, string message = null);
    Validation IfParseToLong(string text, string message = null);
    Validation IfNotEmpty<T>(IEnumerable<T> list, string message = null);
    Validation IfOlder(DateTime date, DateTime toCompare, string message = null);
    Validation IfOlderOrEqual(DateTime date, DateTime toCompare, string message = null);
    Validation IfEmail(string email, string? message = null);
}
```

### IThrower

You can use it to throw exception.

```csharp
public interface IThrower
{
    IThrower WithException(Func<string, Exception> exceptionThrower);
    bool IfFalse(bool condition, string message = null);
    bool IfTrue(bool condition, string message = null);
    bool IfDefault<T>(T obj, string message = null);
    bool IfNotNull(object? obj, string message = null);
    bool IfNull(object? obj, string message = null);
    bool IfNotEqual(object obj, object toCompare, string message = null);
    bool IfZero(int number, string message = null);
    bool IfZero(decimal number, string message = null);
    bool IfGreaterOrEqual(int number, int toCompare, string message = null);
    bool IfGreater(int number, int toCompare, string message = null);
    bool IfGreaterOrEqual(decimal number, decimal toCompare, string message = null);
    bool IfGreater(decimal number, decimal toCompare, string message = null);
    bool IfEmpty(string text, string message = null);
    bool IfNotParseToLong(string text, string message = null);
    bool IfEmpty<T>(IEnumerable<T> list, string message = null);
    bool IfOlder(DateTime date, DateTime toCompare, string message = null);
    bool IfOlderOrEqual(DateTime date, DateTime toCompare, string message = null);
    bool IfNotEmail(string email, string? message = null);
}
```

## Star

if you enjoy, don't forget the ⭐ and install the package 😊.
