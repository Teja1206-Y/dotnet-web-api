using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Officeworkflows.Api.Data;
using Officeworkflows.Api.Models;
using OfficeWorkflows.Api.DTOs.Leave;

namespace Officeworkflows.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LeaveController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ APPLY for Leave (Employee)
      
        [HttpPost]
        public async Task<IActionResult> ApplyLeave([FromBody] CreateLeaveDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid leave request.");

            // ⚠️ TODO: Replace with actual user ID from JWT
            int userId = 1;

            var leaveRequest = new LeaveRequest
            {
                UserId = userId,
                FromDate = dto.FromDate,
                ToDate = dto.ToDate,
                Reason = dto.Reason,
                Status = "Pending",
                RequestedDate = DateTime.UtcNow
            };

            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Leave request submitted successfully!",
                leaveId = leaveRequest.Id
            });
        }


        // ✅ Get all leave requests (Admin View)
        [HttpGet]
        public async Task<IActionResult> GetLeaves()
        {
            var leaves = await _context.LeaveRequests
                .Include(l => l.User)
                .ToListAsync();

            return Ok(leaves);
        }

        // ✅ Approve leave
        [HttpPut("{id}/approve")]
        public async Task<IActionResult> ApproveLeave(int id)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);
            if (leave == null) return NotFound();

            leave.Status = "Approved";
            await _context.SaveChangesAsync();

            return Ok("Leave approved ✅");
        }

        // ✅ Reject leave
        [HttpPut("{id}/reject")]
        public async Task<IActionResult> RejectLeave(int id)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);
            if (leave == null) return NotFound();

            leave.Status = "Rejected";
            await _context.SaveChangesAsync();

            return Ok("Leave rejected ❌");
        }
    }
}
