using ErrorOr;

namespace IndustrialAssist.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Conflict(code: "Auth.InvalidCred", description: "Invalid credentials - thrown from ErrorOr - Errors.Authentication.cs in domain layer");
    }
}