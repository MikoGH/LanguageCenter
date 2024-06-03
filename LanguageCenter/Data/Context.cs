using LanguageCenter.Models;
using Microsoft.EntityFrameworkCore;

namespace LanguageCenter.Data
{
	public class Context : DbContext
	{
		public DbSet<LanguageEntity> Languages { get; set; }
		public DbSet<LevelEntity> Levels { get; set; }
		public DbSet<CourseEntity> Courses { get; set; }
		public DbSet<PersonEntity> Persons { get; set; }
		public DbSet<GroupEntity> Groups { get; set; }
		public DbSet<CourseTutorEntity> CoursesTutors { get; set; }
		public DbSet<GroupClientEntity> GroupsClients { get; set; }
		public DbSet<AddressEntity> Addresses { get; set; }
		public DbSet<ClassroomEntity> Classrooms { get; set; }
		public DbSet<ScheduleEntity> Schedules { get; set; }

		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.UseSerialColumns();
			modelBuilder.Entity<CourseTutorEntity>()
				  .HasKey(ct => new { ct.CourseId, ct.PersonId });
			modelBuilder.Entity<GroupClientEntity>()
				  .HasKey(gc => new { gc.GroupId, gc.PersonId });
		}
	}
}
