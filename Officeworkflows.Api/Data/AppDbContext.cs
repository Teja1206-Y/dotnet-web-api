using Microsoft.EntityFrameworkCore;
using Officeworkflows.Api.Models;

namespace Officeworkflows.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        

    }
}
