using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.MinimumTestModels;

public class MinimumTestInt
{
    [Minimum("0")]
    public int Value { get; set; }
}
