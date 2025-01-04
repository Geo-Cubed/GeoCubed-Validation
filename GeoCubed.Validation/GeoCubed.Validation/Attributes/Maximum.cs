namespace GeoCubed.Validation.Attributes;

// TODO: Can I extract these into a number comparison validation attribute and then
// have all the ones that require number comparisons inherit from it's logic.
// for example => Minimum, Maximum, Range
public class Maximum : BaseValidationAttribute
{
    public Maximum(): base("")
    {
        
    }

    public override bool IsValid(object value)
    {
        throw new NotImplementedException();
    }
}
