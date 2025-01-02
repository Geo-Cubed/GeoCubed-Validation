using GeoCubed.Validation.Test.Models;

namespace GeoCubed.Validation.Test;

/// <summary>
/// Test class for testing the required validation attribute.
/// </summary>
public class RequiredTests
{
    [Fact]
    public void TestNullValue()
    {
        var model = new RequiredTestModel1();

        var result = Validator.Validate(model);
        Assert.True(result.HasErrors);

        // TODO: Validate the error messages.
    }

    [Fact]
    public void TestNullableNull()
    {

    }

    [Fact]
    public void TestStringNull()
    {

    }

    [Fact]
    public void TestStringEmpty()
    {

    }

    [Fact]
    public void TestHasValue()
    {

    }

    [Fact]
    public void TestNullableHasValue()
    {

    }

    [Fact]
    public void TestStringHasValue()
    {

    }
}