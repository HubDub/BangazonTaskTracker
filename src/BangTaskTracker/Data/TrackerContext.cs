using Microsoft.EntityFrameworkCore;
using BangTaskTracker.Models;

namespace BangTaskTracker.Data
{
    public class TrackerContext : DbContext 
    {
        public TrackerContext(DbContextOptions<TrackerContext> options) : base(options)
        { }

        public DbSet<TrackedTask> TrackedTask { get; set; }

    }
}
