using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Validations;

public static class ValidateModel
{
    public static List<ValidationResult>? ModelValidation(object obj)
    {
        ValidationContext validationContext = new ValidationContext(obj);
        List<ValidationResult> validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
        if (!isValid)
        {
            return validationResults;
        }
        else
            return new List<ValidationResult>();
    }
}
