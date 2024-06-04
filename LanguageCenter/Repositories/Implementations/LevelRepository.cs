using LanguageCenter.Data;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LanguageCenter.Repositories.Implementations
{
	public class LevelRepository : ILevelRepository
	{
		Context context;
		public LevelRepository(Context context)
		{
			this.context = context;
		}

		/// <summary>
		/// Получить список всех уровней владения
		/// </summary>
		/// <returns>Список уровней владения</returns>
		public async Task<IEnumerable<LevelEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await context.Levels.ToListAsync(cancellationToken);
		}

		/// <summary>
		/// Получить уровень владения по id
		/// </summary>
		/// <param name="id">id уровня владения</param>
		/// <returns>Уровень владения</returns>
		public async Task<LevelEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Levels.FirstOrDefaultAsync(level => level.Id == id, cancellationToken);
		}

		/// <summary>
		/// Добавить новый уровень владения
		/// </summary>
		/// <param name="level">Уровень владения</param>
		/// <returns>Уровень владения</returns>
		public async Task<LevelEntity> InsertAsync(LevelEntity level, CancellationToken cancellationToken)
		{
			await context.Levels.AddAsync(level, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return level;
		}

		/// <summary>
		/// Изменить уровень владения
		/// </summary>
		/// <param name="level">Уровень владения</param>
		/// <returns>Уровень владения</returns>
		public async Task<LevelEntity> UpdateAsync(LevelEntity level, CancellationToken cancellationToken)
		{
			context.Levels.Update(level);
			await context.SaveChangesAsync(cancellationToken);
			return level;
		}

		/// <summary>
		/// Удалить уровень владения по id
		/// </summary>
		/// <param name="id">id уровня владения</param>
		/// <returns>false если id отсутствует; иначе true</returns>
		public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
		{
			LevelEntity level = await GetByIdAsync(id, cancellationToken);
			if (level == null) return false;
			context.Levels.Remove(level);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}

		/// <summary>
		/// Проверить, существует ли уровень владения с данным id
		/// </summary>
		/// <param name="id">id уровня владения</param>
		/// <returns>true если id существует, иначе false</returns>
		public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Levels.AnyAsync(level => level.Id == id, cancellationToken);
		}
	}
}
