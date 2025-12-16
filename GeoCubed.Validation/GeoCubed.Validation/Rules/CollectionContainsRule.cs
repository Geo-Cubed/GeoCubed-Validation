using GeoCubed.Validation.Custom;

namespace GeoCubed.Validation.Rules
{
    public sealed class CollectionContainsRule<TModel, TProperty> : BaseRuleComponent<TProperty>, IRuleComponent<TModel, TProperty> where TModel : class
    {
        private const string DEFAUT_ERROR = "{PROPERTY} does not contain {VALUE}";

        private readonly object _value;

        public CollectionContainsRule(object value, string propertyName) : base(propertyName, DEFAUT_ERROR)
        {
            this._value = value;
        }

        public void IsValid(TProperty value, ValidationContext<TModel> context)
        {
            throw new NotImplementedException();
        }
    }
}
