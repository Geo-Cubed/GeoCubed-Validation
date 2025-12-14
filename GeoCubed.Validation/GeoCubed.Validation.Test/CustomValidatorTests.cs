using GeoCubed.Validation.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoCubed.Validation.Test;

public class CustomValidatorTests
{
    [Fact]
    public void TestCustomValidator()
    {
        var person = new Person()
        {
            Name = "John Smith1",
        };

        var validator = new PersonValidator();

        var result = validator.RunValidation(person);

        Assert.False(result.HasErrors);
    }
}

public class Person
{
    public string Name { get; set; }
}

public class PersonValidator : ClassValidator<Person>
{
    public PersonValidator()
    {
        AddRule(x => x.Name).EqualTo("John Smith");
    }
}
