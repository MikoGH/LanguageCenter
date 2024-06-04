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

		/// <summary>
		/// Получить список связей группа-клиент по id
		/// </summary>
		/// <param name="groupId">id группы</param>
		/// <returns>Список связей группа-клиент</returns>
		public async Task<IEnumerable<GroupClientEntity>> GetByGroupIdAsync(int groupId, CancellationToken cancellationToken)
		{
			return await context.GroupsClients.Where(groupClient => groupClient.GroupId == groupId).ToListAsync(cancellationToken);
		}

		/// <summary>
		/// Получить список связей группа-клиент по id
		/// </summary>
		/// <param name="personId">id клиента</param>
		/// <returns>Список связей группа-клиент</returns>
		public async Task<IEnumerable<GroupClientEntity>> GetByPersonIdAsync(int personId, CancellationToken cancellationToken)
		{
			return await context.GroupsClients.Where(groupClient => groupClient.PersonId == personId).ToListAsync(cancellationToken);
		}

		/// <summary>
		/// Добавить новую связь группа-клиент
		/// </summary>
		/// <param name="groupClient">Связь группа-клиент</param>
		/// <returns>Связь группа-клиент</returns>
		public async Task<GroupClientEntity> InsertAsync(GroupClientEntity groupClient, CancellationToken cancellationToken)
		{
			if (await context.GroupsClients.AnyAsync(gc => gc.Equals(groupClient), cancellationToken)) return null;
			context.GroupsClients.Add(groupClient);
			await context.SaveChangesAsync(cancellationToken);
			return groupClient;
		}

		/// <summary>
		/// Удалить связь группа-клиент
		/// </summary>
		/// <param name="groupClient">Связь группа-клиент</param>
		/// <returns>false если связь отсутствует; иначе true</returns>
		public async Task<bool> DeleteAsync(GroupClientEntity groupClient, CancellationToken cancellationToken)
		{
			if (!await context.GroupsClients.AnyAsync(gc => gc.Equals(groupClient), cancellationToken)) return false;
			context.GroupsClients.Remove(groupClient);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}
	}
}
