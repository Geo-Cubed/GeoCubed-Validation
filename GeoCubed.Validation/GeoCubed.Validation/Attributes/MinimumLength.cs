using System.Collections;
using System.Reflection.Emit;

namespace GeoCubed.Validation.Attributes;

/// <summary>
/// Validation attribute for checking the minimum length of an object.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class MinimumLength : BaseValidationAttribute
{
    private const string _defaultErrorMessage = "";

    private readonly int _minimumLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="MinimumLength"/> class.
    /// </summary>
    /// <param name="minimumLength">The minimum length.</param>
    public MinimumLength(int minimumLength)
        : base(_defaultErrorMessage)
    {
        this._minimumLength = minimumLength;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MinimumLength"/> class.
    /// </summary>
    /// <param name="minimumLength">The minimum length.</param>
    /// <param name="errorMessage">The error message to use on fail.</param>
    public MinimumLength(int minimumLength, string errorMessage)
        : base(errorMessage)
    {
        this._minimumLength = minimumLength;
    }

    public override bool IsValid(object value)
    {
        var span = new Span<string>();
        var objType = value.GetType();

        int length = int.MinValue;
        if (objType == typeof(string))
        {
            var parsed = value as string;
            length = parsed == null ? 0 : parsed.Length;
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
        return length >= this._minimumLength;
    }
}
