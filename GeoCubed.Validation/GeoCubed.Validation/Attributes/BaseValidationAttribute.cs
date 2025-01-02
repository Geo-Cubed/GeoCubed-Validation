namespace GeoCubed.Validation.Attributes;

/// <summary>
/// Base validation attribute that all attributes should inherit from.
/// </summary>
public abstract class BaseValidationAttribute : Attribute
{
    private string _errorMessage = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseValidationAttribute"/> class.
    /// </summary>
    /// <param name="errorMessage">The error message to use.</param>
    protected BaseValidationAttribute(string errorMessage)
    {
        _errorMessage = errorMessage;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseValidationAttribute"/> class.
    /// </summary>
    protected BaseValidationAttribute()
    {
    }

    /// <summary>
    /// Abstract method to check if the value provided is valid.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>True if valid, false otherwise.</returns>
    public abstract bool IsValid(object value);

    /// <summary>
    /// Constructs the error message to use on validation fail.
    /// </summary>
    /// <param name="name">The name of the parameter.</param>
    /// <returns>The error message to use.</returns>
    public virtual string ConstructErrorMessage(string name)
    {
        return string.Format("Validation Error on: {0} | {1}", name, _errorMessage);
    }
}
