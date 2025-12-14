using GeoCubed.Validation.Test.Helpers;
using GeoCubed.Validation.Test.Models.NotNullTestModels;

namespace GeoCubed.Validation.Test;

/// <summary>
/// Tests for the <see cref="NotNull"/> validation attribute.
/// </summary>
public class NotNullTests
{
    public NotNullTests()
    {
        TestValidationHelper.SetDefualtErrorMessage("The value was null.");    
    }

    /// <summary>
    /// Test validation fail on nullable property being null.
    /// </summary>
    [Fact]
    public void TestNullableNull()
    {
        var model = new NotNullTestIntNullable()
        {
            Value = null,
        };

        var result = AttributeValidator.Validate(model);

        TestValidationHelper.ValidateFail(result, nameof(model.Value));
    }

    /// <summary>
    /// Test validation fail when string is null.
    /// </summary>
    [Fact]
    public void TestStringNull()
    {
        var model = new NotNullTestString();

        var result = AttributeValidator.Validate(model);

        TestValidationHelper.ValidateFail(result, nameof(model.Value));
    }

    /// <summary>
    /// Test validation fail when string is string.Empty.
    /// </summary>
    [Fact]
    public void TestStringEmpty()
    {
        var model = new NotNullTestString()
        {
            Value = string.Empty,
        };

        var result = AttributeValidator.Validate(model);

        TestValidationHelper.ValidateFail(result, nameof(model.Value));
    }

    /// <summary>
    /// Test validation pass when value has value.
    /// </summary>
    [Fact]
    public void TestHasValue()
    {
        var model = new NotNullTestIntNullable()
        {
            Value = 1,
        };

        var result = AttributeValidator.Validate(model);

        TestValidationHelper.ValidatePass(result);
    }

    /// <summary>
    /// Test validation pass when string value has non empty value.
    /// </summary>
    [Fact]
    public void TestStringHasValue()
    {
        var model = new NotNullTestString()
        {
            Value = "Test",
        };

        var result = AttributeValidator.Validate(model);

        TestValidationHelper.ValidatePass(result);
    }

    /// <summary>
    /// Test validation fail specified error message.
    /// </summary>
    [Fact]
    public void TestErrorMessage()
    {
        var model = new NotNullTestErrorMessage()
        {
            Value = null,
        };

        var result = AttributeValidator.Validate(model);

        Assert.True(result.HasErrors);

        var error = result.Errors[0];
        Assert.Equal("Value", error.Property);
        Assert.Equal("Validation Error on: Value | Testing", error.Message);
    }

    /// <summary>
    /// Test that multiple errors are thrown when there are multiple null values.
    /// </summary>
    [Fact]
    public void TestMultipleError()
    {
        var model = new NotNullTestMultipleValues()
        {
            Value = null,
            Value2 = null,
        };

        var result = AttributeValidator.Validate(model);

        Assert.True(result.HasErrors);
        Assert.True(result.Errors.Count == 2);
    }

    /// <summary>
    /// Test one error when only one of two values are null.
    /// </summary>
    [Fact]
    public void TestOneOfManyErrors()
    {
        var model = new NotNullTestMultipleValues()
        {
            Value = null,
            Value2 = 1,
        };

        var result = AttributeValidator.Validate(model);

        Assert.True(result.HasErrors);
        Assert.True(result.Errors.Count == 1);
    }
}