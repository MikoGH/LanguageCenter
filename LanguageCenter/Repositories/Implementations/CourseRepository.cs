using LanguageCenter.Data;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LanguageCenter.Repositories.Implementations
{
	public class CourseRepository : ICourseRepository
	{
		private readonly Context context;
		public CourseRepository(Context context)
		{
			this.context = context;
		}

		/// <summary>
		/// Получить список всех курсов
		/// </summary>
		/// <returns>Список курсов</returns>
		public async Task<IEnumerable<CourseEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await context.Courses.ToListAsync(cancellationToken);
		}

		/// <summary>
		/// Получить курс по id
		/// </summary>
		/// <param name="id">id курса</param>
		/// <returns>Курс</returns>
		public async Task<CourseEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Courses.FirstOrDefaultAsync(course => course.Id == id, cancellationToken);
		}

		/// <summary>
		/// Добавить новый курс
		/// </summary>
		/// <param name="course">Курс</param>
		/// <returns>Курс</returns>
		public async Task<CourseEntity> InsertAsync(CourseEntity course, CancellationToken cancellationToken)
		{
			await context.Courses.AddAsync(course, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return course;
		}

		/// <summary>
		/// Изменить курс
		/// </summary>
		/// <param name="course">Курс</param>
		/// <returns>Курс</returns>
		public async Task<CourseEntity> UpdateAsync(CourseEntity course, CancellationToken cancellationToken)
		{
			context.Courses.Update(course);
			await context.SaveChangesAsync(cancellationToken);
			return course;
		}

		/// <summary>
		/// Удалить курс по id
		/// </summary>
		/// <param name="id">id курса</param>
		/// <returns>false если id отсутствует; иначе true</returns>
		public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
		{
			CourseEntity course = await GetByIdAsync(id, cancellationToken);
			if (course == null) return false;
			context.Courses.Remove(course);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}

		/// <summary>
		/// Проверить, существует ли курс с данным id
		/// </summary>
		/// <param name="id">id курса</param>
		/// <returns>true если id существует, иначе false</returns>
		public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Courses.AnyAsync(course => course.Id == id, cancellationToken);
		}
	}
}
