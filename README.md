# GeoCubed Validation

This is a validation library I wrote based on the System.ComponentModel.DataAnnotations valideion. The validation is done by specifying attributes on models which then is checked by a validator. This library currently only supports property validation but I may look into other thing in the future.

## Quick Start

#### 1. Add a reference to the `GeoCubed.Validation.csproj` file
This file can be found at `GeoCubed.Validation/GeoCubed.Validation/GeoCubed.Validation.csproj`

#### 2. Add the validation attributes to a model
Add attributes to the models as shown below.

```csharp
public class Example
{
    [WithinLength(2, 20)]
    public string Name { get; set; }

    [Minimum("0")]
    public int Age { get; set; }

    [NotNull]
    public bool? HasCat { get; set; }
}
```

#### 3. Run the validator to check if the model is valid
```csharp
var model = new Example()
{
    Name = "Luke",
    Age = 56,
    HasCat = null,
};

var validationResult = Validator.Validate(model);
```

The `Validate(object obj)` method will return a validation result containing information on any errors with the validation.

## Validation Result

TODO: Explain this

## Validation Attributes
The current available validation attributes are as follows:

##### - NotNull `GeoCubed.Validation.Attributes.NotNull`
This checks to make sure the value of the property is not null

##### - Maximum `GeoCubed.Validation.Attributes.Maximum`
This checks a numeric type to see if it is less than or equal to the maximum value provided 

##### - Minimum `GeoCubed.Validation.Attributes.Minimum`
This checks a numeric type to see if it is greater than or equal to the minimum value provided

##### - Within `GeoCubed.Validation.Attributes.Within`
This checks a numeric type to see if it is within the bounds provided inclusive

##### - MaximumLength `GeoCubed.Validation.Attributes.MaximumLength`
This checks a string or enumeratable type such as an array or list to check it's length is less than or equal to the maximum value provided

TODO: Test

##### - MinimumLength `GeoCubed.Validation.Attributes.MinimumLength`
This checks a string or enumeratable type such as an array or list to check it's length is greater than or equal to the minimum value provided

TODO: Test

##### - WithinLength `GeoCubed.Validation.Attributes.WithinLength`
This checks a string or enumeratable type such as an array or list to check it's length is within the bounds provided inclusive

TODO: Test

##### - IsType

TODO: Not done

#### - ValidateViaMethod

TODO: Not done

#### - Contains

TODO: Not done

#### - Equals

TODO: Not done

#### IsOneOf

TODO: Not done

## Creating Custom Validation Attributes

-- TODO: Explain how

## Test Project

Located in `GeoCubed.Validation/GeoCubed.Validation.Test` there is a xUnit test project `GeoCubed.Validation.Test.csproj`
This project is used to test the validity of the functionality of the validation attributes
This project can be ignored as it is only used to verify that the validation attributes are working as expected