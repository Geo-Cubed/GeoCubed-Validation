using System.Collections;

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
        var span = new Span<string>();
        var objType = value.GetType();

        if (objType == typeof(string))
        {
            // Strings.
        }
        else if (typeof(IEnumerable).IsAssignableFrom(objType))
        {
            // List . enymerable
        }
        else if (objType.IsArray)
        {
            // Arrays
        }

        // Dictionaries?

    }
}
