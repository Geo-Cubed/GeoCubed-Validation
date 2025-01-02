using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation;

/// <summary>
/// Required validation attribute class. This will check if an object is not null (or empty in case of string).
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public sealed class Required : BaseValidationAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Required"/> class.
    /// </summary>
    public Required()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Required"/> class.
    /// </summary>
    /// <param name="errorMessage">The error message for the validation.</param>
    public Required(string errorMessage)
        : base(errorMessage)
    {
    }

    /// <summary>
    /// Checks if the value is null or not.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>True if valid, False otherwise.</returns>
    public override bool IsValid(object value)
    {
        if (value.GetType() == typeof(string))
        {
            return string.IsNullOrEmpty(value as string);
        }

        return value != null;
    }

    /// <summary>
    /// Constructs the error message to use on validation fail.
    /// </summary>
    /// <param name="name">The name of the parameter.</param>
    /// <returns>The error message.</returns>
    public override string ConstructErrorMessage(string name)
    {
        return base.ConstructErrorMessage(name);
    }
}
