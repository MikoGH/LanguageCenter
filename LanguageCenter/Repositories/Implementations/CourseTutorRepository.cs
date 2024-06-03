using LanguageCenter.Data;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanguageCenter.Repositories.Implementations
{
	public class CourseTutorRepository : ICourseTutorRepository
	{
		private readonly Context context;
		public CourseTutorRepository(Context context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<CourseTutorEntity>> GetByCourseIdAsync(int courseId, CancellationToken cancellationToken)
		{
			return await context.CoursesTutors.Where(courseTutor => courseTutor.CourseId == courseId).ToListAsync(cancellationToken);
		}

		public async Task<IEnumerable<CourseTutorEntity>> GetByPersonIdAsync(int personId, CancellationToken cancellationToken)
		{
			return await context.CoursesTutors.Where(courseTutor => courseTutor.PersonId == personId).ToListAsync(cancellationToken);
		}

		public async Task<CourseTutorEntity> InsertAsync(CourseTutorEntity courseTutor, CancellationToken cancellationToken)
		{
			context.CoursesTutors.Add(courseTutor);
			await context.SaveChangesAsync(cancellationToken);
			return courseTutor;
		}

		public async Task<bool> DeleteAsync(CourseTutorEntity courseTutor, CancellationToken cancellationToken)
		{
			if (!await context.CoursesTutors.AnyAsync(ct => ct.Equals(courseTutor), cancellationToken)) return false;
			context.CoursesTutors.Remove(courseTutor);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}
	}
}
