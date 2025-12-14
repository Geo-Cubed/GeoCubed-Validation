namespace GeoCubed.Validation.Test.Helpers;

public static class TestValidationHelper
{
    private static string _defaultErrorMessage = "";

    public static void SetDefualtErrorMessage(string defaultErrorMessage)
    {
        _defaultErrorMessage = defaultErrorMessage;
    }

    public static void ValidateFail(ValidationResult result, string propertyName)
    {
        Assert.True(result.HasErrors);
        Assert.NotEmpty(result.Errors);

        var error = result.Errors[0];
        Assert.Equal($"Validation Error on: {propertyName} | {_defaultErrorMessage}", error.Message);
        Assert.Equal(propertyName, error.Property);
    }

    public static void ValidatePass(ValidationResult result)
    {
        Assert.False(result.HasErrors);
        Assert.Empty(result.Errors);
    }
}
