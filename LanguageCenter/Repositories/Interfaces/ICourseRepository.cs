using LanguageCenter.Models;

namespace LanguageCenter.Repositories.Interfaces
{
	public interface ICourseRepository
	{
		public Task<IEnumerable<CourseEntity>> GetAllAsync(CancellationToken cancellationToken);
		public Task<CourseEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
		public Task<CourseEntity> InsertAsync(CourseEntity course, CancellationToken cancellationToken);
		public Task<CourseEntity> UpdateAsync(CourseEntity course, CancellationToken cancellationToken);
		public Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken);
		public Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken);
	}
}
