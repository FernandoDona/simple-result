namespace SimpleResult.Tests;

public class ResultValueTests
{
    [Fact]
    public void Create_SuccessResult()
    {
        // Arrange
        var value = "value";

        // Act
        Result<string> result = value;

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(value, result.Value);
    }

    [Fact]
    public void Create_SuccessResult_NullValue()
    {
        // Arrange
        string? value = null;

        // Act
        Action act = () => { Result<string> result = value!; };

        // Assert
        var exception = Assert.Throws<ArgumentNullException>(act);
        Assert.Equal("A successful result cannot be null (Parameter 'value')", exception.Message);
    }

    [Fact]
    public void Create_FailureResult()
    {
        // Arrange
        var error = new Error(999, "Test.Error", "Test error message", ErrorType.InternalServerError);

        // Act
        Result<string> result = error;

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(error, result.FirstError);
        Assert.Single(result.Errors);
        Assert.Equal(error, result.Errors[0]);
    }

    [Fact]
    public void Create_FailureResult_ListErrors()
    {
        // Arrange
        var errors = new List<Error>
        {
            new Error(998, "Test.Error1", "Test error message", ErrorType.NotImplemented),
            new Error(999, "Test.Error2", "Test error message", ErrorType.InternalServerError)
        };

        // Act
        Result<string> result = errors;

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(errors[0], result.FirstError);
        Assert.True(CompareErrors(errors, result.Errors));
    }

    [Fact]
    public void Create_FailureResult_NullErrors()
    {
        // Arrange
        List<Error>? errors = null;

        // Act
        Action act = () => { Result<string> result = errors!; };

        // Assert
        var exception = Assert.Throws<ArgumentNullException>(act);
        Assert.Equal("An error result must have at least one error (Parameter 'errors')", exception.Message);
    }

    [Fact]
    public void Create_FailureResult_EmptyErrors()
    {
        // Arrange
        List<Error> errors = new List<Error>();

        // Act
        Action act = () => { Result<string> result = errors; };

        // Assert
        var exception = Assert.Throws<ArgumentNullException>(act);
        Assert.Equal("An error result must have at least one error (Parameter 'errors')", exception.Message);
    }

    [Fact]
    public void Match_Success()
    {
        // Arrange
        var value = "value";
        Result<string> result = value;

        // Act
        var response = result.Match(
            onSuccess: v => v,
            onError: _ => "error");

        // Assert
        Assert.Equal(value, response);
    }

    [Fact]
    public void Match_Failure()
    {
        // Arrange
        var error = new Error(999, "Test.Error", "Test error message", ErrorType.InternalServerError);
        Result<string> result = error;

        // Act
        var response = result.Match(
            onSuccess: v => v,
            onError: _ => "error");

        // Assert
        Assert.Equal("error", response);
    }

    private bool CompareErrors(List<Error> errors1, List<Error> errors2)
    {
        if (errors1.Count != errors2.Count)
        {
            return false;
        }

        for (int i = 0; i < errors1.Count; i++)
        {
            if (errors1[i].Id != errors2[i].Id || errors1[i].Code != errors2[i].Code)
            {
                return false;
            }
        }

        return true;
    }
}