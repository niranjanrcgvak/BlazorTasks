using System.ComponentModel.DataAnnotations;

namespace Task2.Web.Api.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class TodoModel
    {
        [Required]
        public string Title { get; set; }
    }
}
