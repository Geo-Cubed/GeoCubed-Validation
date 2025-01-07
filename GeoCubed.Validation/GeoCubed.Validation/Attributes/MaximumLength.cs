namespace GeoCubed.Validation.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class MaximumLength : BaseValidationAttribute
{
    private const string _defaultErrorMessage = "";

    public MaximumLength()
        : base(_defaultErrorMessage)
    {
    }

    public MaximumLength(string errorMessage)
        : base(errorMessage)
    {
    }

    public override bool IsValid(object value)
    {
        throw new NotImplementedException();
    }
}
