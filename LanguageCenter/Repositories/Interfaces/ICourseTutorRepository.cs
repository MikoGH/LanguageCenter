using LanguageCenter.Models;

namespace LanguageCenter.Repositories.Interfaces
{
	public interface ICourseTutorRepository
	{
		public Task<IEnumerable<CourseTutorEntity>> GetByCourseIdAsync(int courseId, CancellationToken cancellationToken);
		public Task<IEnumerable<CourseTutorEntity>> GetByPersonIdAsync(int personId, CancellationToken cancellationToken);
		public Task<CourseTutorEntity> InsertAsync(CourseTutorEntity courseTutor, CancellationToken cancellationToken);
		public Task<bool> DeleteAsync(CourseTutorEntity courseTutor, CancellationToken cancellationToken);
	}
}
