namespace SimpleResult;

public readonly record struct Error(
    int Id,
    string Code,
    string Message,
    ErrorType Type)
{
    public static Error BadRequest(
        int id = 400,
        string code = "BadRequest",
        string message = "The request is invalid",
        ErrorType errorType = ErrorType.BadRequest) => new Error(id, code, message, errorType);
    public static Error Unauthorized(
        int id = 401,
        string code = "Unauthorized",
        string message = "You are not authorized to access this resource",
        ErrorType errorType = ErrorType.Unauthorized) => new Error(id, code, message, errorType);
    public static Error Forbidden(
        int id = 403,
        string code = "Forbidden",
        string message = "You are not allowed to access this resource",
        ErrorType errorType = ErrorType.Forbidden) => new Error(id, code, message, errorType);
    public static Error NotFound(
        int id = 404,
        string code = "NotFound",
        string message = "The requested resource was not found",
        ErrorType errorType = ErrorType.NotFound) => new Error(id, code, message, errorType);
    public static Error Conflict(
        int id = 409,
        string code = "Conflict",
        string message = "A conflit happened",
        ErrorType errorType = ErrorType.Conflict) => new Error(id, code, message, errorType);
    public static Error InternalServerError(
        int id = 500,
        string code = "InternalServerError",
        string message = "An unexpected error occurred",
        ErrorType errorType = ErrorType.InternalServerError) => new Error(id, code, message, errorType);
    public static Error NotImplemented(
        int id = 501,
        string code = "NotImplemented",
        string message = "This feature is not implemented",
        ErrorType errorType = ErrorType.NotImplemented) => new Error(id, code, message, errorType);
}