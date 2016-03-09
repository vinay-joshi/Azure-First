using System;
using System.ComponentModel.DataAnnotations;
using Azure_First.Web.Extensions;

namespace Azure_First.Web.Validator
{
    public class AgeRangeAttribute : ValidationAttribute
    {
        private int _highAge;
        private int _lowAge;

        public AgeRangeAttribute(int lowAge, int highAge)
        {
            _lowAge = lowAge;
            _highAge = highAge;
            ErrorMessage = "{0} must be between 18 to 120";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is DateTime))
            {
                throw new ValidationException("Add range is only valid for datetime properties");
            }

            var birthday = (DateTime)value;

            if(birthday.CalculateAge() < _lowAge || birthday.CalculateAge() > _highAge)
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.MemberName));
            }
            else
            {
                return ValidationResult.Success;
            }
                
        }
    }
}