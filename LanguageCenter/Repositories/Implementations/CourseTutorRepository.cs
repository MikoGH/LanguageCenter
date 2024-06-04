using LanguageCenter.Data;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanguageCenter.Repositories.Implementations
{
	public class CourseTutorRepository : ICourseTutorRepository
	{
		private readonly Context context;
		public CourseTutorRepository(Context context)
		{
			this.context = context;
		}

		/// <summary>
		/// Получить список связей курс-преподаватель по id курса
		/// </summary>
		/// <param name="courseId">id курса</param>
		/// <returns>Список связей курс-преподаватель</returns>
		public async Task<IEnumerable<CourseTutorEntity>> GetByCourseIdAsync(int courseId, CancellationToken cancellationToken)
		{
			return await context.CoursesTutors.Where(courseTutor => courseTutor.CourseId == courseId).ToListAsync(cancellationToken);
		}

		/// <summary>
		/// Получить список связей курс-преподаватель по id преподавателя
		/// </summary>
		/// <param name="personId">id преподавателя</param>
		/// <returns>Список связей курс-преподаватель</returns>
		public async Task<IEnumerable<CourseTutorEntity>> GetByPersonIdAsync(int personId, CancellationToken cancellationToken)
		{
			return await context.CoursesTutors.Where(courseTutor => courseTutor.PersonId == personId).ToListAsync(cancellationToken);
		}

		/// <summary>
		/// Добавить новую связь курс-преподаватель
		/// </summary>
		/// <param name="courseTutor">Связь курс-преподаватель</param>
		/// <returns>Связь курс-преподаватель</returns>
		public async Task<CourseTutorEntity> InsertAsync(CourseTutorEntity courseTutor, CancellationToken cancellationToken)
		{
			if (await context.CoursesTutors.AnyAsync(ct => ct.Equals(courseTutor), cancellationToken)) return null;
			context.CoursesTutors.Add(courseTutor);
			await context.SaveChangesAsync(cancellationToken);
			return courseTutor;
		}

		/// <summary>
		/// Удалить связь курс-преподаватель
		/// </summary>
		/// <param name="courseTutor">Связь курс-преподаватель</param>
		/// <returns>false если связь отсутствует; иначе true</returns>
		public async Task<bool> DeleteAsync(CourseTutorEntity courseTutor, CancellationToken cancellationToken)
		{
			if (!await context.CoursesTutors.AnyAsync(ct => ct.Equals(courseTutor), cancellationToken)) return false;
			context.CoursesTutors.Remove(courseTutor);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}
	}
}
