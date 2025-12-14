using GeoCubed.Validation.Custom;
using System.Linq.Expressions;

namespace GeoCubed.Validation;

/// <summary>
/// Custom validator class for writing more complex model validations.
/// </summary>
/// <typeparam name="T">The type of model to validate.</typeparam>
public abstract class ClassValidator<TModel> where TModel : class
{
    private List<IValidationRule<TModel>> Rules { get; } = new ();

    /// <summary>
    /// Add a new rule to the ruleset.
    /// </summary>
    /// <typeparam name="TProperty">The type of property that the rule is for.</typeparam>
    /// <param name="property">The property the validation is for.</param>
    /// <returns>A new rule to build upon.</returns>
    public ValidationRule<TModel, TProperty> AddRule<TProperty>(Expression<Func<TModel, TProperty>> property)
    {
        ArgumentNullException.ThrowIfNull(property);

        var rule = new ValidationRule<TModel, TProperty>(property);
        Rules.Add(rule);
        return rule;
    }

    /// <summary>
    /// Run the validation for the model.
    /// </summary>
    /// <param name="model">The model to use for the validation.</param>
    /// <returns>The result of the validation.</returns>
    public ValidationResult RunValidation(TModel model)
    {
        var context = new ValidationContext<TModel>(model);

        // Run validation for the rules.
        var rulesCount = Rules.Count;
        for (int i = 0; i < rulesCount; ++i)
        {
            var rule = Rules[i];
            rule.Validate(context);
        }

        return context.ToValidationResult();
    }
}
