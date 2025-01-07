namespace GeoCubed.Validation.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class WithinLength : BaseValidationAttribute
{
    private const string _defaultErrorMessage = "";

    public WithinLength()
        : base(_defaultErrorMessage)
    {
    }

    public WithinLength(string errorMessage)
        : base(errorMessage)
    {
    }

    public override bool IsValid(object value)
    {
        throw new NotImplementedException();
    }
}
