using GeoCubed.Validation.Custom;

namespace GeoCubed.Validation.Rules;

public sealed class StringContainsRuleComponent<TModel> : BaseRuleComponent<string>, IRuleComponent<TModel, string> where TModel : class
{
    private const string DEFAULT_ERROR = "{PROPERTY} does not contain {VALUE}";

    private readonly string _value;

    public StringContainsRuleComponent(string value, string propertyName) : base(propertyName, DEFAULT_ERROR)
    {
        this._value = value;
    }

    public void IsValid(string value, ValidationContext<TModel> context)
    {
        if (value != null && !value.Contains(this._value))
        {
            context.AddFailiure(this.PropertyName, this.ConstructErrorMessage(value));
        }
    }
}
