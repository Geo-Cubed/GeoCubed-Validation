using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.MinimumTestModels;

public class MinimumTestFloat
{
    [Minimum("0")]
    public float Value { get; set; }
}
