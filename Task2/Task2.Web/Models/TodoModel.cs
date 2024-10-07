using System.ComponentModel.DataAnnotations;

namespace Task2.Web.Models
{
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
