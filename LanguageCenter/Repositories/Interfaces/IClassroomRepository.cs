using LanguageCenter.Data;
using LanguageCenter.Models;

namespace LanguageCenter.Repositories.Interfaces
{
	public interface IClassroomRepository
	{
		public Task<IEnumerable<ClassroomEntity>> GetAllAsync(CancellationToken cancellationToken);
		public Task<ClassroomEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
		public Task<ClassroomEntity> InsertAsync(ClassroomEntity classroom, CancellationToken cancellationToken);
		public Task<ClassroomEntity> UpdateAsync(ClassroomEntity classroom, CancellationToken cancellationToken);
		public Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken);
		public Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken);
	}
}
