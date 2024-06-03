using LanguageCenter.Models;

namespace LanguageCenter.Repositories.Interfaces
{
	public interface IGroupRepository
	{
		public Task<IEnumerable<GroupEntity>> GetAllAsync(CancellationToken cancellationToken);
		public Task<GroupEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
		public Task<GroupEntity> InsertAsync(GroupEntity group, CancellationToken cancellationToken);
		public Task<GroupEntity> UpdateAsync(GroupEntity group, CancellationToken cancellationToken);
		public Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken);
		public Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken);
	}
}
