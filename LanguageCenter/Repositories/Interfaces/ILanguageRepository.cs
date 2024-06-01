using LanguageCenter.Models;

namespace LanguageCenter.Repositories.Interfaces
{
	public interface ILanguageRepository
	{
		public Task<IEnumerable<LanguageEntity>> GetAllAsync(CancellationToken cancellationToken);
		public Task<LanguageEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
		public Task<LanguageEntity> InsertAsync(LanguageEntity language, CancellationToken cancellationToken);
		public Task<LanguageEntity> UpdateAsync(LanguageEntity language, CancellationToken cancellationToken);
		public Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken);
		public Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken);
	}
}
