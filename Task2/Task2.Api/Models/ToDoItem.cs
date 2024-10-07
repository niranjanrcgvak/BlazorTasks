using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Task2.Web.Api.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
