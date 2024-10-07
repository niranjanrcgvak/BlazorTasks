using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Task2.Web.Models
{
    public class AuthResponse
    {
        public string Token { get; set; }
    }

    public class TodoModel
    {
        [Required]
        public string Description { get; set; }
    }

    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsEditing { get; set; }
    }


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

    public class ErrorDetail
    {
        public string Code { get; set; }
        public string Description { get; set; }
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

    public class TodoEditModel
    {
        [Required]
        public string Description { get; set; }

        public int Id { get; set; }
    }


    public class TodoUsers
    {
        public string UserName { get; set; }
        public int TodoCount { get; set; }
        public int CompletedCount { get; set; }
    }

}
