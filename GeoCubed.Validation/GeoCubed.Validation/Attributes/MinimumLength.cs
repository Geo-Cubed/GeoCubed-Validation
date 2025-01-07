namespace GeoCubed.Validation.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class MinimumLength : BaseValidationAttribute
{
    private const string _defaultErrorMessage = "";

    public MinimumLength()
        : base(_defaultErrorMessage)
    {
    }

    public MinimumLength(string errorMessage)
        : base(errorMessage)
    {
    }

    public override bool IsValid(object value)
    {
        throw new NotImplementedException();
    }
}
