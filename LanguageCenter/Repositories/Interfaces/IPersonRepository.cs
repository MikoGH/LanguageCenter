using LanguageCenter.Models.Entity;

namespace LanguageCenter.Repositories.Interfaces
{
	public interface IPersonRepository
	{
		public Task<IEnumerable<PersonEntity>> GetAllAsync(CancellationToken cancellationToken);
		public Task<PersonEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
		public Task<PersonEntity> GetByLoginAsync(string login, CancellationToken cancellationToken);
		public Task<PersonEntity> InsertAsync(PersonEntity person, CancellationToken cancellationToken);
		public Task<PersonEntity> UpdateAsync(PersonEntity person, CancellationToken cancellationToken);
		public Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken);
		public Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken);
		public Task<bool> ExistsByLoginAsync(string login, CancellationToken cancellationToken);
	}
}
