using LanguageCenter.Data;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanguageCenter.Repositories.Implementations
{
	public class GroupRepository : IGroupRepository
	{
		private readonly Context context;
		public GroupRepository(Context context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<GroupEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await context.Groups.ToListAsync(cancellationToken);
		}

		public async Task<GroupEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Groups.FirstOrDefaultAsync(group => group.Id == id, cancellationToken);
		}

		public async Task<GroupEntity> InsertAsync(GroupEntity group, CancellationToken cancellationToken)
		{
			await context.Groups.AddAsync(group, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return group;
		}

		public async Task<GroupEntity> UpdateAsync(GroupEntity group, CancellationToken cancellationToken)
		{
			context.Groups.Update(group);
			await context.SaveChangesAsync(cancellationToken);
			return group;
		}

		public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
		{
			GroupEntity group = await GetByIdAsync(id, cancellationToken);
			if (group == null) return false;
			context.Groups.Remove(group);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}

		public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Groups.AnyAsync(group => group.Id == id, cancellationToken);
		}
	}
}
