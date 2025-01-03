namespace GeoCubed.Validation.Test.Models.NotNullTestModels;

public class NotNullTestErrorMessage
{
    [NotNull("Testing")]
    public int? Value { get; set; }
}
