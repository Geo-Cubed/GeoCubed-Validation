namespace GeoCubed.Validation.Test.Models.NotNullTestModels;

public class NotNullTestMultipleValues
{
    [NotNull]
    public int? Value { get; set; }

    [NotNull]
    public int? Value2 { get; set; }
}
