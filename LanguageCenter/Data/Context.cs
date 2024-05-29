using LanguageCenter.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace LanguageCenter.Data
{
	public class Context : DbContext
	{
		public DbSet<LanguageEntity> Languages { get; set; }
		public DbSet<LevelEntity> Levels { get; set; }
		public DbSet<CourseEntity> Courses { get; set; }
		public DbSet<PersonEntity> Persons { get; set; }

		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.UseSerialColumns();
		}
	}
}
