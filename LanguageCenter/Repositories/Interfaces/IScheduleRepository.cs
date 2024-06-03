using LanguageCenter.Models;

namespace LanguageCenter.Repositories.Interfaces
{
	public interface IScheduleRepository
	{
		public Task<IEnumerable<ScheduleEntity>> GetAllAsync(CancellationToken cancellationToken);
		public Task<ScheduleEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
		public Task<ScheduleEntity> InsertAsync(ScheduleEntity schedule, CancellationToken cancellationToken);
		public Task<ScheduleEntity> UpdateAsync(ScheduleEntity schedule, CancellationToken cancellationToken);
		public Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken);
		public Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken);
	}
}
