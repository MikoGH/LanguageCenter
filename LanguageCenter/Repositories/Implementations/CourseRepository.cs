using LanguageCenter.Data;
using LanguageCenter.Models.Entity;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LanguageCenter.Repositories.Implementations
{
	public class CourseRepository : ICourseRepository
	{
		private readonly Context context;
		public CourseRepository(Context context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<CourseEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await context.Courses.ToListAsync(cancellationToken);
		}

		public async Task<CourseEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Courses.FirstOrDefaultAsync(course => course.Id == id, cancellationToken);
		}

		public async Task<CourseEntity> InsertAsync(CourseEntity course, CancellationToken cancellationToken)
		{
			await context.Courses.AddAsync(course, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return course;
		}

		public async Task<CourseEntity> UpdateAsync(CourseEntity course, CancellationToken cancellationToken)
		{
			context.Courses.Update(course);
			await context.SaveChangesAsync(cancellationToken);
			return course;
		}

		public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
		{
			CourseEntity course = await GetByIdAsync(id, cancellationToken);
			if (course == null) return false;
			context.Courses.Remove(course);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}

		public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Courses.AnyAsync(course => course.Id == id, cancellationToken);
		}
	}
}
