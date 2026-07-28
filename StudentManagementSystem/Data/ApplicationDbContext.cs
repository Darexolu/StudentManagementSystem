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
        public DbSet<Teacher> Teachers { get; set; }
		public DbSet<SchoolClass> SchoolClasses { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<ClassSubject> ClassSubjects { get; set; }
		public DbSet<Result> Results { get; set; }
		public DbSet<ClassTimeTable> ClassTimeTables { get; set; }
		public DbSet<StudentAttendance> StudentAttendances { get; set; }
		public DbSet<SystemSetting> SystemSettings { get; set; }

		public DbSet<ParentStudent> ParentStudents { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);

			builder.Entity<ParentStudent>()
	       .HasOne(x => x.Parent)
	       .WithMany(x => x.ParentStudents)
	      .HasForeignKey(x => x.ParentId)
	      .OnDelete(DeleteBehavior.Cascade);

			builder.Entity<ParentStudent>()
				.HasOne(x => x.Student)
				.WithMany(x => x.ParentStudents)
				.HasForeignKey(x => x.StudentId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Entity<ParentStudent>()
				.HasIndex(x => new { x.ParentId, x.StudentId })
				.IsUnique();

			builder.Entity<Teacher>()
	.Property(x => x.Gender)
	.HasConversion<string>();



		}

    }


}
