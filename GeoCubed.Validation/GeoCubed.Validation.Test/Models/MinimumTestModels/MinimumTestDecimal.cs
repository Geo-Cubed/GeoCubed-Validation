using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.MinimumTestModels;

public class MinimumTestDecimal
{
    [Minimum("0")]
    public decimal Value { get; set; }
}
