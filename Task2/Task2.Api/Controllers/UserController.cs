using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.Web.Api.Data;
using Task2.Web.Api.Models;

namespace Task2.Web.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetUsers()
        {
            var usersWithTodoStats = await _userManager.Users
                .Select(user => new
                {
                    Username = user.UserName,
                    TodoCount = _context.TodoItems.Count(todo => todo.UserId == user.Id),
                    CompletedCount = _context.TodoItems.Count(todo => todo.UserId == user.Id && todo.IsCompleted)
                })
                .ToListAsync();

            return Ok(usersWithTodoStats);
        }
    }



}
