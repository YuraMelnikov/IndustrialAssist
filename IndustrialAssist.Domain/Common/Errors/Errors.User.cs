using ErrorOr;

namespace IndustrialAssist.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "Email already in use - thrown from ErrorOr - Errors.User.cs in domain layer");
    }
}