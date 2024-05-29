using LanguageCenter.Models.Entity;

namespace LanguageCenter.Repositories.Interfaces
{
	public interface ILevelRepository
	{
		public Task<IEnumerable<LevelEntity>> GetAllAsync(CancellationToken cancellationToken);
		public Task<LevelEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
		public Task<LevelEntity> InsertAsync(LevelEntity level, CancellationToken cancellationToken);
		public Task<LevelEntity> UpdateAsync(LevelEntity level, CancellationToken cancellationToken);
		public Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken);
		public Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken);
	}
}
