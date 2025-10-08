namespace SimpleResult.Tests;

public class ResultValueTests
{
    [Fact]
    public void Create_SuccessResult()
    {
        var value = "value";

        Result<string> result = value;

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(value, result.Value);
    }

    [Fact]
    public void Create_SuccessResult_NullValue()
    {
        string? value = null;

        Action act = () => { Result<string> result = value!; };

        var exception = Assert.Throws<ArgumentNullException>(act);
        Assert.Equal("A successful Result<T> cannot be null. (Parameter 'value')", exception.Message);
    }

    [Fact]
    public void Create_FailureResult()
    {
        var error = new Error("Test.Error", "Test error message", ErrorType.Unexpected);

        Result<string> result = error;

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Single(result.Errors);
        Assert.Equal(error, result.Errors[0]);
    }

    [Fact]
    public void Create_FailureResult_ListErrors()
    {
        var errors = new List<Error>
        {
            new Error("Test.Error1", "Test error message", ErrorType.Conflict),
            new Error("Test.Error2", "Test error message", ErrorType.RuleViolation)
        };

        Result<string> result = errors;

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        foreach (var error in errors)
        {
            Assert.Contains(error, result.Errors);
        }
    }

    [Fact]
    public void Create_FailureResult_NullErrors()
    {
        List<Error>? errors = null;

        Action act = () => { Result<string> result = errors!; };

        var exception = Assert.Throws<ArgumentNullException>(act);
        Assert.Equal("An error result must have at least one error (Parameter 'errors')", exception.Message);
    }

    [Fact]
    public void Create_FailureResult_EmptyErrors()
    {
        List<Error> errors = new List<Error>();

        Action act = () => { Result<string> result = errors; };

        var exception = Assert.Throws<ArgumentNullException>(act);
        Assert.Equal("An error result must have at least one error (Parameter 'errors')", exception.Message);
    }

    [Fact]
    public void Match_Success()
    {
        var value = "value";
        Result<string> result = value;

        var response = result.Match(
            onSuccess: v => v,
            onError: _ => "error");

        Assert.Equal(value, response);
    }

    [Fact]
    public void Match_Failure()
    {
        var error = new Error("Test.Error", "Test error message", ErrorType.Forbidden);
        Result<string> result = error;

        var response = result.Match(
            onSuccess: v => v,
            onError: e => e.First().Message);

        Assert.Equal(error.Message, response);
    }
}