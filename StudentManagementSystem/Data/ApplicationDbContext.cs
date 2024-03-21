using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystemShared.Models;

namespace StudentManagementSystem.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<SystemCode> SystemCodes { get; set; }
        public DbSet<SystemCodeDetail> SystemCodeDetails { get; set; }
        public DbSet<Parent> Parents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);
            builder.Entity<Parent>()
                        .HasOne(f => f.Student)
                        .WithMany()
                        .HasForeignKey(f => f.StudentId)
                        .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Parent>()
                      .HasOne(f => f.Gender)
                      .WithMany()
                      .HasForeignKey(f => f.GenderId)
                      .OnDelete(DeleteBehavior.Restrict);

        }

    }


}
