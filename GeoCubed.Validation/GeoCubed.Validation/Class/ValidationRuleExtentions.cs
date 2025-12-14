using GeoCubed.Validation.Rules;

namespace GeoCubed.Validation.Custom;

public static class ValidationRuleExtentions
{
    public static ValidationRule<TModel, TProperty> EqualTo<TModel, TProperty>(this ValidationRule<TModel, TProperty> rule, TProperty expectedValue, string errorMessage = "") where TModel : class
    {
        ArgumentNullException.ThrowIfNull(rule);

        var equalityRule = new EqualRuleComponent<TModel, TProperty>(expectedValue, rule.MemberName);
        if (!string.IsNullOrEmpty(errorMessage))
        {
            equalityRule.SetErrorMessage(errorMessage);
        }

        rule.AddComponent(equalityRule);

        return rule;
    }

    public static ValidationRule<TModel, TProperty> GreaterThan<TModel, TProperty>(this ValidationRule<TModel, TProperty> rule, TProperty minimum, string errorMessage = "") where TModel : class
    {
        ArgumentNullException.ThrowIfNull(rule);

        var greaterThanRule = new GreaterThanRule<TModel, TProperty>(minimum.ToString(), rule.MemberName);
    }

    private static void AttachErrorMessage(this IRuleComponent<TModel, TProperty> ruleCompostring errorMessage)
}
