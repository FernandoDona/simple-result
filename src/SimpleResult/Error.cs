namespace SimpleResult;

public readonly record struct Error(
    int Id,
    string Code,
    string Message,
    ErrorType Type)
{
    public static Error Validation(
        int id = (int)ErrorType.Validation,
        string code = nameof(ErrorType.Validation),
        string message = "The input is invalid",
        ErrorType errorType = ErrorType.Validation) => new Error(id, code, message, errorType);
    public static Error Unauthorized(
        int id = (int)ErrorType.Unauthorized,
        string code = nameof(ErrorType.Unauthorized),
        string message = "You are not authorized to access this resource",
        ErrorType errorType = ErrorType.Unauthorized) => new Error(id, code, message, errorType);
    public static Error Forbidden(
        int id = (int)ErrorType.Forbidden,
        string code = nameof(ErrorType.Forbidden),
        string message = "You are not allowed to access this resource",
        ErrorType errorType = ErrorType.Forbidden) => new Error(id, code, message, errorType);
    public static Error NotFound(
        int id = (int)ErrorType.NotFound,
        string code = nameof(ErrorType.NotFound),
        string message = "The requested resource was not found",
        ErrorType errorType = ErrorType.NotFound) => new Error(id, code, message, errorType);
    public static Error Conflict(
        int id = (int)ErrorType.Conflict,
        string code = nameof(ErrorType.Conflict),
        string message = "A conflit happened",
        ErrorType errorType = ErrorType.Conflict) => new Error(id, code, message, errorType);
    public static Error InternalServerError(
        int id = (int)ErrorType.InternalServerError,
        string code = nameof(ErrorType.InternalServerError),
        string message = "An unexpected error occurred",
        ErrorType errorType = ErrorType.InternalServerError) => new Error(id, code, message, errorType);
    public static Error NotImplemented(
        int id = (int)ErrorType.NotImplemented,
        string code = nameof(ErrorType.NotImplemented),
        string message = "This feature is not implemented",
        ErrorType errorType = ErrorType.NotImplemented) => new Error(id, code, message, errorType);
}