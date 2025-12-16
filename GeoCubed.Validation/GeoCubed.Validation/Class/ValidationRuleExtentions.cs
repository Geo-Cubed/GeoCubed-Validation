using GeoCubed.Validation.Rules;

namespace GeoCubed.Validation.Custom;

public static class ValidationRuleExtentions
{
    public static ValidationRule<TModel, TProperty> EqualTo<TModel, TProperty>(this ValidationRule<TModel, TProperty> rule, TProperty expectedValue, string errorMessage = "") where TModel : class
    {
        ArgumentNullException.ThrowIfNull(rule);

        var equalityRule = new EqualRuleComponent<TModel, TProperty>(expectedValue, rule.MemberName);
        AttachErrorMessage(equalityRule, errorMessage);

        rule.AddComponent(equalityRule);

        return rule;
    }

    public static ValidationRule<TModel, TProperty> GreaterThan<TModel, TProperty>(this ValidationRule<TModel, TProperty> rule, TProperty minimum, string errorMessage = "") where TModel : class
    {
        ArgumentNullException.ThrowIfNull(rule);

        var greaterThanRule = new GreaterThanRule<TModel, TProperty>(minimum.ToString(), rule.MemberName);
        AttachErrorMessage(greaterThanRule, errorMessage);

        rule.AddComponent(greaterThanRule);

        return rule;
    }

    public static ValidationRule<TModel, TProperty> LessThan<TModel, TProperty>(this ValidationRule<TModel, TProperty> rule, TProperty maximum, string errorMessage = "") where TModel : class
    {
        ArgumentNullException.ThrowIfNull(rule);

        var lessThanRule = new LessThanRule<TModel, TProperty>(maximum.ToString(), rule.MemberName);
        AttachErrorMessage(lessThanRule, errorMessage);

        rule.AddComponent(lessThanRule);

        return rule;
    }

    public static ValidationRule<TModel, TProperty> Contains<TModel, TProperty>(this ValidationRule<TModel, TProperty> rule, object value, string errorMessage = "") where TModel : class
    {
        ArgumentNullException.ThrowIfNull(rule);

        if (typeof(TProperty) == typeof(string))
        {
            if (value is not string && value is not char)
            {
                throw new ArgumentException("Cannot create a contains for a string type without string or char contain value.");
            }

            var ruleComponent = new StringContainsRuleComponent<TModel>(value as string, rule.MemberName);
            AttachErrorMessage(ruleComponent, errorMessage);
            return rule;
        }

        // TODO: Contains for a collection.
        throw new NotImplementedException();
    }

    private static void AttachErrorMessage<TModel, TProperty>(this IRuleComponent<TModel, TProperty> ruleComponent, string errorMessage) where TModel : class
    {
        if (!string.IsNullOrEmpty(errorMessage))
        {
            ruleComponent.SetErrorMessage(errorMessage);
        }
    }
}
