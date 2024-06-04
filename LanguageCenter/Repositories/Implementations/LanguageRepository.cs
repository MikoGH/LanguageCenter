using LanguageCenter.Data;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace LanguageCenter.Repositories.Implementations
{
	public class LanguageRepository : ILanguageRepository
	{
		Context context;
		public LanguageRepository(Context context)
		{
			this.context = context;
		}

		/// <summary>
		/// Получить список всех языков
		/// </summary>
		/// <returns>Список языков</returns>
		public async Task<IEnumerable<LanguageEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await context.Languages.ToListAsync(cancellationToken);
		}

		/// <summary>
		/// Получить язык по id
		/// </summary>
		/// <param name="id">id языка</param>
		/// <returns>Язык</returns>
		public async Task<LanguageEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Languages.FirstOrDefaultAsync(language => language.Id == id, cancellationToken);
		}

		/// <summary>
		/// Добавить новый язык
		/// </summary>
		/// <param name="language">Язык</param>
		/// <returns>Язык</returns>
		public async Task<LanguageEntity> InsertAsync(LanguageEntity language, CancellationToken cancellationToken)
		{
			await context.Languages.AddAsync(language, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return language;
		}

		/// <summary>
		/// Изменить язык
		/// </summary>
		/// <param name="language">Язык</param>
		/// <returns>Язык</returns>
		public async Task<LanguageEntity> UpdateAsync(LanguageEntity language, CancellationToken cancellationToken)
		{
			context.Languages.Update(language);
			await context.SaveChangesAsync(cancellationToken);
			return language;
		}

		/// <summary>
		/// Удалить язык по id
		/// </summary>
		/// <param name="id">id языка</param>
		/// <returns>false если id отсутствует; иначе true</returns>
		public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
		{
			LanguageEntity language = await GetByIdAsync(id, cancellationToken);
			if (language == null) return false;
			context.Languages.Remove(language);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}

		/// <summary>
		/// Проверить, существует ли язык с данным id
		/// </summary>
		/// <param name="id">id языка</param>
		/// <returns>true если id существует, иначе false</returns>
		public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Languages.AnyAsync(language => language.Id == id, cancellationToken);
		}
	}
}
