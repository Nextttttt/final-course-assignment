using System.Reflection.Emit;
using FinalCourseAssignment.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace FinalCourseAssignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { 

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Discussion> Discussions { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}