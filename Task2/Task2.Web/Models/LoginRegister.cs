using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Task2.Web.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordRequirements]
        public string Password { get; set; }
    }

    public class RegisterResponse
    {
        public bool IsSucceeded { get; set; }
        public List<ErrorDetail> Errors { get; set; }
    }

    public class PasswordRequirementsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;

            if (string.IsNullOrWhiteSpace(password))
            {
                return new ValidationResult("Password is required.");
            }

            if (password.Length < 6)
            {
                return new ValidationResult("Password must be at least 6 characters long.");
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                return new ValidationResult("Password must have at least one uppercase letter ('A'-'Z').");
            }

            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                return new ValidationResult("Password must have at least one digit ('0'-'9').");
            }

            if (!Regex.IsMatch(password, @"[^a-zA-Z0-9]"))
            {
                return new ValidationResult("Password must have at least one non-alphanumeric character.");
            }

            return ValidationResult.Success;
        }
    }
}
