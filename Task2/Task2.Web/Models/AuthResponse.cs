using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Task2.Web.Models
{
    public class AuthResponse
    {
        public string Token { get; set; }
    }

    public class ErrorDetail
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }   

}
