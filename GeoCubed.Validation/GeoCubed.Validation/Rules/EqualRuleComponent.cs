using GeoCubed.Validation.Custom;

namespace GeoCubed.Validation.Rules;

public sealed class EqualRuleComponent<TModel, TProperty> : BaseRuleComponent<TProperty>, IRuleComponent<TModel, TProperty> where TModel : class
{
    private const string DEFAULT_ERROR = "The value for the property {PROPERTY} does not match expected value {VALUE}.";
    private readonly TProperty _expectedValue;

    public EqualRuleComponent(TProperty expectedValue, string PropertyName) : base(PropertyName, DEFAULT_ERROR)
    {
        _expectedValue = expectedValue;
    }

    public void IsValid(TProperty value, ValidationContext<TModel> context)
    {
        if (null == value && null == _expectedValue)
        {
            return;
        }

        if (null == value && null != _expectedValue || null != value && null == _expectedValue || !_expectedValue.Equals(value))
        {
            context.AddFailiure(PropertyName, ContructErrorMessage(value));
        }
    }
}
