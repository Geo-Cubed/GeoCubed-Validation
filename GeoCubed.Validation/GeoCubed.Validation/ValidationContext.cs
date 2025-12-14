namespace GeoCubed.Validation.Custom;

/// <summary>
/// A context for validation to use.
/// </summary>
/// <typeparam name="TModel">The class the validation is running against.</typeparam>
public sealed class ValidationContext<TModel> where TModel : class
{
    private readonly List<ValidationError> _failiures;
    
    /// <summary>
    /// Gets the model instance for validation.
    /// </summary>
    public readonly TModel Instance;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationContext{TModel}"/> class.
    /// </summary>
    /// <param name="instance">The model instance to check against.</param>
    public ValidationContext(TModel instance)
    {
        this.Instance = instance;
        this._failiures = new List<ValidationError>();
    }

    /// <summary>
    /// Add a custom failiure to the context.
    /// </summary>
    /// <param name="propertyName">The property name.</param>
    /// <param name="errorMessage">The error message for the validation.</param>
    public void AddFailiure(string propertyName, string errorMessage)
    {
        this._failiures.Add(new() { Property = propertyName, Message = errorMessage });
    }

    /// <summary>
    /// Add a failiure to the context.
    /// </summary>
    /// <param name="error">An error to add.</param>
    public void AddFailiure(ValidationError error)
    {
        this._failiures.Add(error);
    }

    /// <summary>
    /// Convert the context into a validation result.
    /// </summary>
    /// <returns>A result of the validation.</returns>
    public ValidationResult ToValidationResult()
    {
        if (this._failiures.Count == 0)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(this._failiures);
    }
}
