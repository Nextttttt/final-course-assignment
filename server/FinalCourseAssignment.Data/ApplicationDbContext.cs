using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace FinalCourseAssignment.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public override void OnModelCreating(ModuleBuilder moduleBuilder)
        {
            base.OnModelCreating(moduleBuilder);
        }
    }
}