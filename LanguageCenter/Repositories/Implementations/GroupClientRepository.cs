using LanguageCenter.Data;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanguageCenter.Repositories.Implementations
{
	public class GroupClientRepository : IGroupClientRepository
	{
		private readonly Context context;
		public GroupClientRepository(Context context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<GroupClientEntity>> GetByGroupIdAsync(int groupId, CancellationToken cancellationToken)
		{
			return await context.GroupsClients.Where(groupClient => groupClient.GroupId == groupId).ToListAsync(cancellationToken);
		}

		public async Task<IEnumerable<GroupClientEntity>> GetByPersonIdAsync(int personId, CancellationToken cancellationToken)
		{
			return await context.GroupsClients.Where(groupClient => groupClient.PersonId == personId).ToListAsync(cancellationToken);
		}

		public async Task<GroupClientEntity> InsertAsync(GroupClientEntity groupClient, CancellationToken cancellationToken)
		{
			context.GroupsClients.Add(groupClient);
			await context.SaveChangesAsync(cancellationToken);
			return groupClient;
		}

		public async Task<bool> DeleteAsync(GroupClientEntity groupClient, CancellationToken cancellationToken)
		{
			if (!await context.GroupsClients.AnyAsync(gc => gc.Equals(groupClient), cancellationToken)) return false;
			context.GroupsClients.Remove(groupClient);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}
	}
}
