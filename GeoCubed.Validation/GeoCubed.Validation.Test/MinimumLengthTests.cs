using GeoCubed.Validation.Attributes;
using GeoCubed.Validation.Test.Helpers;
using GeoCubed.Validation.Test.Models.MinimumLengthTestModels;

namespace GeoCubed.Validation.Test;

/// <summary>
/// Tests for the <see cref="MinimumLength"/> validation attribute.
/// </summary>
public class MinimumLengthTests
{
    public MinimumLengthTests()
    {
        TestValidationHelper.SetDefualtErrorMessage("The length was less than the minimum value.");
    }

    [Fact]
    public void TestStringPass()
    {
        var model = new MinimumLengthTestAll()
        {
            StringValue = "1234567890",
        };

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(result);

    }

    [Fact]
    public void TestStringFail()
    {
        var model = new MinimumLengthTestAll()
        {
            StringValue = "123456789",
        };

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(result, nameof(model.StringValue));
    }

    [Fact]
    public void TestArrayPass()
    {
        var model = new MinimumLengthTestAll()
        {
            ArrayValue = [ "1", "2" ],
        };

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(result);
    }

    [Fact]
    public void TestArrayFail()
    {
        var model = new MinimumLengthTestAll()
        {
            ArrayValue = ["1"],
        };

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(result, nameof(model.ArrayValue));
    }

    [Fact]
    public void TestListPass()
    {
        var model = new MinimumLengthTestAll()
        {
            ListValue = new () { "1", "2" },
        };

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(result);
    }

    [Fact]
    public void TestListFail()
    {
        var model = new MinimumLengthTestAll()
        {
            ListValue = new () { "1" },
        };

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(result, nameof(model.ListValue));
    }

    [Fact]
    public void TestCollectionPass()
    {
        var model = new MinimumLengthTestAll()
        {
            CollectionValue = new() { "1", "2" },
        };

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(result);
    }

    [Fact]
    public void TestCollectionFail()
    {
        var model = new MinimumLengthTestAll()
        {
            CollectionValue = new() { "1" },
        };

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(result, nameof(model.CollectionValue));
    }

    [Fact]
    public void TestErrorMessage()
    {
        var model = new MinimumLengthTestAll()
        {
            ErrorMessage = "0",
        };

        var result = AttributeValidator.Validate(model);
        Assert.True(result.HasErrors);
        Assert.NotEmpty(result.Errors);

        var error = result.Errors[0];
        Assert.Equal("Validation Error on: ErrorMessage | Test", error.Message);
        Assert.Equal(nameof(model.ErrorMessage), error.Property);
    }

    [Fact]
    public void TestValueNull()
    {
        var model = new MinimumLengthTestAll()
        {
            StringValue = null,
        };

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(result);
    }
}
