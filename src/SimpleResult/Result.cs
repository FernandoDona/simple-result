namespace SimpleResult;

public readonly record struct Result
{
    private readonly List<Error>? _errors = null;
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public List<Error> Errors
    {
        get
        {
            if (_errors is null)
            {
                return [];
            }

            return [.. _errors!];
        }
    }

    private Result(List<Error> errors)
    {
        if (errors is null || errors.Count == 0)
        {
            throw new ArgumentNullException(nameof(errors), "An error result must have at least one error");
        }

        _errors = [.. errors];
        IsSuccess = false;
    }

    private Result(Error error)
    {
        _errors =  [error];
        IsSuccess = false;
    }

    private Result(bool success)
    {
        IsSuccess = success;
    }

    public static implicit operator Result(Error error) => new(error);
    public static implicit operator Result(List<Error> errors) => new(errors);
    public static Result Success() => new(true);

    public TResponse Match<TResponse>(Func<TResponse> onSuccess, Func<List<Error>, TResponse> onError)
    {
        if (!IsSuccess)
            return onError(Errors);

        return onSuccess();
    }
}
