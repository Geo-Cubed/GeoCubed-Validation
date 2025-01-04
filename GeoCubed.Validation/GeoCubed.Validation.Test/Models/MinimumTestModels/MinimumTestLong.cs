using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.MinimumTestModels;

public class MinimumTestLong
{
    [Minimum("0")]
    public long Value { get; set; }
}
