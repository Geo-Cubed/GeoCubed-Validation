using GeoCubed.Validation.Attributes.Common;
using GeoCubed.Validation.Custom;
using System.ComponentModel;

namespace GeoCubed.Validation.Rules;

public sealed class GreaterThanRule<TModel, TProperty> : BaseRuleComponent<TProperty>, IRuleComponent<TModel, TProperty> where TModel : class
{
    private const string DEFAULT_ERROR = "{PROPERTY} is not greater than {VALUE}";
    private readonly string _minimumValue;

    public GreaterThanRule(string minimumValue, string propertyName) : base(propertyName, DEFAULT_ERROR)
    {
        this._minimumValue = minimumValue;
    }

    public void IsValid(TProperty value, ValidationContext<TModel> context)
    {
        if (value != null && !this.CheckGreaterThan(value))
        {
            context.AddFailiure(this.PropertyName, this.ContructErrorMessage(value));
        }
    }

    private bool CheckGreaterThan(TProperty value)
    {
        var objType = value.GetType();

        // Fetch the converter for the object type.
        TypeConverter converter;
        try
        {
            converter = AttributeHelper.GetConverter(objType);
        }
        catch
        {

            return false;
        }

        // Fetch the converter for the object type.
        IComparable comparer;
        try
        {
            comparer = AttributeHelper.GetComparer(converter, this._minimumValue);
        }
        catch
        {
            return false;
        }

        return comparer.CompareTo(value) <= 0;
    }
}
