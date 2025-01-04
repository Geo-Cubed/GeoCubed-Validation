using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.MinimumTestModels;

public class MinimumTestErrorMessage
{
    [Minimum("2", "Test")]
    public int Value { get; set; }
}
