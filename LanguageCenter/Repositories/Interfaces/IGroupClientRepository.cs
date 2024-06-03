using LanguageCenter.Models;

namespace LanguageCenter.Repositories.Interfaces
{
	public interface IGroupClientRepository
	{
		public Task<IEnumerable<GroupClientEntity>> GetByGroupIdAsync(int groupId, CancellationToken cancellationToken);
		public Task<IEnumerable<GroupClientEntity>> GetByPersonIdAsync(int personId, CancellationToken cancellationToken);
		public Task<GroupClientEntity> InsertAsync(GroupClientEntity groupClient, CancellationToken cancellationToken);
		public Task<bool> DeleteAsync(GroupClientEntity groupClient, CancellationToken cancellationToken);
	}
}
