using LanguageCenter.Data;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanguageCenter.Repositories.Implementations
{
	public class ClassroomRepository : IClassroomRepository
	{
		private readonly Context context;
		public ClassroomRepository(Context context)
		{
			this.context = context;
		}

		/// <summary>
		/// Получить список всех кабинетов
		/// </summary>
		/// <returns>Список кабинетов</returns>
		public async Task<IEnumerable<ClassroomEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await context.Classrooms.ToListAsync(cancellationToken);
		}

		/// <summary>
		/// Получить кабинет по id
		/// </summary>
		/// <param name="id">id кабинета</param>
		/// <returns>Кабинет</returns>
		public async Task<ClassroomEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Classrooms.FirstOrDefaultAsync(classroom => classroom.Id == id, cancellationToken);
		}

		/// <summary>
		/// Добавить новый кабинет
		/// </summary>
		/// <param name="classroom">Кабинет</param>
		/// <returns>Кабинет</returns>
		public async Task<ClassroomEntity> InsertAsync(ClassroomEntity classroom, CancellationToken cancellationToken)
		{
			await context.Classrooms.AddAsync(classroom, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return classroom;
		}

		/// <summary>
		/// Изменить кабинет
		/// </summary>
		/// <param name="classroom">Кабинет</param>
		/// <returns>Кабинет</returns>
		public async Task<ClassroomEntity> UpdateAsync(ClassroomEntity classroom, CancellationToken cancellationToken)
		{
			context.Classrooms.Update(classroom);
			await context.SaveChangesAsync(cancellationToken);
			return classroom;
		}

		/// <summary>
		/// Удалить кабинет по id
		/// </summary>
		/// <param name="id">id кабинета</param>
		/// <returns>false если id отсутствует; иначе true</returns>
		public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
		{
			ClassroomEntity classroom = await GetByIdAsync(id, cancellationToken);
			if (classroom == null) return false;
			context.Classrooms.Remove(classroom);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}

		/// <summary>
		/// Проверить, существует ли кабинет с данным id
		/// </summary>
		/// <param name="id">id кабинета</param>
		/// <returns>true если id существует, иначе false</returns>
		public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Classrooms.AnyAsync(classroom => classroom.Id == id, cancellationToken);
		}
	}
}
