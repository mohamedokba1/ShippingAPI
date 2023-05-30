﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Validations;

public static class ValidateModel
{
    internal static void ModelValidation(object obj)
    {
        ValidationContext validationContext = new ValidationContext(obj);
        List<ValidationResult> validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
        if (!isValid)
        {
            throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
        }
    }
}
