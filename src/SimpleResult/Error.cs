namespace SimpleResult;

public readonly record struct Error(
    string Code,
    string Message,
    ErrorType Type)
{
    public bool Equals(Error other) => Code == other.Code && Type == other.Type;
    public override int GetHashCode() => HashCode.Combine(Code, Type);

    public static Error InvalidData(
        string code = nameof(ErrorType.InvalidData),
        string message = "Invalid data provided") => new(code, message, ErrorType.InvalidData);
    public static Error Unauthorized(
        string code = nameof(ErrorType.Unauthorized),
        string message = "Authentication required") => new(code, message, ErrorType.Unauthorized);
    public static Error Forbidden(
        string code = nameof(ErrorType.Forbidden),
        string message = "Access denied") => new(code, message, ErrorType.Forbidden);
    public static Error NotFound(
        string code = nameof(ErrorType.NotFound),
        string message = "Resource not found") => new(code, message, ErrorType.NotFound);
    public static Error InvalidState(
        string code = nameof(ErrorType.InvalidState),
        string message = "Invalid state for operation") => new(code, message, ErrorType.InvalidState);
    public static Error RuleViolation(
        string code = nameof(ErrorType.RuleViolation),
        string message = "Business rules violation") => new(code, message, ErrorType.RuleViolation);
    public static Error Unprocessable(
        string code = nameof(ErrorType.Unprocessable),
        string message = "Unprocessable action") => new(code, message, ErrorType.Unprocessable);
    public static Error Conflict(
        string code = nameof(ErrorType.Conflict),
        string message = "Conflict detected") => new(code, message, ErrorType.Conflict);
    public static Error Unexpected(
        string code = nameof(ErrorType.Unexpected),
        string message = "An unexpected error occured") => new(code, message, ErrorType.Unexpected);
}
