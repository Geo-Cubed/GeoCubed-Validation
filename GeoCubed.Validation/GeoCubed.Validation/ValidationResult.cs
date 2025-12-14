namespace GeoCubed.Validation;

/// <summary>
/// Model for storing the result of a validation check.
/// </summary>
public sealed class ValidationResult
{
    private List<ValidationError> _errors;

    /// <summary>
    /// Gets or sets if the validation has errors.
    /// </summary>
    public bool HasErrors 
    {
        get => this._errors.Count > 0; 
    }

    /// <summary>
    /// Gets or sets the Errors in the validation.
    /// </summary>
    public List<ValidationError> Errors 
    {
        get => this._errors;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            this._errors = value;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationResult"/> class.
    /// </summary>
    public ValidationResult()
    {
        this._errors = new ();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationResult"/> class.
    /// </summary>
    /// <param name="errors">The errors.</param>
    public ValidationResult(List<ValidationError> errors)
    {
        this._errors = errors;
    }

    /// <summary>
    /// Get a successful validation result.
    /// </summary>
    public static ValidationResult Success => new ValidationResult(); 
}
