using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Officeworkflows.Api.Data;
using Officeworkflows.Api.Models;

namespace Officeworkflows.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Create Task
        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskRequest request)
        {
            // ✅ If AssignedToUserId is 0 or invalid → set to null
            int? assignedUserId = null;

            if (request.AssignedToUserId.HasValue && request.AssignedToUserId.Value > 0)
            {
                // check if user exists
                var userExists = await _context.Users.AnyAsync(u => u.Id == request.AssignedToUserId.Value);
                if (userExists)
                    assignedUserId = request.AssignedToUserId.Value;
            }

            var task = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
                Deadline = request.Deadline,
                AssignedToUserId = assignedUserId // ✅ safe assignment
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return Ok(task);
        }



        // ✅ Get ALL Tasks
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _context.Tasks.Include(t => t.AssignedToUser).ToListAsync();
            return Ok(tasks);
        }

        // ✅ Mark task as completed
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> MarkCompleted(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            task.IsCompleted = true;
            await _context.SaveChangesAsync();

            return Ok("Task marked as complete ✅");
        }
    }
}
