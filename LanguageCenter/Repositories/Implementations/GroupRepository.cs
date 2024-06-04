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

		/// <summary>
		/// Получить список всех групп
		/// </summary>
		/// <returns>Список групп</returns>
		public async Task<IEnumerable<GroupEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await context.Groups.ToListAsync(cancellationToken);
		}

		/// <summary>
		/// Получить группу по id
		/// </summary>
		/// <param name="id">id группы</param>
		/// <returns>Группа</returns>
		public async Task<GroupEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Groups.FirstOrDefaultAsync(group => group.Id == id, cancellationToken);
		}

		/// <summary>
		/// Добавить новую группу
		/// </summary>
		/// <param name="group">Группа</param>
		/// <returns>Группа</returns>
		public async Task<GroupEntity> InsertAsync(GroupEntity group, CancellationToken cancellationToken)
		{
			await context.Groups.AddAsync(group, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return group;
		}

		/// <summary>
		/// Изменить группу
		/// </summary>
		/// <param name="group">Группа</param>
		/// <returns>Группа</returns>
		public async Task<GroupEntity> UpdateAsync(GroupEntity group, CancellationToken cancellationToken)
		{
			context.Groups.Update(group);
			await context.SaveChangesAsync(cancellationToken);
			return group;
		}

		/// <summary>
		/// Удалить группу по id
		/// </summary>
		/// <param name="id">id группы</param>
		/// <returns>false если id отсутствует; иначе true</returns>
		public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
		{
			GroupEntity group = await GetByIdAsync(id, cancellationToken);
			if (group == null) return false;
			context.Groups.Remove(group);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}

		/// <summary>
		/// Проверить, существует ли группа с данным id
		/// </summary>
		/// <param name="id">id группы</param>
		/// <returns>true если id существует, иначе false</returns>
		public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Groups.AnyAsync(group => group.Id == id, cancellationToken);
		}
	}
}
