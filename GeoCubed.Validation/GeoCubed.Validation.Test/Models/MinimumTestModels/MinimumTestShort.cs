using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.MinimumTestModels;

public class MinimumTestShort
{
    [Minimum("0")]
    public short Value { get; set; }
}
