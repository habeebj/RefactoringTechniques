using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Refactor.WebApi.Models
{
    public class ValidateBindingModel : IPRSBindingModel, IValidatableObject
    {
        public string Surname { get; set; }
        public string GivenNames { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var isUganda = CountryCode.ToUpper() == "UG";
            if (isUganda)
            {
                if (DocumentNumber.Length != 14)
                    yield return new ValidationResult($"{nameof(DocumentNumber)} must be 14 characters", new[] { nameof(DocumentNumber) });

                if (string.IsNullOrEmpty(SerialNumber))
                    yield return new ValidationResult($"The {nameof(SerialNumber)} field is required.", new[] { nameof(SerialNumber) });

                if (!string.IsNullOrEmpty(SerialNumber) && SerialNumber.Length != 9)
                    yield return new ValidationResult($"{nameof(SerialNumber)} must be 9 characters", new[] { nameof(SerialNumber) });

                if (string.IsNullOrEmpty(Surname) && string.IsNullOrEmpty(GivenNames) && DateOfBirth == null)
                    yield return new ValidationResult($"Include at least surname, given names or the date of birth", new[] { "OtherFeilds" });
            }
        }
    }
}