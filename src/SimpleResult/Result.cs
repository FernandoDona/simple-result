using SimpleResult;
using System.Runtime.CompilerServices;

namespace SimpleResult;

public readonly record struct Result<TValue>
{
    private readonly TValue? _value = default;
    private readonly List<Error>? _errors = null;
    public TValue? Value => _value;
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error FirstError
    { 
        get
        {
            if (_errors is null || _errors.Count == 0)
            {
                throw new InvalidOperationException("There is no error. Check IsFailure before calling this property.");
            }

            return _errors[0];
        }
    }

    public List<Error> Errors
    {
        get
        {
            if (_errors is null || _errors.Count == 0)
            {
                throw new InvalidOperationException("There is no error. Check IsFailure before calling this property.");
            }

            return _errors;
        }
    }
    private Result(TValue value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value), "A successful result cannot be null");
        }

        _value = value;
        IsSuccess = true;
    }
    private Result(List<Error> errors)
    {
        if (errors is null || errors.Count == 0)
        {
            throw new ArgumentNullException(nameof(errors), "An error result must have at least one error");
        }

        _errors = errors;
        IsSuccess = false;
    }
    private Result(Error error)
    {
        _errors = new List<Error> { error };
        IsSuccess = false;
    }

    public TResponse Match<TResponse>(Func<TValue, TResponse> onSuccess, Func<List<Error>, TResponse> onError)
    {
        if (!IsSuccess)
            return onError(_errors!);

        return onSuccess(_value!);
    }

    public static implicit operator Result<TValue>(TValue value) => new Result<TValue>(value);
    public static implicit operator Result<TValue>(Error error) => new Result<TValue>(error);
    public static implicit operator Result<TValue>(List<Error> errors) => new Result<TValue>(errors);
}
