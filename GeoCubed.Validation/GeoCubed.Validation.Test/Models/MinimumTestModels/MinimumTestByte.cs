using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.MinimumTestModels;

public class MinimumTestByte
{
    [Minimum("128")]
    public byte Value { get; set; }
}
