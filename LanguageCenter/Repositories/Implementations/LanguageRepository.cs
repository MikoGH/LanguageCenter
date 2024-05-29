using LanguageCenter.Data;
using LanguageCenter.Models.Entity;
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

		public async Task<IEnumerable<LanguageEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await context.Languages.ToListAsync(cancellationToken);
		}

		public async Task<LanguageEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Languages.FirstOrDefaultAsync(language => language.Id == id, cancellationToken);
		}

		public async Task<LanguageEntity> InsertAsync(LanguageEntity language, CancellationToken cancellationToken)
		{
			await context.Languages.AddAsync(language, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return language;
		}

		public async Task<LanguageEntity> UpdateAsync(LanguageEntity language, CancellationToken cancellationToken)
		{
			context.Languages.Update(language);
			await context.SaveChangesAsync(cancellationToken);
			return language;
		}

		public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
		{
			LanguageEntity language = await GetByIdAsync(id, cancellationToken);
			if (language == null) return false;
			context.Languages.Remove(language);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}

		public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Languages.AnyAsync(language => language.Id == id, cancellationToken);
		}
	}
}
