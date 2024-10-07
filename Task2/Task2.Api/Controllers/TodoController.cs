using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Task2.Web.Api.Data;
using Task2.Web.Api.Models;

namespace Task2.Web.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/todo")]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetTodoItems()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var items = await _context.TodoItems.Where(t => t.UserId == userId).ToListAsync();
            return Ok(items);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTodoItem([FromBody] TodoItem item)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            item.UserId = userId;
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoItems), new { id = item.Id }, item);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditTodoItem([FromBody] TodoItem item)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            item.UserId = userId;
            var toDoitem = await _context.TodoItems.Where(t => t.Id == item.Id).FirstOrDefaultAsync();
            toDoitem.Description = item.Description;
            toDoitem.IsCompleted = item.IsCompleted;
            _context.Update(toDoitem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoItems), new { id = item.Id }, item);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var toDoitem = await _context.TodoItems.Where(t => t.Id == id).FirstOrDefaultAsync();
            _context.Remove(toDoitem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoItems), new { id = id }, toDoitem);
        }
    }


}
